using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Course_Work
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public uint ID;
        public bool isChanded = false;

        public MainWindow()
        {
            StatusBarService StatusBar = new StatusBarService();
            Resources.Add("StatusBar", StatusBar);
            InitializeComponent();
            DataContext = new MainWindowVM(StatusBar, this);
        }

        private void ToggleButtonClick_RightClick(object sender, RoutedEventArgs e)
        {
            DependencyObject obj = (DependencyObject)e.OriginalSource;

            while (!(obj is DataGridRow) && obj != null) obj = VisualTreeHelper.GetParent(obj);
            try
            {
                if ((obj as DataGridRow).DetailsVisibility == Visibility.Visible)
                {
                    (obj as DataGridRow).IsSelected = false;
                    dataGrid2.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.Collapsed;
                }
                else
                {
                    (obj as DataGridRow).IsSelected = true;
                    dataGrid2.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.VisibleWhenSelected;
                }
            }
            catch(NullReferenceException)
            {

            }
        }

        public void dataGrid2_SelectionChanded(object sender, SelectionChangedEventArgs e)
        {
            object item = dataGrid2.SelectedItem;
            try
            {   if (item != null)
                {
                    ID = Convert.ToUInt32((dataGrid2.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    isChanded = true;
                }
                else
                    isChanded = false;

            }
            catch (ArgumentOutOfRangeException)
            {
                isChanded = false;
            }
        }

        private void dataGrid1_RowDetailsVisibilityChanged(object sender, DataGridRowDetailsEventArgs e)
        {
            DataGridRow row = e.Row as DataGridRow;
            FrameworkElement tb = GetTemplateChildByName(row, "RowHeaderToggleButton");
            if (tb != null)
            {
                if (row.DetailsVisibility == System.Windows.Visibility.Visible)
                {
                    (tb as ToggleButton).IsChecked = true;
                }
                else
                {
                    (tb as ToggleButton).IsChecked = false;
                    dataGrid2.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.Collapsed;
                }
            }
        }

        public static FrameworkElement GetTemplateChildByName(DependencyObject parent, string name)
        {
            int childnum = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childnum; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is FrameworkElement && ((FrameworkElement)child).Name == name)
                {
                    return child as FrameworkElement;
                }
                else
                {
                    var s = GetTemplateChildByName(child, name);
                    if (s != null)
                        return s;
                }
            }
            return null;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            AboutAutor.Visibility = Visibility.Visible;
            Panel.SetZIndex(GridBackground, 1);
            GridBackground.Opacity = 1;
            //GridLength p = new GridLength(200);
            //Main.ColumnDefinitions[0].Width = p;

        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            AboutAutor.Visibility = Visibility.Collapsed;
            Panel.SetZIndex(GridBackground, 0);
            GridBackground.Opacity = 0;
            //GridLength p = new GridLength(70);
            //Main.ColumnDefinitions[0].Width = p;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double p = GridBackground.Opacity;

            if (p == 1)
            {
                ((Storyboard)this.Resources["CloseMenu"]).Begin(this);
                ButtonCloseMenu.Visibility = Visibility.Collapsed;
                ButtonOpenMenu.Visibility = Visibility.Visible;
                AboutAutor.Visibility = Visibility.Collapsed;
                Panel.SetZIndex(GridBackground, 0);
                GridBackground.Opacity = 0;
            }
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //UserControl usc = null;
            //GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "MemoryRepository":
                    CustomDataGridMain.Visibility = Visibility.Visible;
                    //MainWindowVM.CreateRepository(RepositoryType.MEMORY, null);
                    break;
                case "TextRepository":
                    //usc = new UserControlCreate();
                    //GridMain.Children.Add(usc);
                    //CustomDataGridMain.Visibility = Visibility.Visible;
                    //MainWindowVM.CreateRepository(RepositoryType.TEXT, MainWindowVM.Path);
                    break;
                case "BinaryRepository":
                    CustomDataGridMain.Visibility = Visibility.Visible;
                    //MainWindowVM.CreateRepository(RepositoryType.BINARY, MainWindowVM.Path);
                    break;
                default:
                    break;
            }
        }

        private void CreateTable_Click(object sender, RoutedEventArgs e)
        {
            CustomDataGridMain.Visibility = Visibility.Visible;
            myImage.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Panel.SetZIndex(GridBackground, 1);
        }
    }
}
