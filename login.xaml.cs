using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
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

namespace sql
{
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
            loginBox.MaxLength = 25;
            passwordBox.MaxLength = 25;
            passwordBoxDubler.IsReadOnly = true;
        }

        public void LoginAccount(object sender, RoutedEventArgs e)
        {
            string passwordText = passwordBox.Password.Trim();

            using (PharmacySystemEntities db = new PharmacySystemEntities())
            {
                var accountCurrent = db.account.Where(p => p.login == loginBox.Text && p.password == passwordText).FirstOrDefault();

                var roleCurrent = db.account.Where(p => p.login == loginBox.Text && p.password == passwordText && p.id_role == 1).FirstOrDefault();

                if (accountCurrent != null)
                {
                    if (roleCurrent != null)
                    {
                        MainWindowAdmin mainWindow = new MainWindowAdmin();
                        mainWindow.Show();
                        Close();
                    }
                    else
                    {
                        MainWindow mainWindow = new MainWindow(loginBox.Text);
                        mainWindow.Show();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Дынные введены некорректно");
                }
            }
        }
        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NewAccount(object sender, RoutedEventArgs e)
        {
            signup SignUp = new signup();
            SignUp.Show();
            Close();
        }

        private void viewBtn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            passwordBoxDubler.Text = passwordBox.Password;
            passwordBox.Visibility = Visibility.Hidden;
            passwordBoxDubler.Visibility = Visibility.Visible;
        }

        private void viewBtn_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            passwordBoxDubler.Visibility = Visibility.Hidden;
            passwordBox.Password = passwordBoxDubler.Text;
            passwordBox.Visibility = Visibility.Visible;
        }

        private void loginBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void passwordBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}