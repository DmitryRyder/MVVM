using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Work
{
    [Serializable]
    public class BicycleFrame : INotifyPropertyChanged
    {
        string material;
        int size;

        public BicycleFrame(string material, int size)
        {
            Material = material;
            Size = size;
        }

        #region Properties
        public string Material
        {
            get
            {
                return material;
            }
            set
            {
                material = value;
                NotifyPropertyChanged("Material");
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                NotifyPropertyChanged("Size");
            }
        }
        #endregion

        #region Methods
        private void NotifyPropertyChanged(String property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        #region INotifyPropertyChanged Members
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
