using System;
using System.Collections.Generic;
using System.Text;

namespace Data
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
