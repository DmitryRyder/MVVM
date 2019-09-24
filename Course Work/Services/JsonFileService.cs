using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Course_Work
{
    class JsonFileService : IFileService
    {
        public ObservableCollection<Bicycle> Open(string filename)
        {
            ObservableCollection<Bicycle> Bicycles = new ObservableCollection<Bicycle>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<Bicycle>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                Bicycles = jsonFormatter.ReadObject(fs) as ObservableCollection<Bicycle>;
            }

            return Bicycles;
        }

        public void Save(string filename, ObservableCollection<Bicycle> BicycleList)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<Bicycle>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, BicycleList);
            }
        }
    }
}
