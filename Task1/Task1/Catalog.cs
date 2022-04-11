using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    [Serializable]
    public class Catalog
    {
        public String Author { get; set; }
        public String Title { get; set; }
        public List<Book> Books { get; set; }

        public Catalog(string author, string title)
        {
            Author = author;
            Title = title;
            Books = new List<Book>();
        }
    }
}
