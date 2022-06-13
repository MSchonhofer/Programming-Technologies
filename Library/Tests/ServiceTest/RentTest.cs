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
    internal class Book : IBook
    {
        public Data.API.ICatalog Catalog { get; set; }
        public int BookID { get; set; }
        Data.API.ICatalog IBook.Catalog { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Book(Data.API.ICatalog catalog, int id)
        {
            Catalog = catalog;
            BookID = id;
        }
    }
    [TestClass]
    public class RentTest
    {
        private IDataRepository? dataRepository;
        private IService? service;

        public RentTest()
        {
            dataRepository = IDataRepository.CreateDataRepository(new TestFillStatic());
            service = IService.CreateService(dataRepository);
        }
        [TestMethod]

        public void RentBookTest()
        {
            ICatalog c1 = service.GetCatalog(0);
            IBook book = new Book(c1, 1);
            Data.API.IReader r2 = service.GetReader(2);
            Assert.IsTrue(service.GetReader(2).Books.Count == 3);
            service.RentBook("Dostoevsky", "Crime and Punishment", r2);
            Assert.IsTrue(service.GetReader(2).Books.Count == 4);
        } 
    }
}
