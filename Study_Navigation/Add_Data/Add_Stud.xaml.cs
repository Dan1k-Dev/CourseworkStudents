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
using Study_Navigation.Classes;

namespace Study_Navigation.Add_Data
{
    /// <summary>
    /// Логика взаимодействия для Add_Stud.xaml
    /// </summary>
    public partial class Add_Stud : Window
    {
        MyDbContext context = new MyDbContext();
        public Add_Stud()
        {
            InitializeComponent();

            ComboBoxItem all1 = new ComboBoxItem();
            all1.Content = "Все";
            all1.IsSelected = true;

            groups.Items.Add(all1);
            var grQuery = context.Groups.Select(x => x.Title_group).ToList(); //Выборка дисциплин на выбранном в combobox преподавателе
            foreach (string groupss in grQuery)
                groups.Items.Add(groupss);
        }

        private void Name_stud_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Name_stud.Text = "";
        }

        private void address_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            address.Text = "";
        }

        private void teleph_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            teleph.Text = "";
        }

        private void add_stud_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var query = new Student()
                {
                    FCs = Name_stud.Text,
                    numb_of_gradebook = int.Parse(grade.Text),
                    date_of_born = born.Text,
                    address = address.Text,
                    telephone = teleph.Text,
                    Groups = context.Groups.First(x => x.Title_group == groups.Text),
                    fluorography = flu.Text
                };
                context.Students.Add(query);
                context.SaveChanges();

                var Journaluser = context.journal_firsts.Select(x => x.username).FirstOrDefault();

                var StduAdd = new Classes.Journal_Interactions() //Добавление данных о добавлении пользователем нового студента
                {
                    username = Journaluser.ToString(),
                    date = DateTime.Now.ToString(),
                    status = "Добавление данных в таблицу Students"
                };
                context.journal_s.Add(StduAdd);
                context.SaveChanges();

                ExcelAdd();

                MessageBox.Show("Студент успешно добавлен!");
            }
            catch
            {
                MessageBox.Show("Данные заполнены не верно или полностью");
            }
        }

        private void not_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void grade_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            grade.Text = "";
        }
    }
}
