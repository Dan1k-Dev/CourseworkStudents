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

namespace Study_Navigation.Pages
{
    /// <summary>
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Window
    {
        MyDbContext db = new MyDbContext();

        public Administrator()
        {
            InitializeComponent();
        }

        private void Specialize_Click(object sender, RoutedEventArgs e)
        {
            Reports.Specialize specialize = new Reports.Specialize();
            specialize.Show();
            this.Close();
        }

        private void Disciplines_Click(object sender, RoutedEventArgs e)
        {
            Reports.Discipline_adm disciplines = new Reports.Discipline_adm();
            disciplines.Show();
            this.Close();
        }

        private void Facultets_Click(object sender, RoutedEventArgs e)
        {
            Reports.Facultet_adm facultets = new Reports.Facultet_adm();
            facultets.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ExitJournal();
            ExcelAdd();

            MainWindow autorization = new MainWindow();
            autorization.Show();
            this.Close();
        }

        void ExitJournal()
        {
            int idUser = db.journal_firsts.Max(x => x.id) + 1;
            var Journaluser = db.journal_firsts.Select(x => x.username).FirstOrDefault().ToString();
            var journal = db.journal_firsts.Where(x => x.username == Journaluser).OrderBy(x => x.id == idUser).FirstOrDefault().ToString();

            var dataExit = new Journal_Enter_Exit()
            {
                username = journal,
                date = DateTime.Now.ToString(),
                status = "Пользователь вышел из системы"
            };
            db.journal_firsts.Add(dataExit);
            db.SaveChanges();
        }

        void ExcelAdd()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(@"C:\Users\itsfo\Desktop\Study_Navigation\Study_Navigation\Журналы.xlsx");

            Excel.Worksheet workSheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);

            List<Journal_Enter_Exit> nasvay = db.journal_firsts.Where(x => x.id != 0).ToList();
            var ot1 = nasvay.Select(x => new
            {
                id = x.id,
                Login = x.username,
                TimeEnter = x.date,
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

        private void Attend_Stud_Click(object sender, RoutedEventArgs e)
        {
            Reports.AttendStud_adm attend_adm = new Reports.AttendStud_adm();
            attend_adm.Show();
            this.Close();
        }

        private void Perf_Stud_Click(object sender, RoutedEventArgs e)
        {
            Reports.Perf_StudAndGroups perf_adm = new Reports.Perf_StudAndGroups();
            perf_adm.Show();
            this.Close();
        }

        private void GroupsData_Click(object sender, RoutedEventArgs e)
        {
            Reports.Groups_adm groups_Adm = new Reports.Groups_adm();
            groups_Adm.Show();
            this.Close();
        }

        private void StudentsData_Click(object sender, RoutedEventArgs e)
        {
            Reports.Students_adm students_Adm = new Reports.Students_adm();
            students_Adm.Show();
            this.Close();
        }   
    }
}
