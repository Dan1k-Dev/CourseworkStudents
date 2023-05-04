using Study_Navigation.Classes;
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
using System.IO;

namespace Study_Navigation.Reports
{
    /// <summary>
    /// Логика взаимодействия для Perf_StudAndGroups.xaml
    /// </summary>
    public partial class Perf_StudAndGroups : Window
    {
        MyDbContext dbContext = new MyDbContext();
        public Perf_StudAndGroups()
        {
            InitializeComponent();

            ComboBoxItem all = new ComboBoxItem();
            all.Content = "Все";
            all.IsSelected = true;

            Stud.Items.Add(all); //Отображаем все образовательные программы в datagrid
            var query = dbContext.Student_s.Select(x => new
            {
                x.id_progress,
                student = x.Student.FCs,
                discipline = x.Discipline.title_discipline,
                x.estimation           

            }).ToList();

            Data.ItemsSource = query;

            var studyQuery = dbContext.Students.Select(x => x.FCs).ToList();
            foreach (string study in studyQuery)
                Stud.Items.Add(study);
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Pages.Administrator administrator = new Pages.Administrator();
            administrator.Show();
            this.Close();
        }

        /// <summary>
        /// Добавление информации о успеваемости студентов/групп в лист Excel
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
            workSheet.Cells[1, 1] = Stud.Text == "Успеваемость" ? "Вся успеваемость " : "Успеваемость " + Stud.Text; //Вычисляем выбранную форму обучения
            workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, Data.Columns.Count]].Merge();

            for (int i = 1; i <= Data.Columns.Count; i++)
                workSheet.Cells[3, i] = Data.Columns[i - 1].Header;

            dynamic itemsSource = Data.ItemsSource;//Берем данные из datagrid

            List<string> headers = new List<string>();
            foreach (DataGridTextColumn c in Data.Columns)
                headers.Add((c.Binding as Binding).Path.Path);

            if (Stud.Text == "Все")
            {
                for (int i = 0; i < Data.Items.Count; i++)
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
                workSheet.Cells[itemsSource.Count + 5, 1] = Stud.Text == "Все" ? "Всего дисциплин: " + itemsSource.Count.ToString() : "Дисциплины данного преподавателя " + Stud.Text + ": " + itemsSource.Count.ToString();
            }
            else
            {
                for (int i = 0; i < Data.Items.Count; i++)
                {
                    for (int j = 0; j < headers.Count; j++)
                    {
                        //string cellContent = " " + itemsSource[i].GetType().GetProperty(headers[j]).GetValue(itemsSource[i], null).ToString();
                        string cellContent = ((TextBlock)Data.Columns[j].GetCellContent(Data.Items[i])).Text;
                        workSheet.Cells[i + 4, j + 1] = cellContent;
                    }
                }

                workSheet.Range[workSheet.Columns[1], workSheet.Columns[Data.Columns.Count]].AutoFit();
                workSheet.Range[workSheet.Cells[Data.Items.Count + 5, 1], workSheet.Cells[Data.Items.Count + 5, Data.Columns.Count + 1]].Merge();

                //Подсчитываем кол-во дисциплин, которые выводим в данный момент из datagrid в таблицу Excel
                workSheet.Cells[Data.Items.Count + 5, 1] = Stud.Text == "Все" ? "Всего дисциплин: " + Data.Items.Count.ToString() : "Всего студентов по дисциплине";
            }
            excelApp.Visible = true;
            excelApp.DisplayAlerts = false;
        }

        private void Student_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedItem as string;

            var ed = dbContext.Students.FirstOrDefault(x => x.FCs == text);

            if (ed == null) //Если студент не выбран, то отбражаем сообщение с ошибкой
            {
                var query = new MyDbContext().Student_s.Select(x => new
                {
                    x.id_progress,
                    student = x.Student.FCs,
                    discipline = x.Discipline.title_discipline,
                    x.estimation

                }).ToList();

                Data.ItemsSource = query;
            }
            else //Иначе отображаем информацию о выбранном студенте
            {
                var query = dbContext.Student_s.ToList().Select(x => new
                {
                    x.id_progress,
                    student = x.Student.FCs,
                    discipline = x.Discipline.title_discipline,
                    x.estimation

                }).ToList().Where(x => x.student == ed.FCs);

                Data.ItemsSource = query;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Stud.SelectionChanged += Student_SelectionChanged;
        }

        private void Add_data_Click(object sender, RoutedEventArgs e)
        {
            Add_Data.Add_perf add_Perf = new Add_Data.Add_perf();
            add_Perf.Show();
        }

        private void Edit_data_Click(object sender, RoutedEventArgs e)
        {
            if (Data.SelectedItem == null)
            {
                MessageBox.Show("Ни один студент не выбран");
                return;
            }
            else
            {
                dynamic perf = Data.SelectedItem;
                int perfId = perf.id_progress;
                var perff = dbContext.Student_s.Find(perfId);
                dbContext.Student_s.Remove(perff);
                dbContext.SaveChanges();

                var Journaluser = dbContext.journal_firsts.Select(x => x.username).FirstOrDefault();

                var deletePerf = new Classes.Journal_Interactions()
                {
                    username = Journaluser.ToString(),
                    date = DateTime.Now.ToString(),
                    status = "Удаление данных из таблицы Student_Progress"
                };
                dbContext.journal_s.Add(deletePerf);
                dbContext.SaveChanges();

                Excel();

                MessageBox.Show("Сведения об успеваемости успешно удалены!");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var query = dbContext.Student_s.Select(x => new
            {
                x.id_progress,
                student = x.Student.FCs,
                discipline = x.Discipline.title_discipline,
                x.estimation

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
