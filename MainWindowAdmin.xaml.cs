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
    public partial class MainWindowAdmin : Window
    {
        public MainWindowAdmin()
        {
            InitializeComponent();
            TBoxSearch.MaxLength = 55;
            var currentPreparation = PharmacySystemEntities.GetContext().preparation.ToList();
            LViewPreparation.ItemsSource = currentPreparation;
        }
        private void MaxBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                }
            }
        }

        private void UpdatePreparation()
        {
            var currentPreparation = PharmacySystemEntities.GetContext().preparation.ToList();
            currentPreparation = currentPreparation.Where(p => p.drug_name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            LViewPreparation.ItemsSource = currentPreparation;
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите выйти?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            { 
                Close();
            }
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите выйти к авторизации?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                login Login = new login();
                Login.Show();
                Close();
            }
        }
        private void Client_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите выйти к авторизации?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                login Login = new login();
                Login.Show();
                Close();
            }
        }
        private void Preparation_Click(object sender, RoutedEventArgs e)
        {
            LViewPreparation.Visibility = Visibility.Visible;
            Search.Visibility = Visibility.Visible;
        }
        private void AddAdmin_Click(object sender, RoutedEventArgs e)
        {
            signupAdmin AddAdmin = new signupAdmin();
            AddAdmin.Show();
            Close();
        }
        private void DeletePreparaation_Click(object sender, RoutedEventArgs e)
        {
            var deletePreparation = LViewPreparation.SelectedItems.Cast<preparation>();

            if (LViewPreparation.SelectedItem != null)
            {
                if (MessageBox.Show("Вы хотите удалить препарат безвозвратно?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        PharmacySystemEntities.GetContext().preparation.RemoveRange(deletePreparation);
                        PharmacySystemEntities.GetContext().SaveChanges();
                        MessageBox.Show("Успешно!");
                        LViewPreparation.ItemsSource = PharmacySystemEntities.GetContext().preparation.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                    LViewPreparation.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Выберите элемент");
            }
        }
        private void AddPreparation_Click(object sender, RoutedEventArgs e)
        {
            AddPreparation add = new AddPreparation(null);
            add.Show();
            Close();
        }
        
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePreparation();
        }

        private void LViewPreparation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var currentPreparation = LViewPreparation.SelectedItem as preparation;
            if (LViewPreparation.SelectedItem != null)
            {
                AddPreparation edit = new AddPreparation(currentPreparation);
                edit.Show();
                Close();
                LViewPreparation.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Выберите элемент");
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PharmacySystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LViewPreparation.ItemsSource = PharmacySystemEntities.GetContext().preparation.ToList();
            }
        }
    }
}
