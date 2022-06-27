using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IAction
    {
        int ActionID { get; set; }
        int? CatalogID { get; set; }
        int? ReaderID { get; set; }
    }
}
