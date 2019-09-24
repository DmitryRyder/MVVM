using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Course_Work
{
    /// <summary>
    /// Логика взаимодействия для SizeofRepositoryDialogxaml.xaml
    /// </summary>
    public partial class CustomBicycleAddDialog : Window
    {
        public CustomBicycleAddDialog(DependencyBicycleValidation bicycle)
        {
            Resources.Add("bicycle", bicycle);
            InitializeComponent();
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FormHasErrors())
            {
                MessageBox.Show("Прверте правильность ввода данных или введите недостающие данные", "Некорректный ввод", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                this.DialogResult = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {               
                this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Model.Focus();
        }

        private bool FormHasErrors()
        {
            foreach(var child in GridFields.Children)
            {
                if (child is TextBox)
                {
                    TextBox element = child as TextBox;
                    if (!Validation.GetHasError(element)) continue;
                    else return Validation.GetHasError(element);
                }

                if(child is ComboBox)
                {
                    ComboBox element = child as ComboBox;
                    if (!Validation.GetHasError(element)) continue;
                    else return Validation.GetHasError(element);
                }
            }
            return false;
        }
    }
}
