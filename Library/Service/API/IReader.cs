using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Service.API
{
    public interface IReader
    {
        
        string Name { get; set; }
        string Surname { get; set; }
        int ReaderID { get; set; }
        List<IBook> Books { get; set; }
    
    }
}
