using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Presentation.Model.Implementation
{
    public class CatalogModelView : ICatalogModelView
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public List<IBook> Books { get; set; }
        public CatalogModelView(string author, string name)
        {
            Author = author;
            Title = name;
            Books = new List<IBook>();
        }
    }
}
