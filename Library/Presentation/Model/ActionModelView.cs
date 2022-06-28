using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.API;

namespace Presentation.Model
{
    internal class ActionModelView : IActionModelView
    {
        public int ActionID { get; set; }
        public int? CatalogID { get; set; }
        public int? ReaderID { get; set; }
        public ActionModelView(int id, int cID, int rID)
        {
            ActionID = id;
            CatalogID = cID;
            ReaderID = rID;
        }
    }
}
