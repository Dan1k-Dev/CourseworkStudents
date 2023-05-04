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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Study_Navigation.Add_Data
{
    /// <summary>
    /// Логика взаимодействия для Add_Attend.xaml
    /// </summary>
    public partial class Add_Attend : Window
    {
        MyDbContext context = new MyDbContext();

        public Add_Attend()
        {
            InitializeComponent();

            ComboBoxItem all = new ComboBoxItem();
            all.Content = "Все";
            all.IsSelected = true;

            Stud.Items.Add(all);
            var studQuery = context.Students.Select(x => x.FCs).ToList(); //Выборка дисциплин на выбранном в combobox преподавателе
            foreach (string stud in studQuery)
                Stud.Items.Add(stud);
        }

        private void add_teach_Click(object sender, RoutedEventArgs e)
        {
            if (Stud.Text != "Все" && GR_Hours.Text != "" && nGR_Hours.Text != "" && date.Text != "")
            {
                try
                {
                    var query = new Attendance_Student()
                    {
                        _Student = context.Students.First(x => x.FCs == Stud.Text),
                        quantity_of_hours_GR = int.Parse(GR_Hours.Text),
                        quantity_of_hours_nGR = int.Parse(nGR_Hours.Text),
                        date = date.Text,
                        General_quantity_of_hours = int.Parse(GR_Hours.Text) + int.Parse(nGR_Hours.Text)
                    };
                    context.Attendances.Add(query);
                    context.SaveChanges();

                    var Journaluser = context.journal_firsts.Select(x => x.username).FirstOrDefault();

                    var attendAdd = new Classes.Journal_Interactions() //Добавление данных о добавлении пользователем новых данных о посещаемости
                    {
                        username = Journaluser.ToString(),
                        date = DateTime.Now.ToString(),
                        status = "Добавление данных в таблицу Attendance_Student"
                    };
                    context.journal_s.Add(attendAdd);
                    context.SaveChanges();

                    ExcelAdd();

                    MessageBox.Show("Дисциплина успешно добавлена!");
                }
                catch
                {
                    MessageBox.Show("Данные заполнены не верно или полностью");
                }
            }
            else
                MessageBox.Show("Данные заполнены не верно или полностью");
        }

        private void not_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Stud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //useless
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Stud.SelectionChanged += Stud_SelectionChanged;
        }

        private void date_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            date.Text = "";
        }

        void ExcelAdd()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(@"C:\Users\itsfo\Desktop\Study_Navigation\Study_Navigation\Журналы2.xlsx");

            Excel.Worksheet workSheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);

            List<Journal_Interactions> nasvay = context.journal_s.Where(x => x.id != 0).ToList();
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
