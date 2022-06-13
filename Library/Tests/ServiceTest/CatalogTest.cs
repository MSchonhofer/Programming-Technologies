using Data.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICatalog = Data.API.ICatalog;

namespace Tests.ServiceTest
{
    internal class Catalog : Data.API.ICatalog
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

        public CatalogTest()
        {
            dataRepository = IDataRepository.CreateDataRepository(new TestFillStatic());
            service = IService.CreateService(dataRepository);
        }

        [TestMethod]

        public void AddCatalogTest()
        {
            Assert.IsTrue(service.GetAllCatalogs().ToList().Count == 3);
            service.AddCatalog(new Catalog("Henryk Sienkiewicz", "W pustyni i w puszczy"));
            Assert.IsTrue(service.GetAllCatalogs().ToList().Count == 4);
        }
        [TestMethod]
        public void UpdateCatalogTest()
        {
            Assert.IsTrue(service.GetCatalog(1).Title.Equals("Heart of Darkness"));
            ICatalog c4 = new Catalog("Jan Kochanowski", "Treny");
            service.UpdateCatalog(1, c4);
            Assert.IsTrue(service.GetCatalog(1).Title.Equals("Treny"));
        }
        [TestMethod]
        public void DeleteCatalog()
        {
            service.AddCatalog(new Catalog("Henryk Sienkiewicz", "W pustyni i w puszczy"));
            Assert.IsTrue(service.GetAllCatalogs().ToList().Count == 4);
            service.DeleteCatalog(3);
            Assert.IsTrue(service.GetAllCatalogs().ToList().Count == 3);
        }
    }
}
