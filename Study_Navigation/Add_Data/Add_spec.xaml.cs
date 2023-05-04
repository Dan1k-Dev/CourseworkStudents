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
    /// Логика взаимодействия для Add_spec.xaml
    /// </summary>
    public partial class Add_spec : Window
    {
        MyDbContext dbContext = new MyDbContext();
        public Add_spec()
        {
            InitializeComponent();
        }

        private void Name_spec_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Name_spec.Text = "";
        }

        private void not_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void add_teach_Click(object sender, RoutedEventArgs e)
        {
            if (Name_spec.Text.Any(char.IsDigit))
                MessageBox.Show("Данные введены не верно");
            else
            {
                var query = new Specialization()
                {
                    title_specialization = Name_spec.Text
                };
                dbContext.Specializations.Add(query);
                dbContext.SaveChanges();

                var Journaluser = dbContext.journal_firsts.Select(x => x.username).FirstOrDefault();

                var specAdd = new Classes.Journal_Interactions() //Добавление данных о добавлении новой специальности пользователем
                {
                    username = Journaluser.ToString(),
                    date = DateTime.Now.ToString(),
                    status = "Добавление данных в таблицу Specializations"
                };
                dbContext.journal_s.Add(specAdd);
                dbContext.SaveChanges();

                ExcelAdd();

                MessageBox.Show("Специальность успешно добавлена!");
            }
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
