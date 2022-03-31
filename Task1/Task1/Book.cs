using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Book
    {
        public Catalog Catalog { get; set; }
        public int BookID { get; set; }
        public Book(Catalog catalog, int id)
        {
            Catalog = catalog;
            BookID = id;
        }
    }
}
