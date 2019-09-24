using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Course_Work
{
    public class TextRepository : IRepository
    {
        string Path;
        public RepositoryType TypeOfRepository => RepositoryType.TEXT;
        List<string> buffer;
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

        public TextRepository(string path)
        {
            buffer = new List<string>();
            IsClear = false;
            Path = path;
        }

        public void CreateRepository()
        {
            //if (!File.Exists(Path))
            //{
            //    File.Create(Path);
            //}
        }

        public void ReadRepository(ObservableCollection<Bicycle> s)
        {
            using (StreamReader sr = new StreamReader(Path)) //поток чтения файла - локального
            {
                while (sr.Peek() >= 0) //контролируем что в файле еще есть символы
                {
                    buffer.Add(sr.ReadLine()); //записываем всю строку в элемент списка буфер
                }
            }
            s.Clear();

            for (int i = 0; i < buffer.Count; i++)
            {
                string[] words = buffer[i].Split(' '); // разделяем строку на массив строк
                uint id = uint.Parse(words[0]);
                string model = words[1];
                string manufacture = words[2];
                int year = int.Parse(words[3]);
                int numberOfSpeeds = int.Parse(words[4]);
                string type = words[5];
                BicycleFrame Frame = new BicycleFrame(words[6], int.Parse(words[7]));
                string creationTime = words[8];

                s.Add(new Bicycle(model, manufacture, year, numberOfSpeeds, type, Frame, id, creationTime));
            }
            buffer.Clear();
        }

        public void UpdateRepository(ObservableCollection<Bicycle> s)
        {
            for (int i = 0; i < s.Count; i++)
            {
                buffer.Add(s[i].ID.ToString() + ' ' + s[i].Model + ' ' + s[i].Manufacture + ' ' + s[i].Year + ' ' + s[i].NumberOfSpeeds + ' ' + s[i].Type + ' ' + s[i].Frame.Material + ' ' + s[i].Frame.Size + ' ' + s[i].CreationTime);
            }

            using (StreamWriter sw = new StreamWriter(Path, false, Encoding.UTF8))
            {
                foreach(string str in buffer)
                {
                    sw.WriteLine(str);
                }
            }

            buffer.Clear();
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
