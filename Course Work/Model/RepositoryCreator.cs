using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Work
{
    public class RepositoryCreator
    {
        private static IRepository repository;
        private static RepositoryCreator instance = new RepositoryCreator();

        private RepositoryCreator() { }

        public static RepositoryCreator Instance => instance ?? new RepositoryCreator();

        public IRepository Repository => repository;

        public void Initialize(RepositoryType type, string path)
        {
            try
            {
                switch (type)
                {
                    case RepositoryType.BINARY: repository = new BinaryRepository(path); break;
                    case RepositoryType.TEXT: repository = new TextRepository(path); break;
                    case RepositoryType.MEMORY: repository = new MemoryRepository(); break;
                    default: repository = repository ?? new MemoryRepository(); break;
                }
            }
            catch (NullReferenceException) { Console.WriteLine("Exception is here"); }
        }
    }
}
