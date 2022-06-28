using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.API;

namespace Presentation.Model
{
    internal class CatalogModelView : ICatalogModelView
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int CatalogID { get; set; }
        public CatalogModelView(int id, string author, string title)
        {
            CatalogID = id;
            Title = title;
            Author = author;
        }
    }
}
