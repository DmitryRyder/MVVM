using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Course_Work
{
    class AddOrEditBicycleDialogService
    {
        DependencyBicycleValidation bicycle;

        public bool InputDialog(MainWindow p)
        {
            bicycle = new DependencyBicycleValidation();
            CustomBicycleAddDialog s = new CustomBicycleAddDialog(bicycle);
            s.Owner = p;
            p.GridBackground.Opacity = 1;
            Panel.SetZIndex(p.GridBackground, 1);
            if (s.ShowDialog() == true)
            {
                p.GridBackground.Opacity = 0;
                Panel.SetZIndex(p.GridBackground, 0);
                return true;
            }
            p.GridBackground.Opacity = 0;
            Panel.SetZIndex(p.GridBackground, 0);
            return false;
        }

        public bool EditDialog(MainWindow p, Bicycle bFromList)
        {
            bicycle = new DependencyBicycleValidation(bFromList);
            CustomBicycleAddDialog s = new CustomBicycleAddDialog(bicycle);
            s.Owner = p;
            p.GridBackground.Opacity = 1;
            Panel.SetZIndex(p.GridBackground, 1);
            if (s.ShowDialog() == true)
            {
                p.GridBackground.Opacity = 0;
                Panel.SetZIndex(p.GridBackground, 0);
                return true;
            }
            p.GridBackground.Opacity = 0;
            Panel.SetZIndex(p.GridBackground, 0);
            return false;
        }

        public Bicycle GetData()
        {
            return bicycle.GetBicycle();
        }

        public Bicycle GetDataToEdit()
        {
            return bicycle.GetBicycle();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
