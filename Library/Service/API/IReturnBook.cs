using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Service.API
{
    public interface IReturnBook
    {
        public void ReturnBook(IBook book, IReader reader);
     
    }
}
