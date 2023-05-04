using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;
using System;
using System.Data.Entity;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Study_Navigation.Classes;
using System.Collections.Generic;

namespace Study_Navigation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyDbContext db = new MyDbContext(); //Инициализируем контекст базы данных

        public MainWindow()
        {
            InitializeComponent();

            //var query = new Classes.Journal_Enter_Exit()
            //{
            //    username = "asdas",
            //    date = "24.11.2003",
            //    status = "asd"
            //};
            //db.journal_firsts.Add(query);
            //db.SaveChanges();
        }

        /// <summary>
        /// Возможность перетаскивать окно по рабочему столу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        /// <summary>
        /// Авторизироваться в системе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            //Привязываем значения из введенных пользователем данных (логин и пароль)
            //К запросам на поиск пользователя в системе 
            var userlogin = usernameTb.Text;
            var dataloginuser = db.Users.Where(f => f.Login == userlogin).FirstOrDefault();

            var userpassw = passwordTb.Password;
            var datapasswuser = db.Users.Where(t => t.Password == userpassw).FirstOrDefault();

            if (dataloginuser != null && datapasswuser != null && usernameTb.Text == dataloginuser.Login && passwordTb.Password == datapasswuser.Password) //Проверяем пользователя на его существование
            {
                if (dataloginuser.Access_rights == 2)
                {
                    var dataEnterTeach = new Journal_Enter_Exit() //Добавление в журнал данных о входе пользователя
                    {
                        username = userlogin.ToString(),
                        date = DateTime.Now.ToString(),
                        status = "Пользователь вошел в систему"
                    };
                    db.journal_firsts.Add(dataEnterTeach);
                    db.SaveChanges();

                    ExcelAdd();

                    Teacher_Right();
                }
                else if (dataloginuser.Access_rights == 1)
                {
                    var dataEnterAdm = new Journal_Enter_Exit() //Добавление в журнал данных о входе пользователя
                    {
                        username = userlogin.ToString(),
                        date = DateTime.Now.ToString(),
                        status = "Пользователь вошел в систему" 
                    };
                    db.journal_firsts.Add(dataEnterAdm);
                    db.SaveChanges();

                    ExcelAdd();

                    Admin_Right();
                }
            }
            else //Ошибка при неверном вводе данных в поля логина или/и пароля
            {
                Error_Data();
            }
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

        void Admin_Right()
        {
            Pages.Administrator admin = new Pages.Administrator();
            admin.Show();
            this.Close();
        }

        void Teacher_Right()
        {
            Pages.TeacherWin teacher = new Pages.TeacherWin();
            teacher.Show();
            this.Close();
        }

        void Error_Data()
        {
            AccountIcon.Foreground = Brushes.Red;
            UsernameBorder.Background = Brushes.Red;

            PasswordIcon.Foreground = Brushes.Red;
            PasswordBorder.Background = Brushes.Red;

            ExceptionOfLoginOrPassword.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Функциональность строки пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordTb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (passwordTb.Password == "Пароль")
            {
                passwordTb.Password = "";

                PasswordIcon.Foreground = Brushes.Black;
                PasswordBorder.Background = Brushes.Black;

                ExceptionOfLoginOrPassword.Visibility = Visibility.Hidden;
            }
            else
            {
                passwordTb.Password = passwordTb.Password;

                PasswordIcon.Foreground = Brushes.Black;
                PasswordBorder.Background = Brushes.Black;

                ExceptionOfLoginOrPassword.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Функциональность строки логина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usernameTb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (usernameTb.Text == "Логин")
            {
                usernameTb.Text = "";
                AccountIcon.Foreground = Brushes.Black;
                UsernameBorder.Background = Brushes.Black;

                ExceptionOfLoginOrPassword.Visibility = Visibility.Hidden;
            }
            else
            {
                usernameTb.Text = usernameTb.Text;
                AccountIcon.Foreground = Brushes.Black;
                UsernameBorder.Background = Brushes.Black;

                ExceptionOfLoginOrPassword.Visibility = Visibility.Hidden;
            }            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pages.Registration registration = new Pages.Registration();
            registration.Show();
            this.Close();
        }
    }
}