using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Course_Work
{
    class StatusBarService : DependencyObject
    {
        public static readonly DependencyProperty StateProperty;
        public static readonly DependencyProperty CurrentRepositoryProperty;
        public static readonly DependencyProperty FileNameProperty;

        static StatusBarService()
        {
            StateProperty = DependencyProperty.Register("State", typeof(string), typeof(StatusBarService));
            CurrentRepositoryProperty = DependencyProperty.Register("CurrentRepository", typeof(string), typeof(StatusBarService));
            FileNameProperty = DependencyProperty.Register("FileName", typeof(string), typeof(StatusBarService));
        }

        public void SelectRepository(RepositoryType t, string filename)
        {
            int indexOfSubstring = filename.IndexOf("Repositories");
            StringBuilder sb = new StringBuilder(filename);
            sb.Remove(0, indexOfSubstring);
            string ShortFileName = ".../" + sb.ToString();

            switch (t)
            {
                case RepositoryType.TEXT: { CurrentRepository = "Текстовый репозиторий"; State = "Создан Текстовый репозиторий"; FileName = ShortFileName;  break; }
                case RepositoryType.BINARY: { CurrentRepository = "Бинарный репозиторий"; State = "Создан Бинарный репозиторий"; FileName = ShortFileName; break; }
                default: CurrentRepository = "Репозиторий не создан"; break;
            }
        }

        public void SelectMemoryRepository()
        {
            CurrentRepository = "Репозиторий в памяти";
            State = "Создан репозиторий в памяти";
            FileName = "InMemory";
        }

        public string State
        {
            get { return (string)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public string CurrentRepository
        {
            get { return (string)GetValue(CurrentRepositoryProperty); }
            set { SetValue(CurrentRepositoryProperty, value); }
        }

        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }
    }
}
