using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Work
{
    interface IFileService
    {
        ObservableCollection<Bicycle> Open(string filename);
        void Save(string filename, ObservableCollection<Bicycle> starlist);
    }
}
