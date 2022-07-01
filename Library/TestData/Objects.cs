using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.API;
using System;

namespace TestData
{
    internal class TestReader : IReader
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ReaderID { get; set; }
        public TestReader(int readerID, string name, string surname)
        {
            ReaderID = readerID;
            Name = name;
            Surname = surname;
        }
    }
    internal class TestCatalog : ICatalog
    {
        public int CatalogID { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }

        public TestCatalog(int id, string author, string title)
        {
            CatalogID = id;
            Author = author;
            Title = title;
        }
    }
    internal class TestAction : IAction
    {
        public int ActionID { get; set; }
        public int? CatalogID { get; set; }
        public int? ReaderID { get; set; }

        public TestAction(int actionID, int? catalogID, int? readerID)
        {
            ActionID = actionID;
            CatalogID = catalogID;
            ReaderID = readerID;
        }
    }
}