using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;
using Data.API;


namespace Tests.ServiceTest
{
    internal class Reader : Data.API.IReader
    {
        public int ReaderID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<IBook> Books { get; set; }
        public Reader(int readerID, string name, string surname)
        {
            ReaderID = readerID;
            Name = name;
            Surname = surname;
            Books = new List<IBook>();
        }
    }
    
    [TestClass]
    public class ReaderTest
    {
        private IDataRepository? dataRepository;
        private IService? service;

        public ReaderTest()
        {
            dataRepository = IDataRepository.CreateDataRepository(new TestFillStatic());
            service = IService.CreateService(dataRepository);
        }
        [TestMethod]
        public void AddReaderTest()
        {
            service.AddReader(new Reader(4, "Jan", "Kowalski"));
            Assert.IsTrue(service.GetAllReaders().ToList().Count == 4);
            service.AddReader(new Reader(5, "Marianna", "Nowak"));
            Assert.IsTrue(service.GetAllReaders().ToList().Count == 5);
        }
        [TestMethod]
        public void UpdateReaderTest()
        {
            Assert.IsTrue(service.GetReader(1).Name.Equals("Jack"));
            Data.API.IReader reader = new Reader(1, "Jeremiasz", "Pazura");
            service.UpdateReader(1, reader);
            Assert.IsTrue(service.GetReader(1).Name == reader.Name);
        }
        [TestMethod]
        public void DeleteReaderTest()
        {
            service.AddReader(new Reader(1, "Jan", "Kowalski"));
            Assert.IsTrue(service.GetAllReaders().ToList().Count == 4);
            service.DeleteReader(1);
            Assert.IsTrue(service.GetAllReaders().ToList().Count == 3);
        }


    }
}
    
