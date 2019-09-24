using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Course_Work
{
    class BinaryFileService : IFileService
    {
        public ObservableCollection<Bicycle> Open(string filename)
        {
            ObservableCollection<Bicycle> Bicycles = new ObservableCollection<Bicycle>();
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                Bicycles = (ObservableCollection<Bicycle>)formatter.Deserialize(fs);
            }

            return Bicycles;
        }

        public void Save(string filename, ObservableCollection<Bicycle> BicycleList)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            //using (var fileStream = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //{
            //    using (FileStream fs = new FileStream(filename, true)
            //    {
            //        formatter.Serialize(fs, StarsList);
            //    }
            //}

            using (FileStream fs = new FileStream(filename, FileMode.Append))
            {
                formatter.Serialize(fs, BicycleList);
                fs.Dispose();
            }

        }
    }
}

