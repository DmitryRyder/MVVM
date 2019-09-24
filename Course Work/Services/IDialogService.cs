using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Work
{
    interface IDialogService
    {
        void ShowMessage(string message);   // показ сообщения
        string FilePath { get; set; }   // путь к выбранному файлу
        RepositoryType TypeOfReposirory { get; set; } // тип репозитория
        bool OpenFileDialog(string Path);  // открытие файла с указанием каталога
        bool OpenFileDialog(string Path, RepositoryType type);  // перегруженный метод открытия файла с указанием типа репозитория
        bool SaveFileDialog(string Path);  // сохранение файла с указанием каталога
        bool SaveFileDialog(string Path, RepositoryType type);  // перегруженный метод сохранения файла с указанием типа репозитория
    }
}
