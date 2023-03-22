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

namespace sql
{
    public partial class signupAdmin : Window
    {
        private account currentRegestration = new account();
        private role currentRole = new role();
        public signupAdmin()
        {
            InitializeComponent();
            loginBox.MaxLength = 25;
            passwordBox.MaxLength = 25;
            passwordBoxRepeat.MaxLength = 25;
            SecondName.MaxLength = 25;
            FirstName.MaxLength = 25;
            Surname.MaxLength = 25;
            NumberPhone.MaxLength = 11;
        }
        private void RegistrationAccount(object sender, RoutedEventArgs e)
        {
            currentRegestration.login = loginBox.Text;
            currentRegestration.password = passwordBox.Text;
            currentRegestration.second_name = SecondName.Text;
            currentRegestration.first_name = FirstName.Text;
            currentRegestration.surname = Surname.Text;
            currentRegestration.telephone = NumberPhone.Text;

            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(loginBox.Text.ToString()))
                errors.AppendLine("Не указан логин");
            if (string.IsNullOrWhiteSpace(passwordBox.Text.ToString()))
                errors.AppendLine("Не указан пароль");
            if (string.IsNullOrWhiteSpace(passwordBoxRepeat.Text.ToString()))
                errors.AppendLine("Не указан повторный пароль");
            if (string.IsNullOrWhiteSpace(SecondName.Text.ToString()))
                errors.AppendLine("Не указана Фамилия");
            if (string.IsNullOrWhiteSpace(FirstName.Text.ToString()))
                errors.AppendLine("Не указано Имя");
            if (string.IsNullOrWhiteSpace(Surname.Text.ToString()))
                errors.AppendLine("Не указано Отчество");
            if (string.IsNullOrWhiteSpace(NumberPhone.Text.ToString()))
                errors.AppendLine("Не указан номера телефона");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (passwordBox.Text == passwordBoxRepeat.Text)
            {
                try
                {
                    using (PharmacySystemEntities db = new PharmacySystemEntities())
                    {
                        account loginCurrent = db.account.FirstOrDefault(x => x.login == loginBox.Text.ToString());
                        if (loginCurrent != null)
                        {
                            MessageBox.Show("Логин занят");
                        }
                        else
                        {
                            currentRegestration.id_role = 1;
                            db.account.Add(currentRegestration);
                            db.SaveChanges();

                            StringBuilder informationAccount = new StringBuilder();
                            informationAccount.AppendLine($"Ваш логин: {loginBox.Text}");
                            informationAccount.AppendLine($"Ваш пароль: {passwordBox.Text}");
                            informationAccount.AppendLine("Сохраните данные чтобы их не забыть");
                            MessageBox.Show(informationAccount.ToString());

                            login LogIn = new login();
                            LogIn.Show();
                            Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают");
            }
        }

        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            MainWindowAdmin mainAdmin = new MainWindowAdmin();
            mainAdmin.Show();
            Close();
        }

        private void LoginAccount(object sender, RoutedEventArgs e)
        {
            login LogIn = new login();
            LogIn.Show();
            Close();
        }

        private void NumberPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void SecondName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!Char.IsLetter(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void FirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!Char.IsLetter(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void Surname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!Char.IsLetter(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
    }
    
}