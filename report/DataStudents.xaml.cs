using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для DataStudents.xaml
    /// </summary>
    public partial class DataStudents : Window
    {
        MyDbContext dbContext = new MyDbContext();
        public string title { get; set; }
        public string resultTitle;

        Dictionary<string, string> headers;

        /// <summary>
        /// Добавляем значения из таблицы Студенты в combobox
        /// Инициализируем вывод данных из datagrid в excel
        /// Доабвляем данные из таблицы Студенты в datagrid
        /// </summary>
        /// <param name="title"></param>
        /// <param name="resultTitle"></param>
        /// <param name="headers"></param>
        public DataStudents()
        {
            InitializeComponent();

            var studQuery = dbContext.Students.Select(x => x.FCs).ToList();
            foreach (string stud in studQuery)
                Student.Items.Add(stud);
        }

        /// <summary>
        /// Выход на главную
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Pages.TeacherWin teacherWin = new Pages.TeacherWin();
            teacherWin.Show();
            this.Close();
        }

        /// <summary>
        /// Открываем файл excel с данными из datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExcelAdd_Click(object sender, RoutedEventArgs e)
        {
           
        }

        /// <summary>
        /// Обновляем datagrid с осуществлением поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
