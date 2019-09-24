using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExtendedCommands
{
    public static class DataCommand
    {
        private static RoutedUICommand requery;

        static DataCommand()
        {
            // Инициализация команды. 
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl+R"));
            requery = new RoutedUICommand("Requery", "Requery", typeof(DataCommand), inputs);
        }
        public static RoutedUICommand Requery
        {
            get { return requery; }
        }
    }
}
