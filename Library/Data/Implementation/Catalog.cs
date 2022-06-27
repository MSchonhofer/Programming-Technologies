using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Data.Impl
{
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
}
