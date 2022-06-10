using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IRentBookModelView
    {
        IBook RentBook(string author, string title, IReader reader);
    }
}
