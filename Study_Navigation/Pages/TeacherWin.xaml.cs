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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Study_Navigation.Pages
{
    /// <summary>
    /// Логика взаимодействия для TeacherWin.xaml
    /// </summary>
    public partial class TeacherWin : Window
    {
        MyDbContext context = new MyDbContext();

        public TeacherWin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Выход из основного окна приложения
        /// В окно ваториазции пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            int idUser = context.journal_firsts.Max(x => x.id) + 1;
            var Journaluser = context.journal_firsts.Select(x => x.username).FirstOrDefault().ToString();
            var journal = context.journal_firsts.Where(x => x.username == Journaluser).OrderBy(x => x.id == idUser).FirstOrDefault().ToString();

            var dataExit = new Journal_Enter_Exit()
            {
                username = journal,
                date = DateTime.Now.ToString(),
                status = "Пользователь вышел из системы"
            };
            context.journal_firsts.Add(dataExit);
            context.SaveChanges();
        }

        void ExcelAdd()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(@"C:\Users\itsfo\Desktop\Study_Navigation\Study_Navigation\Журналы.xlsx");

            Excel.Worksheet workSheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);

            List<Journal_Enter_Exit> nasvay = context.journal_firsts.Where(x => x.id != 0).ToList();
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

        private void Specialize_Click(object sender, RoutedEventArgs e)
        {
            Reports.Specializes_adm specialize = new Reports.Specializes_adm();
            specialize.Show();
            this.Close();
        }

        private void Disciplines_Click(object sender, RoutedEventArgs e)
        {
            Reports.Disciplines disciplines = new Reports.Disciplines();
            disciplines.Show();
            this.Close();
        }

        private void Facultets_Click(object sender, RoutedEventArgs e)
        {
            Reports.Facultets facultets = new Reports.Facultets();
            facultets.Show();
            this.Close();
        }
    }
}
