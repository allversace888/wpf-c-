using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class AddPreparation : Window
    {
        private preparation preparationCurrent = new preparation();
        public AddPreparation(preparation selectedpreparation)
        {
            InitializeComponent();
            producer.MaxLength = 55;
            form.MaxLength = 25;
            name.MaxLength = 55;
            price.MaxLength = 15;
            amount.MaxLength = 15;

            if (selectedpreparation != null)
                preparationCurrent = selectedpreparation;

           DataContext = preparationCurrent;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            
            if (preparationCurrent.producer == null)
                errors.AppendLine("Производитель перпарата отсутсвует");
            if (preparationCurrent.release_form == null)
                errors.AppendLine("Форма выпуска отсутвует");
            if (preparationCurrent.drug_name == null)
                errors.AppendLine("Название перпарата отсутсвует");
            if (preparationCurrent.price < 0 || preparationCurrent.price > 100000)
                errors.AppendLine("Цена указа не коректно");
            if (preparationCurrent.amount < 0 || preparationCurrent.price > 100000)
                errors.AppendLine("Количество указано не коректно");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
                if(preparationCurrent.id_preparation == 0)
                PharmacySystemEntities.GetContext().preparation.Add(preparationCurrent);
            try
            {
                PharmacySystemEntities.GetContext().SaveChanges();
                if (MessageBox.Show("Продолжить операцию?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MainWindowAdmin windowAdmin = new MainWindowAdmin();
                    windowAdmin.Show();
                    Close();
                }
                else
                {
                    AddPreparation repetAdd = new AddPreparation(null);
                    repetAdd.Show();
                    Close();
                    
                }
                
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message.ToString());
            }
        }
        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            MainWindowAdmin windowAdmin = new MainWindowAdmin();
            windowAdmin.Show();
            Close();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e. Text, 0)) e.Handled = true;
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e. Text, 0)) e.Handled = true;
        }
    }
}
