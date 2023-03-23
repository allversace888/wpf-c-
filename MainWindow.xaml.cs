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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Data.SqlClient;

namespace sql
{
    public partial class MainWindow : Window
    {
        private preparation preparationCurrent = new preparation();
        private indent indentCurrent = new indent();
        private order_details order_detailsCurrent = new order_details();
        public MainWindow(string loginBox)
        {
            InitializeComponent();
            
            PreviewLogin.Text = loginBox;
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
            var currentSearch = PharmacySystemEntities.GetContext().preparation.ToList();
            var currentPreparationName = currentSearch;
            currentPreparationName = currentPreparationName.Where(p => p.drug_name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            LViewPreparation.ItemsSource = currentPreparationName;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите выйти?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
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
            DataGridBasket.Visibility = Visibility.Hidden;
            LViewPreparation.Visibility = Visibility.Visible;
            Search.Visibility = Visibility.Visible;
            SetBasket.Visibility = Visibility.Hidden;
        }
        private void Basket_Click(object sender, RoutedEventArgs e)
        {
            LViewPreparation.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Hidden;
            DataGridBasket.Visibility = Visibility.Visible;
            SetBasket.Visibility = Visibility.Visible;
        }

        public List<order_details> Order_DetailsList = new List<order_details>();
        private void BasketAdd_Click(object sender, RoutedEventArgs e)
        {
            preparation selectedPreparation = (preparation)LViewPreparation.SelectedItem;
            order_details order_Details = new order_details
            {
                id_preparation = selectedPreparation.id_preparation,
                amount = 1
            };
            Order_DetailsList.Add(order_Details);
        }
        private void SetBasket_Click(object sender, RoutedEventArgs e)
        {
            indent indent = new indent
            {
                login = PreviewLogin.Text,
                data_indent = DateTime.Now,
                order_details = Order_DetailsList
            };
            PharmacySystemEntities.GetContext().indent.Add(indent);
            PharmacySystemEntities.GetContext().SaveChanges();
            Order_DetailsList.Clear();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PharmacySystemEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LViewPreparation.ItemsSource = PharmacySystemEntities.GetContext().preparation.ToList();
            }
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePreparation();
        }

    }
}
