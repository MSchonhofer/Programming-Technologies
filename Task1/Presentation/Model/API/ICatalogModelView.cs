using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model
{
    public interface ICatalogModelView
    {
        string Author { get; set; }
        string Title { get; set; }
        List<IBook> Books { get; set; }
    }
}
