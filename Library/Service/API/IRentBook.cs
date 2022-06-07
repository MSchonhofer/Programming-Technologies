using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Service.API
{
    public interface IRentBook
    {
        public IBook RentBook(string author, string title, IReader reader);
    
    }
}
