using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.API;
using Data.Impl;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Text;

namespace Tests
{
    internal class Reader : IReader
    {
        public int ReaderID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<IBook> Books { get; set; }
        internal Reader(int readerID, string name, string surname)
        {
            ReaderID = readerID;
            Name = name;
            Surname = surname;
            Books = new List<IBook>();
        }
    }

    internal class Catalog : ICatalog
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
    public class TestData
    {
        private IDataRepository? dataRepository;

        [TestInitialize]
        public void Fill()
        {
          dataRepository = IDataRepository.CreateDataRepository(new TestFillStatic());
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
            ICatalog catalog = dataRepository.GetCatalog(0);

            Assert.IsTrue(dataRepository.GetBook(catalog).Catalog.Author.Equals("Dostoevsky"));
            Assert.IsTrue(dataRepository.GetBook(catalog).Catalog.Title.Equals("Crime and Punishment"));
            Assert.IsTrue(dataRepository.GetBook(catalog).Catalog.Books.Count == 4);
            Assert.IsTrue(dataRepository.GetBook(catalog).Catalog.Books[0].BookID == 1);
        }

       
        [TestMethod]
        public void ReaderTest()
        {

            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 3);
            dataRepository.AddReaderAsync(new Reader(90, "Morgan", "Welsh")); // tu trzeba poprawic
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 4);
            dataRepository.AddReaderAsync(new Reader(91, "Cole", "Miller")); // tu trzeba poprawic
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 5);

            Assert.IsTrue(dataRepository.GetReader(91).Name.Equals("Cole"));
            Assert.IsTrue(dataRepository.GetReader(91).Surname.Equals("Miller"));
            Assert.IsTrue(dataRepository.GetReader(91).ReaderID == 91);
            

            dataRepository.DeleteReader(91);
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 4);


           IReader r = new Reader(99, "Nick", "Jones"); // tu trzeba poprawic
            dataRepository.UpdateReader(90, r);

            Assert.IsTrue(dataRepository.GetReader(99).Name.Equals("Nick"));
            Assert.IsTrue(dataRepository.GetReader(99).Surname.Equals("Jones"));
            Assert.IsTrue(dataRepository.GetReader(99).ReaderID == 99);
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 4);
        } 


        [TestMethod]
        public void CatalogTest()
        {

            Assert.IsTrue(dataRepository.GetAllCatalogs().ToList().Count == 3);
            dataRepository.AddCatalogAsync(new Catalog("test1", "test2")); // to be changed 
            Assert.IsTrue(dataRepository.GetAllCatalogs().ToList().Count == 4);

            Assert.IsTrue(dataRepository.GetCatalog(3).Author.Equals("test1"));
            Assert.IsTrue(dataRepository.GetCatalog(3).Title.Equals("test2"));

            dataRepository.DeleteCatalog(1);
            Assert.IsTrue(dataRepository.GetAllCatalogs().ToList().Count == 3);

        }
    }
}
