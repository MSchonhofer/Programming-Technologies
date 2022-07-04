using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Tests.ServiceTest
{
    internal class TestReader : IReader
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ReaderID { get; set; }
    }
    internal class TestAction : IAction
    {
        public int ActionID { get; set; }
        public int? CatalogID { get; set; }
        public int? ReaderID { get; set; }

    }
    internal class TestCatalog : ICatalog
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int CatalogID { get; set; }

    }
}
