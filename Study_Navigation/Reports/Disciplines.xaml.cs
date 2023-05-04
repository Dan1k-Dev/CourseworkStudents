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
using System.Data.Entity;

namespace Study_Navigation.Reports
{
    /// <summary>
    /// Логика взаимодействия для Disciplines.xaml
    /// </summary>
    public partial class Disciplines : Window
    {
        MyDbContext dbContext = new MyDbContext();
        
        /// <summary>
        /// Заполняем данными datagrid - дисциплины, факультеты
        /// При запуске приложения
        /// </summary>
        public Disciplines()
        {
            InitializeComponent();

            ComboBoxItem all = new ComboBoxItem();
            all.Content = "Все";
            all.IsSelected = true;

            teacher.Items.Add(all);
            var query = dbContext.Disciplines.Select(x => new
            {
                x.id_discipline,
                x.title_discipline,
                FCs = x.Teachers.FCs,
                Email = x.Teachers.E_Mail,
                x.quantity_of_hours

            }).ToList();

            Data.ItemsSource = query;

            var teachQuery = dbContext.Teachers.Select(x => x.FCs).ToList(); //Выборка дисциплин на выбранном в combobox преподавателе
            foreach (string teach in teachQuery)
                teacher.Items.Add(teach);
        }

        /// <summary>
        /// Выводим данные из datagrid в Excel документ-таблицу
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
            workSheet.Cells[1, 1] = teacher.Text == "Все"? "Все дисциплины": "Дисциплины факультета " + teacher.Text; //Подсчитываем общее кол-во дисциплин, информацию берем из combobox
            workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, Data.Columns.Count]].Merge();

            for (int i = 1; i <= Data.Columns.Count; i++)
                workSheet.Cells[3, i] = Data.Columns[i - 1].Header;

            dynamic itemsSource = Data.ItemsSource; //Источник данных - datagrid

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

            //Подсчитываем кол-во дисциплин, которые выводим в данный момент из datagrid в таблицу Excel
            workSheet.Cells[itemsSource.Count + 5, 1] = teacher.Text == "Все" ? "Всего дисциплин: " +itemsSource.Count.ToString() : "Дисциплины данного преподавателя " + teacher.Text + ": " + itemsSource.Count.ToString();

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
        /// Выбираем преподавателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void teacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedItem as string;
            var ed = dbContext.Teachers.FirstOrDefault(x => x.FCs == text);
            if (ed == null) //Если преподаватель не выбран, то берем все дисциплины
            {
                var query = dbContext.Disciplines.Select(x => new
                {
                    x.id_discipline,
                    x.title_discipline,
                    FCs = x.Teachers.FCs,
                    Email = x.Teachers.E_Mail,
                    x.quantity_of_hours

                }).ToList();

                Data.ItemsSource = query;
            }
            else //Иначе берем дисциплины по выбранному преподавателю
            {
                var query = ed.Disciplines.Select(x => new
                {
                    x.id_discipline,
                    x.title_discipline,
                    FCs = x.Teachers.FCs,
                    Email = x.Teachers.E_Mail,
                    x.quantity_of_hours

                }).ToList();

                Data.ItemsSource = query;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            teacher.SelectionChanged += teacher_SelectionChanged;
        }
    }
}
