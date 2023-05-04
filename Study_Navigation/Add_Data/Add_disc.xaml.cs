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

namespace Study_Navigation.Add_Data
{
    /// <summary>
    /// Логика взаимодействия для Add_disc.xaml
    /// </summary>
    public partial class Add_disc : Window
    {
        MyDbContext myDb = new MyDbContext();
        public Add_disc()
        {
            InitializeComponent();

            ComboBoxItem all = new ComboBoxItem();
            all.Content = "Все";
            all.IsSelected = true;

            Teach.Items.Add(all);
            var teachQuery = myDb.Teachers.Select(x => x.FCs).ToList(); //Выборка дисциплин на выбранном в combobox преподавателе
            foreach (string teach in teachQuery)
                Teach.Items.Add(teach);
        }

        private void Name_disc_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Name_disc.Text = "";
        }

        private void Kolvo_hours_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Kolvo_hours.Text = "";
        }

        private void add_teach_Click(object sender, RoutedEventArgs e)
        {
            if (Name_disc.Text != "Название дисциплины" && Kolvo_hours.Text != "Количество часов по дисциплине")
            {
                try
                {
                    if (Name_disc.Text.Length != 0 && Kolvo_hours.Text.Length != 0 && Kolvo_hours.Text.Length >= 2)
                    {
                        var query = new Disciplines()
                        {
                            title_discipline = Name_disc.Text,
                            quantity_of_hours = int.Parse(Kolvo_hours.Text),
                            Teachers = myDb.Teachers.First(x => x.FCs == Teach.Text)
                        };
                        myDb.Disciplines.Add(query);
                        myDb.SaveChanges();

                        var Journaluser = myDb.journal_firsts.Select(x => x.username).FirstOrDefault();

                        var discAdd = new Classes.Journal_Interactions() //Добавление данных о добавлении пользователем новой дисциплины
                        {
                            username = Journaluser.ToString(),
                            date = DateTime.Now.ToString(),
                            status = "Добавление данных в таблицу Disciplines"
                        };
                        myDb.journal_s.Add(discAdd);
                        myDb.SaveChanges();

                        ExcelAdd();

                        MessageBox.Show("Дисциплина успешно добавлена!");
                    }
                    else
                        MessageBox.Show("Данные заполнены не верно или полностью");
                }
                catch
                {
                    MessageBox.Show("Данные заполнены не верно или полностью");
                }
            }
        }

        private void not_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Teach.SelectionChanged += Teach_SelectionChanged;
        }

        private void Teach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedItem as string;
            var ed = myDb.Disciplines.FirstOrDefault(x => x.title_discipline == text);
        }

        void ExcelAdd()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(@"C:\Users\itsfo\Desktop\Study_Navigation\Study_Navigation\Журналы2.xlsx");

            Excel.Worksheet workSheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);

            List<Journal_Interactions> nasvay = myDb.journal_s.Where(x => x.id != 0).ToList();
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
