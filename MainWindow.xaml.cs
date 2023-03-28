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
using System.Threading;
using System.Globalization;

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
            LViewPreparation.Visibility = Visibility.Visible;
            Search.Visibility = Visibility.Visible;
            DataGridBasket.Visibility = Visibility.Hidden;
            SetBasket.Visibility = Visibility.Hidden;
            ChangeAmountAddBasket.Visibility = Visibility.Hidden;
            ChangeAmountDeleteBasket.Visibility = Visibility.Hidden;
            DeleteBasket.Visibility = Visibility.Hidden;
            Count.Visibility = Visibility.Hidden;
        }
        public List<order_details> Order_DetailsList = new List<order_details>();
        private void LViewPreparation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            preparation selectedPreparation = (preparation)LViewPreparation.SelectedItem;
            order_details existedDetails = Order_DetailsList.Find(detail => detail.id_preparation == selectedPreparation.id_preparation);
           
                if (existedDetails != null)
                {
                    existedDetails.amount += 1;
                    return;
                }
                
                if (LViewPreparation.SelectedItem != null)
                {
                    order_details details = PharmacySystemEntities.GetContext().order_details.Create();
                    details.id_preparation = selectedPreparation.id_preparation;
                    details.preparation = selectedPreparation;
                    details.amount = 1;
                    Order_DetailsList.Add(details);
                    MessageBox.Show("Препарат в коризне");
                }
            
        }
        private void Basket_Click(object sender, RoutedEventArgs e)
        {
            DataGridBasket.ItemsSource = Order_DetailsList.Select(detail =>
            {
                return new DetailClass
                {
                    id_preparation = detail.id_preparation,
                    drug_name = detail.preparation.drug_name,
                    price = detail.preparation.price,
                    amount = (int)detail.amount,
                    total_price = (int)(detail.preparation.price * detail.amount)
                };
            });

            LViewPreparation.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Hidden;
            DataGridBasket.Visibility = Visibility.Visible;
            SetBasket.Visibility = Visibility.Visible;
            ChangeAmountAddBasket.Visibility = Visibility.Visible;
            ChangeAmountDeleteBasket.Visibility = Visibility.Visible;
            DeleteBasket.Visibility = Visibility.Visible;
            Count.Visibility = Visibility.Visible;

            int totalSum = Order_DetailsList.Aggregate(0,(acc, item) => acc + item.total_price);
            TotalPrice.Text = totalSum.ToString();
        }
        private void SetBasket_Click(object sender, RoutedEventArgs e)
        {
            preparation selectedPreparation = (preparation)LViewPreparation.SelectedItem;
            if (selectedPreparation != null)
                if (selectedPreparation.amount <= 0)
                {
                    MessageBox.Show("Препарат отсутсвует в наличии");
                }
                else
                {
                    if (Order_DetailsList.Count > 0)
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

                        MessageBox.Show("Заказ успешно сформирован. Подробности можно узнать во вкладке -Заказы-");
                        DataGridBasket.ItemsSource = Order_DetailsList.Select(detail =>
                        {
                            return new DetailClass
                            {
                                id_preparation = detail.id_preparation,
                                drug_name = detail.preparation.drug_name,
                                price = detail.preparation.price,
                                amount = (int)detail.amount,
                                total_price = (int)(detail.preparation.price * detail.amount)
                            };
                        });
                    }
                    else
                    {
                        MessageBox.Show("Ваша корзина пуста.");
                    }
                }
        }

        private void ChangeAmountAddBasket_Click(object sender, RoutedEventArgs e)
        {
            var selectedPreparation = (DetailClass)DataGridBasket.SelectedItem;
            if (DataGridBasket.SelectedItem != null)
            {
                order_details existedDetails = Order_DetailsList.Find(detail => detail.id_preparation == selectedPreparation.id_preparation);
                if (existedDetails != null)
                {
                    existedDetails.amount += 1;
                    DataGridBasket.ItemsSource = Order_DetailsList.Select(detail =>
                    {
                        return new DetailClass
                        {
                            id_preparation = detail.id_preparation,
                            drug_name = detail.preparation.drug_name,
                            price = detail.preparation.price,
                            amount = (int)detail.amount,
                            total_price = (int)(detail.preparation.price * detail.amount)
                        };
                    });
                }
            }
        }
        private void ChangeAmountDeleteBasket_Click(object sender, RoutedEventArgs e)
        {

            var selectedPreparation = (DetailClass)DataGridBasket.SelectedItem;

            if (DataGridBasket.SelectedItem != null)
            {
                order_details existedDetails = Order_DetailsList.Find(detail => detail.id_preparation == selectedPreparation.id_preparation);
                if (existedDetails.amount > 1)
                {
                    existedDetails.amount -= 1;
                    DataGridBasket.ItemsSource = Order_DetailsList.Select(detail =>
                    {
                        return new DetailClass
                        {
                            id_preparation = detail.id_preparation,
                            drug_name = detail.preparation.drug_name,
                            price = detail.preparation.price,
                            amount = (int)detail.amount,
                            total_price = (int)(detail.preparation.price * detail.amount)
                        };
                        
                    });

                }
                else
                {
                    Order_DetailsList = Order_DetailsList.Where(p => p.id_preparation != selectedPreparation.id_preparation).ToList();
                    DataGridBasket.ItemsSource = Order_DetailsList.Select(detail =>
                    {
                        return new DetailClass
                        {
                            id_preparation = detail.preparation.id_preparation,
                            drug_name = detail.preparation.drug_name,
                            price = detail.preparation.price,
                            amount = (int)detail.amount,
                            total_price = (int)(detail.preparation.price * detail.amount),
                        };
                    });
                }
            }
        }
        private void DeleteBasket_Click(object sender, RoutedEventArgs e)
        {
            var selectedPreparation = (DetailClass)DataGridBasket.SelectedItem;
            if(selectedPreparation != null)
            Order_DetailsList = Order_DetailsList.Where(p => p.id_preparation != selectedPreparation.id_preparation).ToList();
            DataGridBasket.ItemsSource = Order_DetailsList.Select(detail =>
            {
                return new DetailClass
                {
                    id_preparation = detail.preparation.id_preparation,
                    drug_name = detail.preparation.drug_name,
                    price = detail.preparation.price,
                    amount = (int)detail.amount,
                    total_price = (int)(detail.preparation.price * detail.amount)
                };
            });
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
