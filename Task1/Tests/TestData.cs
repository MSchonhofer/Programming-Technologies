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
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 3);
            Assert.IsTrue(dataRepository.GetAllActions().ToList().Count == 0);


            Assert.IsTrue(dataRepository.GetCatalog(0).Author.Equals("Dostoevsky"));
            Assert.IsTrue(dataRepository.GetCatalog(0).Title.Equals("Crime and Punishment"));
            Assert.IsTrue(dataRepository.GetCatalog(0).Books.Count == 4);
            Assert.IsTrue(dataRepository.GetCatalog(0).Books[0].BookID == 1);


            Assert.IsTrue(dataRepository.GetReader(1).Name.Equals("Jack"));
            Assert.IsTrue(dataRepository.GetReader(1).Surname.Equals("Smith"));
            Assert.IsTrue(dataRepository.GetReader(1).ReaderID == 1);
            Assert.IsTrue(dataRepository.GetReader(1).Books.Count == 3);
            Assert.IsTrue(dataRepository.GetReader(1).Books[0].BookID == 14);
        }


        [TestMethod]
        public void BookTest()

        {
            Catalog catalog = dataRepository.GetCatalog(0);

            Assert.IsTrue(dataRepository.GetBook(catalog).Catalog.Author.Equals("Dostoevsky"));
            Assert.IsTrue(dataRepository.GetBook(catalog).Catalog.Title.Equals("Crime and Punishment"));
            Assert.IsTrue(dataRepository.GetBook(catalog).Catalog.Books.Count == 4);
            Assert.IsTrue(dataRepository.GetBook(catalog).Catalog.Books[0].BookID == 1);
        }

        [TestMethod]
        public void ReaderTest()
        {

            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 3);
            dataRepository.AddReader(new Reader(90, "test10", "test20"));
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 4);
            dataRepository.AddReader(new Reader(91, "test11", "test21"));
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 5);

            Assert.IsTrue(dataRepository.GetReader(91).Name.Equals("test11"));
            Assert.IsTrue(dataRepository.GetReader(91).Surname.Equals("test21"));
            Assert.IsTrue(dataRepository.GetReader(91).ReaderID == 91);

            Catalog catalog = dataRepository.GetCatalog(0);
            Assert.IsTrue(dataRepository.GetBook(catalog).Catalog.Author.Equals("Dostoevsky"));
            Assert.IsTrue(dataRepository.GetBook(catalog).Catalog.Title.Equals("Crime and Punishnment"));
            Assert.IsTrue(dataRepository.GetBook(catalog).Catalog.Books.Count == 4);
            Assert.IsTrue(dataRepository.GetBook(catalog).Catalog.Books[0].BookID == 1);


            dataRepository.DeleteReader(91);
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 4);


            Reader reader = new Reader(99, "test99a", "test99b");
            dataRepository.UpdateReader(90, reader);

            Assert.IsTrue(dataRepository.GetReader(99).Name.Equals("test99a"));
            Assert.IsTrue(dataRepository.GetReader(99).Surname.Equals("test99b"));
            Assert.IsTrue(dataRepository.GetReader(99).ReaderID == 99);
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 4);
        }


        [TestMethod]
        public void CatalogTest()
        {

            Assert.IsTrue(dataRepository.GetAllCatalogs().ToList().Count == 3);
            dataRepository.AddCatalog(new Catalog("test1", "test2"));
            Assert.IsTrue(dataRepository.GetAllCatalogs().ToList().Count == 4);

            Assert.IsTrue(dataRepository.GetCatalog(3).Author.Equals("test1"));
            Assert.IsTrue(dataRepository.GetCatalog(3).Title.Equals("test2"));

            dataRepository.DeleteCatalog(1);
            Assert.IsTrue(dataRepository.GetAllCatalogs().ToList().Count == 3);

        }
    }
}
