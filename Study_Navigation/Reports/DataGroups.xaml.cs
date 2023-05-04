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
    /// Логика взаимодействия для DataGroups.xaml
    /// </summary>
    public partial class DataGroups : Window
    {
        MyDbContext dbContext = new MyDbContext();
        public DataGroups()
        {
            InitializeComponent();

            ComboBoxItem all = new ComboBoxItem();
            all.Content = "Все";
            all.IsSelected = true;

            Year.Items.Add(all); //Отображаем все образовательные программы в datagrid
            var query = dbContext.Groups.Select(x => new
            {
                x.id_group,
                x.Title_group,
                Year_of_recruiment = x.Year_of_recruitment,
                Elder_of_Group = x.Elder_of_group,
                Director_teacher = x.Teacher.FCs

            }).ToList();

            Data.ItemsSource = query;

            var yearQuery = dbContext.Groups.Select(x => x.Year_of_recruitment).ToList();
            foreach (string year in yearQuery)
                Year.Items.Add(year);
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Pages.TeacherWin teacherWin = new Pages.TeacherWin();
            teacherWin.Show();
            this.Close();
        }

        /// <summary>
        /// Добавление информации о группах с datagrid в лист Excel 
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
            workSheet.Cells[1, 1] = Year.Text == "Все" ? "Все группы " : "Групп " + Year.Text; //Вычисляем выбранную форму обучения
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
            workSheet.Cells[itemsSource.Count + 5, 1] = Year.Text == "Все" ? "Всего групп по году набора: " + itemsSource.Count.ToString() : "Всего груб по году набора " + Year.Text + ": " + itemsSource.Count.ToString();

            excelApp.Visible = true;
            excelApp.DisplayAlerts = false;
        }

        private void Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedItem as string;

            var ed = dbContext.Groups.Where(x => x.Year_of_recruitment == text).ToList();

            if (ed.Count == 0) //Если год не выбран, то отбражаем сообщение с ошибкой
            {
                var query = dbContext.Groups.Select(x => new
                {
                    x.id_group,
                    x.Title_group,
                    Year_of_recruiment = x.Year_of_recruitment,
                    Elder_of_Group = x.Elder_of_group,
                    Director_teacher = x.Teacher.FCs

                }).ToList();

                Data.ItemsSource = query;
            }
            else //Иначе отображаем информацию о выбранном годе набора
            {
                var query = ed.Select(x => new
                {
                    x.id_group,
                    x.Title_group,
                    Year_of_recruiment = x.Year_of_recruitment,
                    Elder_of_Group = x.Elder_of_group,
                    Director_teacher = x.Teacher.FCs

                }).ToList();

                Data.ItemsSource = query;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Year.SelectionChanged += Year_SelectionChanged;
        }
    }
}
