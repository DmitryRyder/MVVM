using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Course_Work
{
    public class BinaryRepository : IRepository
    {
        string Path;
        //private RepositoryType typeOfRepository;
        public RepositoryType TypeOfRepository => RepositoryType.BINARY;
        BinaryFormatter formatter;
        bool isClear;
        public bool IsClear
        {
            get
            {
                return isClear;
            }
            private set
            {
                isClear = value;
            }
        }

        public BinaryRepository(string path)
        {
            IsClear = false;
            Path = path;
            formatter = new BinaryFormatter();
        }

        public void CreateRepository()
        {
            //if (!File.Exists(Path) /*|| string.IsNullOrEmpty(Path)*/)
            //{
            //    File.Create(Path).Close();
            //}
        }

        public void ReadRepository(ObservableCollection<Bicycle> s)
        {
            s.Clear();
            ObservableCollection<Bicycle> ss = new ObservableCollection<Bicycle>();
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                ss = (ObservableCollection<Bicycle>)formatter.Deserialize(fs);
            }
             foreach (Bicycle i in ss)
                s.Add(i);
        }

        public void UpdateRepository(ObservableCollection<Bicycle> s)
        {
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, s);
            }

            IsClear = true;
        }
        public void DeleteDataRepository(ObservableCollection<Bicycle> s)
        {
            using (StreamWriter sw = new StreamWriter(Path, false, Encoding.UTF8)) { }

            s.Clear();
            IsClear = false;
        }
    }
}
