using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.Implementation
{
    internal class Catalog : ICatalog
    {
        public String Author { get; set; }
        public String Title { get; set; }
        public List<IBook> Books { get; set; }

        public Catalog(string author, string title)
        {
            Author = author;
            Title = title;
            Books = new List<IBook>();
        }
    }
}

