using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Course_Work
{
    class DefaultDialogService : IDialogService
    {
        public string FilePath { get; set; }
        public RepositoryType TypeOfReposirory { get; set; }

        public bool OpenFileDialog(string Path)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            string path = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            path = System.IO.Path.GetDirectoryName(path);
            path += Path;

            openFileDialog.InitialDirectory = path;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "All Files(*.*)|*.*|TXT Files (*.txt)|*.txt|Binary Files (*.dat)|*.dat";

            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;

                string[] words = FilePath.Split('.');

                switch (words[1])
                {
                    case "txt": TypeOfReposirory = RepositoryType.TEXT; break;
                    case "dat": TypeOfReposirory = RepositoryType.BINARY; break;
                }

                return true;
            }
            return false;
        }

        public bool OpenFileDialog(string Path, RepositoryType type)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            string path = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            path = System.IO.Path.GetDirectoryName(path);
            path += Path;

            openFileDialog.InitialDirectory = path;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "All Files(*.*)|*.*|TXT Files (*.txt)|*.txt|Binary Files (*.dat)|*.dat";

            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }

            return false;
        }

        public bool SaveFileDialog(string Path)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            string path = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            path = System.IO.Path.GetDirectoryName(path);
            path += Path;

            saveFileDialog.InitialDirectory = path;
            saveFileDialog.Filter = "TXT Files (*.txt)|*.txt|Binary Files (*.dat)|*.dat";

            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;

                string[] words = FilePath.Split('.');

                switch (words[1])
                {
                    case "txt": TypeOfReposirory = RepositoryType.TEXT; break;
                    case "dat": TypeOfReposirory = RepositoryType.BINARY; break;
                }
                return true;
            }
            return false;
        }

        public bool SaveFileDialog(string Path, RepositoryType type)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            string path = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            path = System.IO.Path.GetDirectoryName(path);
            path += Path;

            saveFileDialog.InitialDirectory = path;

            if (type is RepositoryType.BINARY)
            {
                saveFileDialog.Filter = "Binary Files (*.dat)|*.dat";
            }

            if (type is RepositoryType.TEXT)
            {
                saveFileDialog.Filter = "TXT Files (*.txt)|*.txt";
            }

            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
