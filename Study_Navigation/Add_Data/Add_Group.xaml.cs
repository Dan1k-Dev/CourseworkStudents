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
using Study_Navigation.Classes;

namespace Study_Navigation.Add_Data
{
    /// <summary>
    /// Логика взаимодействия для Add_Group.xaml
    /// </summary>
    public partial class Add_Group : Window
    {
        MyDbContext dbContext = new MyDbContext();
        public Add_Group()
        {
            InitializeComponent();

            ComboBoxItem all = new ComboBoxItem();
            all.Content = "Все";
            all.IsSelected = true;

            teacherss.Items.Add(all);
            var formsQuery = dbContext.Teachers.Select(x => x.FCs).ToList(); //Выборка дисциплин на выбранном в combobox преподавателе
            foreach (string form in formsQuery)
                teacherss.Items.Add(form);
        }

        private void Name_group_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Name_group.Text = "";
        }

        private void elder_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            elder.Text = "";
        }

        private void add_group_Click(object sender, RoutedEventArgs e)
        {
            if (Name_group.Text.Any(char.IsLetter) && elder.Text.Any(char.IsLetter) && year.Text.Any(char.IsDigit))
            {
                var query = new Group()
                {
                    Title_group = Name_group.Text,
                    Elder_of_group = elder.Text,
                    Teacher = dbContext.Teachers.First(x => x.FCs == teacherss.Text),
                    Year_of_recruitment = year.Text
                };
                dbContext.Groups.Add(query);
                dbContext.SaveChanges();

                var Journaluser = dbContext.journal_firsts.Select(x => x.username).FirstOrDefault();

                var groupAdd = new Classes.Journal_Interactions() //Добавление данных о добавлении пользователем новой группы
                {
                    username = Journaluser.ToString(),
                    date = DateTime.Now.ToString(),
                    status = "Добавление данных в таблицу Groups"
                };
                dbContext.journal_s.Add(groupAdd);
                dbContext.SaveChanges();

                ExcelAdd();

                MessageBox.Show("Группа успешно добавлена!");
            }
            else
            {
                MessageBox.Show("Ошибка! Данные введены не полностью или не верно");
            }
        }

        private void nott_Click(object sender, RoutedEventArgs e)
        {

        }

        private void year_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            year.Text = "";
        }

        void ExcelAdd()
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
