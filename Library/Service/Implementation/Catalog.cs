using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.API;
using ICatalog = Service.API.ICatalog;

namespace Service.Implementation
{
    internal class Catalog : ICatalog
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int CatalogID { get; set; }
        public Catalog(int id, string author, string title)
        {
            CatalogID = id;
            Author = author;
            Title = title;
        }
    }
}
