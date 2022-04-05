using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class TestData
    {
        private DataRepository dataRepository;

        [TestInitialize]

        public void Fill()
        {
            dataRepository = new DataRepository(new TestFillStatic());
        }

        [TestMethod]
        public void FillTest()
        {
            Assert.IsTrue(dataRepository.GetAllCatalogs().ToList().Count == 3);
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 2);
            Assert.IsTrue(dataRepository.GetAllActions().ToList().Count == 0);


            Assert.IsTrue(dataRepository.GetCatalog(0).Author.Equals("Dostoevsky"));
            Assert.IsTrue(dataRepository.GetCatalog(0).Title.Equals("Crime and Punishment"));
            Assert.IsTrue(dataRepository.GetCatalog(0).Books.Count == 4);
            Assert.IsTrue(dataRepository.GetCatalog(0).Books[0].BookID == 001);


            Assert.IsTrue(dataRepository.GetReader(1).Name.Equals("Jack"));
            Assert.IsTrue(dataRepository.GetReader(1).Surname.Equals("Smith"));
            Assert.IsTrue(dataRepository.GetReader(1).ReaderID == 1);
            Assert.IsTrue(dataRepository.GetReader(1).Books.Count == 2);
            Assert.IsTrue(dataRepository.GetReader(1).Books[0].BookID == 010);
        }
    }
}