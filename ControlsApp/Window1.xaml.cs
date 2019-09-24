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

namespace ControlsApp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void add_H_Button_Click(object sender, RoutedEventArgs e)
        {
            string i = Convert.ToString(Wrap_H.Children.Count + 1);

            SolidColorBrush[] colors = new SolidColorBrush[4] { Brushes.Blue, Brushes.Green, Brushes.White, Brushes.LawnGreen };

            Random y = new Random();

            int c = y.Next(0, 4);

            Button l = new Button();

            l.Content = i;
            l.Width = 80;
            l.Height = 30;
            l.Background = colors[c];

            Wrap_H.Children.Add(l);
        }

        private void del_H_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Wrap_H.Children.Count != 0)
            {
                Wrap_H.Children.RemoveAt((Wrap_H.Children.Count - 1));
            }
            else MessageBox.Show("Элементов для удаления не осталось");
        }

        private void add_V_Button_Click(object sender, RoutedEventArgs e)
        {
            string i = Convert.ToString(Wrap_V.Children.Count + 1);

            SolidColorBrush[] colors = new SolidColorBrush[4] { Brushes.Blue, Brushes.Green, Brushes.White, Brushes.LawnGreen };

            Random y = new Random();

            int c = y.Next(0, 4);

            Button l = new Button();

            l.Content = i;
            l.Width = 80;
            l.Height = 30;
            l.Background = colors[c];

            Wrap_V.Children.Add(l);
        }

        private void del_V_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Wrap_V.Children.Count != 0)
            {
                Wrap_V.Children.RemoveAt((Wrap_V.Children.Count - 1));
            }
            else MessageBox.Show("Элементов для удаления не осталось");
        }
    }
}
