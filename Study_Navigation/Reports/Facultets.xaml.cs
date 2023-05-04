using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace Study_Navigation.Reports
{
    /// <summary>
    /// Логика взаимодействия для Facultets.xaml
    /// </summary>
    public partial class Facultets : Window
    {
        MyDbContext dbContext = new MyDbContext();

        /// <summary>
        /// Заполняем грид данными всех образовательных программ
        /// Изначально в combobox выбраны все формы обучения
        /// Также их можно будет выбрать в будущем
        /// </summary>
        public Facultets()
        {
            InitializeComponent();

            ComboBoxItem all = new ComboBoxItem();
            all.Content = "Все";
            all.IsSelected = true;

            forms_ed.Items.Add(all); //Отображаем все образовательные программы в datagrid
            var query = dbContext.Educational_s.Select(x => new
            {
                x.id_program,
                x.title_program,
                x.head_department,
                title_form = x.Form_Of_.title_form,
                title_specialization = x.Specialization.title_specialization

            }).ToList();

            Data.ItemsSource = query;

            var facQuery = dbContext.Form_Of_s.Select(x => x.title_form).ToList(); //Заполняем данными combobox
            foreach (string fac in facQuery)
                forms_ed.Items.Add(fac);
        }

        /// <summary>
        /// Заполняем таблицу Excel данными из datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelAdd_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            excelApp.SheetsInNewWorkbook = 1;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);

            workSheet.Name = "Отчёт";
            workSheet.Cells[1, 1] = forms_ed.Text == "Все" ? "Все формы обучения" : "Форм обучения " + forms_ed.Text; //Вычисляем выбранную форму обучения
            workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, Data.Columns.Count]].Merge();

            for (int i = 1; i <= Data.Columns.Count; i++)
                workSheet.Cells[3, i] = Data.Columns[i - 1].Header;

            dynamic itemsSource = Data.ItemsSource;//Берем данные из datagrid

            List<string> headers = new List<string>();
            foreach (DataGridTextColumn c in Data.Columns)
                headers.Add((c.Binding as Binding).Path.Path);

            for (int i = 0; i < itemsSource.Count; i++)
            {
                for (int j = 0; j < headers.Count; j++)
                {
                    string cellContent = " " + itemsSource[i].GetType().GetProperty(headers[j]).GetValue(itemsSource[i], null).ToString();
                    workSheet.Cells[i + 4, j + 1] = cellContent;
                }
            }

            workSheet.Range[workSheet.Columns[1], workSheet.Columns[Data.Columns.Count]].AutoFit();
            workSheet.Range[workSheet.Cells[itemsSource.Count + 5, 1], workSheet.Cells[itemsSource.Count + 5, Data.Columns.Count + 1]].Merge();

            //Считаем кол-во всех дисциплин по всем формам обучения/по выбранной форме обучения
            workSheet.Cells[itemsSource.Count + 5, 1] = forms_ed.Text == "Все" ? "Всего факультетов по форме обучения: " + itemsSource.Count.ToString() : "Всего факультетов по форме обучения " + forms_ed.Text + ": " + itemsSource.Count.ToString();

            excelApp.Visible = true;
            excelApp.DisplayAlerts = false;
        }

        /// <summary>
        /// Возвращаемся на главную страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Pages.TeacherWin teacherWin = new Pages.TeacherWin();
            teacherWin.Show();
            this.Close();
        }

        /// <summary>
        /// Выбираем форму обучения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forms_ed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedItem as string;

            var ed = dbContext.Form_Of_s.FirstOrDefault(x => x.title_form == text);

            if (ed == null)//Если форма обучения не выбрана, то отображаем все образовательные программы
            {
                var query = dbContext.Educational_s.Select(x => new
                {
                    x.id_program,
                    x.title_program,
                    x.head_department,
                    title_form = x.Form_Of_.title_form,
                    title_specialization = x.Specialization.title_specialization

                }).ToList();

                Data.ItemsSource = query;
            }
            else//Иначе отображаем программы по выбранной форме обучения
            {
                var query = ed.Educational_s.Select(x => new
                {
                    x.id_program,
                    x.title_program,
                    x.head_department,
                    title_form = x.Form_Of_.title_form,
                    title_specialization = x.Specialization.title_specialization

                }).ToList();

                Data.ItemsSource = query;
            }
        }

        /// <summary>
        /// При загрузке окна сразу заполняем combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            forms_ed.SelectionChanged += forms_ed_SelectionChanged;
        }
    }
}
