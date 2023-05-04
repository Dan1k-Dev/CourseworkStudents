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
    /// Логика взаимодействия для Add_fac.xaml
    /// </summary>
    public partial class Add_fac : Window
    {
        MyDbContext DbContext = new MyDbContext();
        public Add_fac()
        {
            InitializeComponent();

            ComboBoxItem all = new ComboBoxItem();
            all.Content = "Все";
            all.IsSelected = true;

            forms.Items.Add(all);
            var formsQuery = DbContext.Form_Of_s.Select(x => x.title_form).ToList(); //Выборка дисциплин на выбранном в combobox преподавателе
            foreach (string form in formsQuery)
                forms.Items.Add(form);

            ComboBoxItem all2 = new ComboBoxItem();
            all2.Content = "Все";
            all2.IsSelected = true;

            specL.Items.Add(all2);
            var specQuery = DbContext.Specializations.Select(x => x.title_specialization).ToList(); //Выборка дисциплин на выбранном в combobox преподавателе
            foreach (string spec in specQuery)
                specL.Items.Add(spec);
        }

        private void Name_fac_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Name_fac.Text = "";
        }

        private void add_fac_Click(object sender, RoutedEventArgs e)
        {
            if (Name_fac.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Данные введены не верно");
            }
            else
            {
                var query = new Educational_Program()
                {
                    title_program = Name_fac.Text,
                    head_department = zav.Text,
                    Form_Of_ = DbContext.Form_Of_s.First(x => x.title_form == forms.Text),
                    Specialization = DbContext.Specializations.First(x => x.title_specialization == specL.Text)

            };
            DbContext.Educational_s.Add(query);
            DbContext.SaveChanges();

                var Journaluser = DbContext.journal_firsts.Select(x => x.username).FirstOrDefault();

                var facAdd = new Classes.Journal_Interactions() //Добавление данных о добавлении пользователем новой образовательной программы
                {
                    username = Journaluser.ToString(),
                    date = DateTime.Now.ToString(),
                    status = "Добавление данных в таблицу Educational_Program"
                };
                DbContext.journal_s.Add(facAdd);
                DbContext.SaveChanges();

                ExcelAdd();

                MessageBox.Show("Образовательная программа успешно добавлена!");
                
        }
    }

        private void not_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void zav_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            zav.Text = "";
        }

        void ExcelAdd()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(@"C:\Users\itsfo\Desktop\Study_Navigation\Study_Navigation\Журналы2.xlsx");

            Excel.Worksheet workSheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);

            List<Journal_Interactions> nasvay = DbContext.journal_s.Where(x => x.id != 0).ToList();
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
