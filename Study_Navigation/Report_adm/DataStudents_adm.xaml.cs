using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Study_Navigation.Classes;

namespace Study_Navigation.Reports
{
    /// <summary>
    /// Логика взаимодействия для DataStudents.xaml
    /// </summary>
    public partial class Students_adm : Window
    {
        MyDbContext dbContext = new MyDbContext();

        /// <summary>
        /// Добавляем значения из таблицы Студенты в combobox
        /// Инициализируем вывод данных из datagrid в excel
        /// Доабвляем данные из таблицы Студенты в datagrid
        /// </summary>
        /// <param name="title"></param>
        /// <param name="resultTitle"></param>
        /// <param name="headers"></param>
        public Students_adm()
        {
            InitializeComponent();

            ComboBoxItem all = new ComboBoxItem();
            all.Content = "Все";
            all.IsSelected = true;

            Student.Items.Add(all); //Отображаем все образовательные программы в datagrid
            var query = dbContext.Students.ToList().Select(x => new
            {
                x.id_student,
                x.FCs,
                x.numb_of_gradebook,
                x.date_of_born,
                x.address,
                x.telephone,
                titlee_group = x.Groups.Title_group,
                x.fluorography

            }).ToList();

            Data.ItemsSource = query;

            var studQuery = dbContext.Students.Select(x => x.FCs).ToList();
            foreach (string stud in studQuery)
                Student.Items.Add(stud);
        }

        /// <summary>
        /// Выход на главную
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
        /// Открываем файл excel с данными из datagrid
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
            workSheet.Cells[1, 1] = Student.Text == "Все" ? "Все студенты" : "Студент: " + Student.Text; //Вычисляем выбранную форму обучения
            workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, Data.Columns.Count]].Merge();

            for (int i = 1; i <= Data.Columns.Count; i++)
                workSheet.Cells[3, i] = Data.Columns[i - 1].Header;

            dynamic itemsSource = Data.ItemsSource;//Берем данные из datagrid

            List<string> headers = new List<string>();
            foreach (DataGridTextColumn c in Data.Columns)
                headers.Add((c.Binding as Binding).Path.Path);

            if (Student.Text == "Все")
            {
                for (int i = 0; i < itemsSource.Count; i++)
                {
                    for (int j = 0; j < headers.Count; j++)
                    {
                        string cellContent = " " + itemsSource[i].GetType().GetProperty(headers[j]).GetValue(itemsSource[i], null).ToString();
                        workSheet.Cells[i + 4, j + 1] = cellContent;
                    }
                }
                workSheet.Range[workSheet.Cells[itemsSource.Count + 5, 1], workSheet.Cells[itemsSource.Count + 5, Data.Columns.Count + 1]].Merge();
                workSheet.Cells[itemsSource.Count + 5, 1] = Student.Text == "Все" ? "Выбрано " + itemsSource.Count.ToString() + "студентов" : "Выбран" + Student.Text + " " + itemsSource.Count.ToString() + "студент";
            }
            else
            {
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < headers.Count; j++)
                    {
                        string cellContent = ((TextBlock)Data.Columns[j].GetCellContent(Data.Items[i])).Text; 
                        workSheet.Cells[i + 4, j + 1] = cellContent;
                    }
                }
                workSheet.Range[workSheet.Cells[6, 1], workSheet.Cells[6, Data.Columns.Count + 1]].Merge();
                workSheet.Cells[6, 1] = "Выбран 1 студент";
            }
            workSheet.Range[workSheet.Columns[1], workSheet.Columns[Data.Columns.Count]].AutoFit();        

            //Считаем кол-во всех дисциплин по всем формам обучения/по выбранной форме обучения
            

            excelApp.Visible = true;
            excelApp.DisplayAlerts = false;
        }

        /// <summary>
        /// При первичной загрузке окна с информацией о студентах по логике метода Student_SelectionChanged  
        /// Изначально отображаются все студенты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Student.SelectionChanged += Student_SelectionChanged;
        }

        /// <summary>
        /// Выбор студента в combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Student_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedItem as string;

            var ed = dbContext.Students.FirstOrDefault(x => x.FCs == text);

            if (ed == null) //Если студент не выбран, то отбражаем сообщение с ошибкой
            {
                var query = dbContext.Students.ToList().Select(x => new
                {
                    x.id_student,
                    x.FCs,
                    x.numb_of_gradebook,
                    x.date_of_born,
                    x.address,
                    x.telephone,
                    titlee_group = x.Groups.Title_group,
                    x.fluorography

                }).ToList();
                Data.ItemsSource = query;
            }
            else //Иначе отображаем информацию о выбранном студенте
            {
                var query = dbContext.Students.ToList().Select(x => new
                {
                    x.id_student,
                    x.FCs,
                    x.numb_of_gradebook,
                    x.date_of_born,
                    x.address,
                    x.telephone,
                    titlee_group = x.Groups.Title_group,
                    x.fluorography

                }).ToList().Where(x => x.id_student == ed.id_student);
                Data.ItemsSource = query;
            }
        }

        private void Add_data_Click(object sender, RoutedEventArgs e)
        {
            Add_Data.Add_Stud add_Stud = new Add_Data.Add_Stud();
            add_Stud.Show();
        }

        private void Delete_data_Click(object sender, RoutedEventArgs e)
        {
            if (Data.SelectedItem == null)
            {
                MessageBox.Show("Ни один студент не выбран");
                return;
            }
            else
            {
                dynamic stud = Data.SelectedItem;
                int studId = stud.id_student;
                var studd = dbContext.Students.Find(studId);
                dbContext.Students.Remove(studd);
                dbContext.SaveChanges();

                var Journaluser = dbContext.journal_firsts.Select(x => x.username).FirstOrDefault();

                var deleteStud = new Classes.Journal_Interactions()
                {
                    username = Journaluser.ToString(),
                    date = DateTime.Now.ToString(),
                    status = "Удаление данных из таблицы Students"
                };
                dbContext.journal_s.Add(deleteStud);
                dbContext.SaveChanges();

                Excel();

                MessageBox.Show("Сведения о студенте успешно удалены!");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var query = dbContext.Students.ToList().Select(x => new
            {
                x.id_student,
                x.FCs,
                x.numb_of_gradebook,
                x.date_of_born,
                x.address,
                x.telephone,
                titlee_group = x.Groups.Title_group,
                x.fluorography

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
