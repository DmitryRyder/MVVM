using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Work
{
    public interface IRepository
    {
        bool IsClear { get;}
        void CreateRepository();
        RepositoryType TypeOfRepository { get; }
        void ReadRepository(ObservableCollection<Bicycle> s);
        void UpdateRepository(ObservableCollection<Bicycle> s);
        void DeleteDataRepository(ObservableCollection<Bicycle> s);
    }
}
