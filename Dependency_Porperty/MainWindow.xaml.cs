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

namespace Dependency_Porperty
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Resources.Add("iPhone6s", new Phone() { Price = 600, Title = "iPhone 6S" });
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Phone phone = (Phone)this.Resources["iPhone6s"]; // получаем ресурс по ключу
            MessageBox.Show(phone.Price.ToString());
        }

        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            ((Phone)this.Resources["iPhone6s"]).Price+=100;
        }

        private void Button_Click_del(object sender, RoutedEventArgs e)
        {
            if (((Phone)this.Resources["iPhone6s"]).Price - 100 < 0)
            {
                MessageBox.Show("Элементов для удаления не осталось");
                return;
            }
            ((Phone)this.Resources["iPhone6s"]).Price-=100;
        }
    }

    public class Phone : DependencyObject
    {
        public static readonly DependencyProperty TitleProperty;
        public static readonly DependencyProperty PriceProperty;

        static Phone()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Phone));

            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();

            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);//делегат вызываемый посе ValidateValueCallback который проверяет диапазон значений на справделивость

            PriceProperty = DependencyProperty.Register("Price", typeof(int), typeof(Phone), metadata, new ValidateValueCallback(ValidateValue));
        }

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            int currentValue = (int)baseValue;
            if (currentValue > 1000)  // если больше 1000, возвращаем 1000
                return 1000;
            return currentValue; // иначе возвращаем текущее значение
        }

        private static bool ValidateValue(object value)
        {
            int currentValue = (int)value;

            if (currentValue >= 0) // если текущее значение от нуля и выше //нельзя ставить 0
                return true;
            else
                return false;
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public int Price
        {
            get { return (int)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }
    }
}
