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

namespace Study_Navigation.Reports
{
    /// <summary>
    /// Логика взаимодействия для Specialize.xaml
    /// </summary>
    public partial class Specializes_adm : Window
    {
        MyDbContext dbContext = new MyDbContext();
        public Specializes_adm()
        {
            InitializeComponent();

            var query = dbContext.Specializations.Select(x => new
            {
                x.id_specializtion,
                x.title_specialization

            }).ToList();

            Data.ItemsSource = query;
        }

        private void ExcelAdd_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            excelApp.SheetsInNewWorkbook = 1;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);

            workSheet.Name = "Отчёт";
           // workSheet.Cells[1, 1] = all ? "Все дисциплины" : "Дисциплины факультета ";
            workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, Data.Columns.Count]].Merge();

            for (int i = 1; i <= Data.Columns.Count; i++)
                workSheet.Cells[3, i] = Data.Columns[i - 1].Header;

            dynamic itemsSource = Data.ItemsSource;

            List<string> headers = new List<string>();
            foreach (DataGridTextColumn c in Data.Columns)
                headers.Add((c.Binding as Binding).Path.Path);

            for (int i = 0; i < itemsSource.Count; i++)
            {
                for (int j = 0; j < headers.Count; j++)
                {
                    string cellContent = " " + itemsSource[i].GetType().GetProperty(headers[j]).GetValue(itemsSource[i], null).ToString();
                    workSheet.Cells[i + 4, j + 1] = cellContent;
                }
            }

            workSheet.Range[workSheet.Columns[1], workSheet.Columns[Data.Columns.Count]].AutoFit();
            workSheet.Range[workSheet.Cells[itemsSource.Count + 5, 1], workSheet.Cells[itemsSource.Count + 5, Data.Columns.Count + 1]].Merge();

            workSheet.Cells[itemsSource.Count + 5, 1] = "Всего специальностей: " + itemsSource.Count.ToString();

            excelApp.Visible = true;
            excelApp.DisplayAlerts = false;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Pages.TeacherWin teacherWin = new Pages.TeacherWin();
            teacherWin.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //useless
        }
    }
}
