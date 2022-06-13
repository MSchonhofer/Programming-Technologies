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
    [TestClass]
    public class ReturnTest
    {
        private IDataRepository? dataRepository;
        private IService? service;

        public ReturnTest()
        {
            dataRepository = IDataRepository.CreateDataRepository(new TestFillStatic());
            service = IService.CreateService(dataRepository);
        }
        [TestMethod]

        public void ReturnBookTest()
        {
            ICatalog c1 = service.GetCatalog(0);
            IBook book = new Book(c1, 1);
            Data.API.IReader r2 = service.GetReader(2);
            Assert.IsTrue(service.GetReader(2).Books.Count == 3);
            service.RentBook("Dostoevsky", "Crime and Punishment", r2);
            Assert.IsTrue(service.GetReader(2).Books.Count == 4);
            service.ReturnBook(book, r2);
            Assert.IsTrue(service.GetReader(2).Books.Count == 4);
        }
    }
}
