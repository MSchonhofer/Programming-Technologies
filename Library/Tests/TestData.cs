using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    internal class Reader : IReader
    {
        public int ReaderID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Reader(int readerID, string name, string surname)
        {
            ReaderID = readerID;
            Name = name;
            Surname = surname;
        }
    }

    internal class Action : IAction
    {
        public int ActionID { get; set; }
        public int? CatalogID { get; set; }
        public int? ReaderID { get; set; }

        public Action(int actionID, int? catalogID, int? readerID)
        {
            ActionID = actionID;
            CatalogID = catalogID;
            ReaderID = readerID;
        }
    }

    internal class Catalog : ICatalog
    {
        public int CatalogID { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }

        public Catalog(int id, string author, string title)
        {
            CatalogID = id;
            Author = author;
            Title = title;
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
            Assert.IsTrue(dataRepository.GetAllCatalogs().ToList().Count == 12);
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 3);
            Assert.IsTrue(dataRepository.GetAllActions().ToList().Count == 8);


            Assert.IsTrue(dataRepository.GetCatalogByID(1).Author.Equals("Dostoevsky"));
            Assert.IsTrue(dataRepository.GetCatalogByTitle("Crime and Punishment").Author.Equals("Dostoevsky"));


            Assert.IsTrue(dataRepository.GetReader(1).Name.Equals("Jack"));
            Assert.IsTrue(dataRepository.GetReader(1).Surname.Equals("Smith"));

            Assert.IsTrue(dataRepository.GetAction(1).CatalogID == 1);
            Assert.IsTrue(dataRepository.GetAction(1).ReaderID == 1);
        }


        [TestMethod]
        public void ReaderTest()
        {

            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 3);
            dataRepository.AddReader(4, "Morgan", "Welsh");
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 4);
            dataRepository.AddReader(5, "Cole", "Miller");
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 5);

            Assert.IsTrue(dataRepository.GetReader(5).Name.Equals("Cole"));
            Assert.IsTrue(dataRepository.GetReader(5).Surname.Equals("Miller"));

            dataRepository.DeleteReader(5);
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 4);

            dataRepository.UpdateReader(4, "Nick", "Jones");

            Assert.IsTrue(dataRepository.GetReader(4).Name.Equals("Nick"));
            Assert.IsTrue(dataRepository.GetReader(4).Surname.Equals("Jones"));
            Assert.IsTrue(dataRepository.GetAllReaders().ToList().Count == 4);
        }


        [TestMethod]
        public void CatalogTest()
        {

            Assert.IsTrue(dataRepository.GetAllCatalogs().ToList().Count == 12);
            dataRepository.AddCatalog(13, "test1", "test2");
            Assert.IsTrue(dataRepository.GetAllCatalogs().ToList().Count == 13);

            Assert.IsTrue(dataRepository.GetCatalogByID(13).Author.Equals("test1"));
            Assert.IsTrue(dataRepository.GetCatalogByID(13).Title.Equals("test2"));

            dataRepository.UpdateCatalog(13, "test1", "hello");
            Assert.IsTrue(dataRepository.GetCatalogByID(13).Title.Equals("hello"));

            dataRepository.DeleteCatalog(13);
            Assert.IsTrue(dataRepository.GetAllCatalogs().ToList().Count == 12);

        }

        [TestMethod]
        public void ActionTest()
        {
            Assert.IsTrue(dataRepository.GetAllActions().ToList().Count == 8);
            dataRepository.AddAction(9, 2, 2);
            Assert.IsTrue(dataRepository.GetAllActions().ToList().Count == 9);
        }
    }
}
