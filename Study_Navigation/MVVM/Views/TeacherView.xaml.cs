using Study_Navigation.MVVM.ViewModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Study_Navigation.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для TeacherView.xaml
    /// </summary>
    public partial class TeacherView : UserControl
    {
        public TeacherView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Открываем окно со сведениями о группах
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGroup_Click(object sender, RoutedEventArgs e)
        {
            Reports.DataGroups dataGroups = new Reports.DataGroups();

            Window.GetWindow(this).Close();
            dataGroups.Show();
        }

        /// <summary>
        /// Открываем окно со сведениями о студентах
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataStudents_Click(object sender, RoutedEventArgs e)
        {      
            Reports.DataStudents dataStudents = new Reports.DataStudents();

            Window.GetWindow(this).Close();
            dataStudents.Show();
        }

        /// <summary>
        /// Открываем окно с посещаемостью групп и стдуентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Attend_StudAndGroups_Click(object sender, RoutedEventArgs e)
        {
            Reports.Attend_StudAndGroups attend = new Reports.Attend_StudAndGroups();

            Window.GetWindow(this).Close();
            attend.Show();
        }

        /// <summary>
        /// Открываем окно с успеваемостью групп и студентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Perf_StudAndGroups_Click(object sender, RoutedEventArgs e)
        {
            Reports.PerfStud_adm perf = new Reports.PerfStud_adm();           

            Window.GetWindow(this).Close();
            perf.Show();
        }
    }
}
