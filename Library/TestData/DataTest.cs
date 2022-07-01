using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Data.API.IDataRepository;

namespace TestData
{
    [TestClass]
    public class DataTest
    {
        private IDataRepository dataRepository;
        public DataTest()
        {
            dataRepository = DataRepositoryFactory.CreateDataRepository();
        }
        [TestMethod]
        public void TestConnection()
        {
            //IDataRepository dataRepository = DataRepositoryFactory.CreateDataRepository();
            int id = 1;
            dataRepository.AddCatalog(id, "Tolkien", "Lord of Rings");
            IEnumerable<ICatalog> dbCatalog = dataRepository.GetAllCatalogs().Where(c => c.CatalogID == id);
            ICatalog catalog = dbCatalog.First();
            Assert.Equals("Lord of Rings", catalog.Title);

            int rID = 1;
            dataRepository.AddReader(rID, "Jan", "Kowalski");
            IEnumerable<IReader> dbReader = dataRepository.GetAllReaders().Where(r => r.ReaderID == rID);
            IReader reader = dbReader.First();
            Assert.Equals("Jan", reader.Name);

            int aID = 1;
            dataRepository.AddAction(aID,id, rID);
            IEnumerable<IAction> dbActions = dataRepository.GetAllActions().Where(a => a.ActionID == aID);
            IAction action = dbActions.First();
            Assert.Equals(rID, action.ReaderID);
        }
        [TestMethod]
        public void TestRemoving()
        {
           // IDataRepository dataRepository = DataRepositoryFactory.CreateDataRepository();
            int id = 1;
            dataRepository.AddCatalog(id, "Tolkien", "Lord of Rings");
            IEnumerable<ICatalog> catalogs = dataRepository.GetAllCatalogs().ToList();
            Assert.Equals(catalogs, 1);
            dataRepository.DeleteCatalog(id);
            Assert.Equals(catalogs, 0);

            int rID = 1;
            dataRepository.AddReader(rID, "Jan", "Kowalski");
            IEnumerable<IReader> dbReader = dataRepository.GetAllReaders().ToList();
            Assert.Equals(dbReader, 1);
            dataRepository.DeleteReader(rID);
            Assert.Equals(dbReader, 0);
        }
        [TestMethod]
        public void TestUpdating()
        {
            //IDataRepository dataRepository = DataRepositoryFactory.CreateDataRepository();
            int id = 1;
            dataRepository.AddCatalog(id, "Tolkien", "Lord of Rings");
            IEnumerable<ICatalog> dbCatalog = dataRepository.GetAllCatalogs().Where(c => c.CatalogID == id);
            ICatalog catalog = dbCatalog.First();
            Assert.Equals("Lord of Rings", catalog.Title);
            dataRepository.UpdateCatalog(id, "Dostoevsky", "Crime and Punishment");
            Assert.Equals("Crime and Punishment", catalog.Title);

            int rID = 1;
            dataRepository.AddReader(rID, "Jan", "Kowalski");
            IEnumerable<IReader> dbReader = dataRepository.GetAllReaders().Where(r => r.ReaderID == rID);
            IReader reader = dbReader.First();
            Assert.Equals("Jan", reader.Name);
            dataRepository.UpdateReader(rID, "Maria", "Nowak");
            Assert.Equals("Maria", reader.Name);
        }
    }
}
