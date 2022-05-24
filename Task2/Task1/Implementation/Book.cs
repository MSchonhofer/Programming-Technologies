using System;
using System.Collections.Generic;
using System.Text;
using Data.API;

namespace Data.Impl
{
    internal class Book : IBook
    {
        public ICatalog Catalog { get; set; }
        public int BookID { get; set; }
        public Book(ICatalog catalog, int id)
        {
            Catalog = catalog;
            BookID = id;
        }
    }
}
