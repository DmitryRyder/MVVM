using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Work
{
    [Serializable]
    public class Bicycle : INotifyPropertyChanged
    {
        string creationTime;
        uint id;

        string model;
        string manufacture;
        int year;
        int numberOfSpeeds;
        string type;
        public BicycleFrame Frame { get; private set; }

        #region Constructors
        public Bicycle() { }
        public Bicycle(string model, string manufacture, int year, int numberofspeeds, string type, BicycleFrame frame, uint id, string creatiotime)
        {
            Model = model;
            Manufacture = manufacture;
            Year = year;
            NumberOfSpeeds = numberofspeeds;
            Type = type;
            Frame = frame;
            ID = id;
            CreationTime = creatiotime;
        }

        public Bicycle(string model, string manufacture, int year, int numberofspeeds, string type, BicycleFrame frame)
        {
            Model = model;
            Manufacture = manufacture;
            Year = year;
            NumberOfSpeeds = numberofspeeds;
            Type = type;
            Frame = frame;
            CreationTime = DateTime.Now.ToString();
            ID = Guid2Int(GuidGenerate());
        }
        #endregion

        #region Properties
        public string CreationTime
        {
            get
            {
                return creationTime;
            }
            set
            {
                creationTime = value;
                NotifyPropertyChanged("CreationTime");
            }
        }

        public uint ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                NotifyPropertyChanged("Model");
            }
        }

        public string Manufacture
        {
            get
            {
                return manufacture;
            }
            set
            {
                manufacture = value;
                NotifyPropertyChanged("Manufacture");
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                NotifyPropertyChanged("Year");
            }
        }

        public int NumberOfSpeeds
        {
            get
            {
                return numberOfSpeeds;
            }
            set
            {
                numberOfSpeeds = value;
                NotifyPropertyChanged("NumberOfSpeeds");
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                NotifyPropertyChanged("Type");
            }
        }
        #endregion

        #region Methods
        //private void GuidGenerate()
        //{
        //    Guid originalGuid = Guid.NewGuid();
        //    id = originalGuid.ToString("N");
        //}

        //public static Guid Int2Guid(int value)
        //{
        //    byte[] bytes = new byte[16];
        //    BitConverter.GetBytes(value).CopyTo(bytes, 0);
        //    return new Guid(bytes);
        //}

        private uint Guid2Int(Guid value)
        {
            byte[] b = value.ToByteArray();
            uint bint = BitConverter.ToUInt32(b, 0);
            return bint;
        }

        private Guid GuidGenerate()
        {
            return Guid.NewGuid();
        }

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
