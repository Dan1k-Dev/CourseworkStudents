using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;
using System;
using System.Data.Entity;

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
                Pages.TeacherWin teacher = new Pages.TeacherWin();
                teacher.Show();
                this.Close();
            }
            else //Ошибка при неверном вводе данных в поля логина или/и пароля
            {
                AccountIcon.Foreground = Brushes.Red;
                UsernameBorder.Background = Brushes.Red;

                PasswordIcon.Foreground = Brushes.Red;
                PasswordBorder.Background = Brushes.Red;

                ExceptionOfLoginOrPassword.Visibility = Visibility.Visible;
            }
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

