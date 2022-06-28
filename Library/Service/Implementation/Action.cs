using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    internal class Action : IAction
    {
        public int ActionID { get; set; }
        public int? CatalogID { get; set; }
        public int? ReaderID { get; set; }

        public Action(int actionID, int? catalogID, int? readerID)
        {
            ActionID = actionID;
            CatalogID = catalogID;
            ReaderID = readerID;
        }
    }
}
