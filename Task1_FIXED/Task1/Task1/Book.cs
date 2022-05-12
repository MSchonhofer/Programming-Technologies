using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class IBook
    {
        public ICatalog Catalog { get; set; }
        public int BookID { get; set; }
        public IBook(ICatalog catalog, int id)
        {
            Catalog = catalog;
            BookID = id;
        }
    }
}
