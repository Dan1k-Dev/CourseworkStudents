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

namespace Study_Navigation.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        MyDbContext dbContext = new MyDbContext();
        public Registration()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Имя пользователя (ФИО)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userName_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (userName.Text == "Имя пользователя")
            {
                userName.Text = "";

                AccountIcon.Foreground = Brushes.Black;
                UsernameBorder.Background = Brushes.Black;

                PasswordIcon.Foreground = Brushes.Black;
                PasswordBorder.Background = Brushes.Black;

                UserIcon.Foreground = Brushes.Black;
                AccnameBorder.Background = Brushes.Black;

                ExceptionOfLoginOrPassword.Visibility = Visibility.Hidden;
            }
            else
            {
                userName.Text = userName.Text;

                AccountIcon.Foreground = Brushes.Black;
                UsernameBorder.Background = Brushes.Black;

                PasswordIcon.Foreground = Brushes.Black;
                PasswordBorder.Background = Brushes.Black;

                UserIcon.Foreground = Brushes.Black;
                AccnameBorder.Background = Brushes.Black;

                ExceptionOfLoginOrPassword.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordTb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (passwordTb.Text == "Пароль")
            {
                passwordTb.Text = "";

                AccountIcon.Foreground = Brushes.Black;
                UsernameBorder.Background = Brushes.Black;

                PasswordIcon.Foreground = Brushes.Black;
                PasswordBorder.Background = Brushes.Black;

                UserIcon.Foreground = Brushes.Black;
                AccnameBorder.Background = Brushes.Black;

                ExceptionOfLoginOrPassword.Visibility = Visibility.Hidden;
            }
            else
            {
                passwordTb.Text = passwordTb.Text;

                AccountIcon.Foreground = Brushes.Black;
                UsernameBorder.Background = Brushes.Black;

                PasswordIcon.Foreground = Brushes.Black;
                PasswordBorder.Background = Brushes.Black;

                UserIcon.Foreground = Brushes.Black;
                AccnameBorder.Background = Brushes.Black;

                ExceptionOfLoginOrPassword.Visibility = Visibility.Hidden;
            }
           
        }

        /// <summary>
        /// Логин
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

                PasswordIcon.Foreground = Brushes.Black;
                PasswordBorder.Background = Brushes.Black;

                UserIcon.Foreground = Brushes.Black;
                AccnameBorder.Background = Brushes.Black;

                ExceptionOfLoginOrPassword.Visibility = Visibility.Hidden;
            }
            else
            {
                usernameTb.Text = usernameTb.Text;

                AccountIcon.Foreground = Brushes.Black;
                UsernameBorder.Background = Brushes.Black;

                PasswordIcon.Foreground = Brushes.Black;
                PasswordBorder.Background = Brushes.Black;

                UserIcon.Foreground = Brushes.Black;
                AccnameBorder.Background = Brushes.Black;

                ExceptionOfLoginOrPassword.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Выход на авторизацию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        /// <summary>
        /// Регистрация профиля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (usernameTb.Text != "" && userName.Text != "" && passwordTb.Text != "")
            {
                if (Access.Text == "Администратор")
                {
                    var query1 = new User()
                    {
                        FCs = userName.Text,
                        Login = usernameTb.Text,
                        Password = passwordTb.Text,
                        Access_rights = 1
                    };
                    dbContext.Users.Add(query1);
                    dbContext.SaveChanges();

                    MessageBox.Show("Профиль был успешно создан!");
                }
                else if (Access.Text == "Преподаватель")
                {
                    var query2 = new User()
                    {
                        FCs = userName.Text,
                        Login = usernameTb.Text,
                        Password = passwordTb.Text,
                        Access_rights = 2
                    };
                    dbContext.Users.Add(query2);
                    dbContext.SaveChanges();

                    MessageBox.Show("Профиль был успешно создан!");
                }
            }
            else
            {
                AccountIcon.Foreground = Brushes.Red;
                UsernameBorder.Background = Brushes.Red;

                PasswordIcon.Foreground = Brushes.Red;
                PasswordBorder.Background = Brushes.Red;

                UserIcon.Foreground = Brushes.Red;
                AccnameBorder.Background = Brushes.Red;

                ExceptionOfLoginOrPassword.Visibility = Visibility.Visible;
            }
        }
    }
}
