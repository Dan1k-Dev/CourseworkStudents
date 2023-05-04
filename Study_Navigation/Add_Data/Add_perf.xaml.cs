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
    /// Логика взаимодействия для Add_perf.xaml
    /// </summary>
    public partial class Add_perf : Window
    {
        MyDbContext dbContext = new MyDbContext();
        public Add_perf()
        {
            InitializeComponent();

            ComboBoxItem all = new ComboBoxItem();
            all.Content = "Все";
            all.IsSelected = true;

            Studs.Items.Add(all);
            var studsQuery = dbContext.Students.Select(x => x.FCs).ToList(); //Выборка дисциплин на выбранном в combobox преподавателе
            foreach (string stud in studsQuery)
                Studs.Items.Add(stud);

            ComboBoxItem all2 = new ComboBoxItem();
            all2.Content = "Все";
            all2.IsSelected = true;

            disc.Items.Add(all2);
            var discQuery = dbContext.Disciplines.Select(x => x.title_discipline).ToList(); //Выборка дисциплин на выбранном в combobox преподавателе
            foreach (string discs in discQuery)
                disc.Items.Add(discs);
        }

        private void add_perf_Click(object sender, RoutedEventArgs e)
        {
            if (Studs.SelectedItem == null || Studs.Text == "Все")
            {
                MessageBox.Show("Данные введены не верно");
            }
            else
            {
                var query1 = new Student_Progress()
                {
                    Student = dbContext.Students.First(x => x.FCs == Studs.Text),
                    Discipline = dbContext.Disciplines.First(x => x.title_discipline == disc.Text),
                    estimation = int.Parse(est.Text),
                };
                dbContext.Student_s.Add(query1);
                dbContext.SaveChanges();

                var Journaluser = dbContext.journal_firsts.Select(x => x.username).FirstOrDefault();

                var perfAdd = new Classes.Journal_Interactions() //Добавление данных о добавлении пользователем новых сведений об успеваемости
                {
                    username = Journaluser.ToString(),
                    date = DateTime.Now.ToString(),
                    status = "Добавление данных в таблицу Student_Progress"
                };
                dbContext.journal_s.Add(perfAdd);
                dbContext.SaveChanges();

                ExcelAdd();

                MessageBox.Show("Информация об успеваемости успешно добавлена!");
            }
        }

        private void not_Click(object sender, RoutedEventArgs e)
        {

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
