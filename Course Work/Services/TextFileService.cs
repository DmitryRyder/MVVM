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
    class TextFileService : IFileService
    {
        public ObservableCollection<Bicycle> Open(string filename)
        {
            ObservableCollection<Bicycle> Bicycles = new ObservableCollection<Bicycle>();
            List<string> buffer = new List<string>();

            using (StreamReader sr = new StreamReader(filename)) //поток чтения файла - локального
            {
                while (sr.Peek() >= 0) //контролируем что в файле еще есть символы
                {
                    buffer.Add(sr.ReadLine()); //записываем всю строку в элемент списка буфер
                }
            }
            
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

                Bicycles.Add(new Bicycle(model, manufacture, year, numberOfSpeeds, type, Frame, id, creationTime));
            }
            buffer.Clear();

            return Bicycles;
        }

        public void Save(string filename, ObservableCollection<Bicycle> s)
        {
            List<string> buffer = new List<string>();

            for (int i = 0; i < s.Count; i++)
            {
                buffer.Add(s[i].ID.ToString() + ' ' + s[i].Model + ' ' + s[i].Manufacture + ' ' + s[i].Year + ' ' + s[i].NumberOfSpeeds + ' ' + s[i].Type+ ' ' + s[i].Frame.Material + ' ' + s[i].Frame.Size + ' ' + s[i].CreationTime);
            }


            //using (var fileStream = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //{
            //    using (StreamWriter sw = new StreamWriter(filename, true))
            //    {
            //        foreach (string str in buffer)
            //        {
            //            sw.WriteLine(str);
            //        }
            //    }
            //}

            using (StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8))
            {
                foreach (string str in buffer)
                {
                    sw.WriteLine(str);
                }
                sw.Dispose();
            }
        }
    }
}
