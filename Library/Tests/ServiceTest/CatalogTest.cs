using Data.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ServiceTest
{
    internal class Catalog : Service.API.ICatalog
    {
        public String Author { get; set; }
        public String Title { get; set; }
        public List<IBook> Books { get; set; }

        public Catalog(string author, string title)
        {
            Author = author;
            Title = title;
            Books = new List<IBook>();
        }
    }
    [TestClass]
    public class CatalogTest
    {
        private IDataRepository? dataRepository;
        private IService? service;
    }
}
