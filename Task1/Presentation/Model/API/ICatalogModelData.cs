using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Presentation.Model
{
    public interface ICatalogModelData
    {
        IService service { get; }
        IEnumerable<ICatalog> Catalogs { get; }
        ICatalogModelView CreateCatalog(string author, string title);
    }
}
