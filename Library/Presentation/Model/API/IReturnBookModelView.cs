using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IReturnBookModelView
    {
        void ReturnBook(IBook book, IReader reader);
    }
}
