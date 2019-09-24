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
    public class MemoryRepository : IRepository
    {
        int size;
        byte[] storage;
        public RepositoryType TypeOfRepository => RepositoryType.MEMORY;
        MemoryStream memstrm;
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

        public MemoryRepository()
        {
            IsClear = false;
            size = 4;
        }

        public MemoryRepository(int size)
        {
            IsClear = false;
            this.size = size;
        }
    
        public void CreateRepository()
        {
            storage = new byte[size * 1000000];
            memstrm = new MemoryStream(storage);
            formatter = new BinaryFormatter();    
        }

        public void ReadRepository(ObservableCollection<Bicycle> s)
        {
            s.Clear();
            ObservableCollection<Bicycle> p = new ObservableCollection<Bicycle>();
            memstrm.Seek(0, SeekOrigin.Begin);
            p = (ObservableCollection<Bicycle>)formatter.Deserialize(memstrm);
            memstrm.Seek(0, SeekOrigin.Begin);

            foreach (Bicycle i in p)
                s.Add(i);
        }

        public void UpdateRepository(ObservableCollection<Bicycle> list)
        {
            formatter.Serialize(memstrm, list);
            if (memstrm.Length > 0) IsClear = true;
        }

        public void DeleteDataRepository(ObservableCollection<Bicycle> t)
        {
            Array.Clear(storage, 0, size);
            t.Clear();
            IsClear = false;
        }
    }
}
