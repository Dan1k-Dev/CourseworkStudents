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
using System.Data;
using System.IO;
using Study_Navigation.Classes;

namespace Study_Navigation.Reports
{
    /// <summary>
    /// Логика взаимодействия для Disciplines.xaml
    /// </summary>
    public partial class Discipline_adm : Window
    {
        MyDbContext dbContext = new MyDbContext();
        
        /// <summary>
        /// Заполняем данными datagrid - дисциплины, факультеты
        /// При запуске приложения
        /// </summary>
        public Discipline_adm()
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
            Pages.Administrator administrator = new Pages.Administrator();
            administrator.Show();
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

        private void Add_data_Click(object sender, RoutedEventArgs e)
        {
            Add_Data.Add_disc add_Disc = new Add_Data.Add_disc();
            add_Disc.Show();
        }

        private void Delete_Data_Click(object sender, RoutedEventArgs e)
        {
            if (Data.SelectedItem == null)
            {
                MessageBox.Show("Ни одна дисциплина не выбрана");
                return;
            }
            else
            {
                dynamic disc = Data.SelectedItem;
                int discId = disc.id_discipline;
                var discc = dbContext.Disciplines.Find(discId);
                dbContext.Disciplines.Remove(discc);
                dbContext.SaveChanges();

                var Journaluser = dbContext.journal_firsts.Select(x => x.username).FirstOrDefault();

                var deleteDisc = new Classes.Journal_Interactions()
                {
                    username = Journaluser.ToString(),
                    date = DateTime.Now.ToString(),
                    status = "Удаление данных из таблицы Disciplines"
                };
                dbContext.journal_s.Add(deleteDisc);
                dbContext.SaveChanges();

                Excel();

                MessageBox.Show("Сведения о дисциплине успешно удалены!");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
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

        void Excel()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(@"C:\Users\itsfo\Desktop\Study_Navigation\Study_Navigation\Журналы2.xlsx");

            Excel.Worksheet workSheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);

            List<Journal_Interactions> nasvay = dbContext.journal_s.Where(x => x.id != 0).ToList();
            var ot1 = nasvay.Select(x => new
            {
                id = x.id,
                Login = x.username,
                TimeEnter = DateTime.Now.ToString(),
                Status = x.status

            }).ToList();

            int row = 4;
            while ((workSheet.Cells[row, 1] as Excel.Range).Value != null) row++;

            string[] propertys = new string[4] { "id", "Login", "TimeEnter", "Status" };
            for (int i = 0; i < ot1.Count; i++)
            {
                for (int j = 0; j < propertys.Length; j++)
                {

                    workSheet.Cells[i + 3, j + 1] = ot1[i].GetType().GetProperty(propertys[j]).GetValue(ot1[i], null).ToString();

                }
            }
            excelApp.Visible = true;
            excelApp.DisplayAlerts = false;
            workbook.Save();
            excelApp.Quit();
        }
    }
}
