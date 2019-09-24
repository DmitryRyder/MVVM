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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chbx = (CheckBox)sender;

            chbx.Content = "Неотмечено";

            sender = chbx;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chbx = (CheckBox)sender;

            chbx.Content = "Отмечено";

            sender = chbx;
        }

        private void checkBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            CheckBox chbx = (CheckBox)sender;

            chbx.Content = "Неопределено";

            sender = chbx;
        }

        private void RadioButton_Checked1(object sender, RoutedEventArgs e)
        {

            RadioButton rdb = new RadioButton();
            rdb = (RadioButton)sender;

            foreach (UIElement p in StackPanel1.Children)
            {
                if (p is TextBlock) ((TextBlock)p).Text = "Выбрано " + rdb.Content.ToString();
            }

            rdb.IsChecked = true;

            sender = rdb;
        }
        private void RadioButton_Checked2(object sender, RoutedEventArgs e)
        {

            RadioButton rdb = new RadioButton();
            rdb = (RadioButton)sender;

            foreach (UIElement p in StackPanel2.Children)
            {
                if (p is TextBlock) ((TextBlock)p).Text = "Выбрано " + rdb.Content.ToString();
            }

            rdb.IsChecked = true;

            sender = rdb;
        }

        private void Button_MouseEnter_1(object sender, MouseEventArgs e)
        {
            popup1.IsOpen = true;
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            scroll.LineUp();
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            scroll.LineDown();
        }
    }
}
