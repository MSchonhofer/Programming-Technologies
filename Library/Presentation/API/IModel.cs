using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Presentation.API
{
    public interface IModel
    {
        IService service { get; }
        IEnumerable<ICatalog> catalogsList { get; }
        IEnumerable<IReader> readersList { get; }
        IEnumerable<IAction> actionsList { get; }
        ICatalogModelView CreateCatalog(int id, string author, string title);
        IReaderModelView CreateReader(int id, string name, string surname);
        IActionModelView CreateAction(int id, int cID, int rID);
    }
}
