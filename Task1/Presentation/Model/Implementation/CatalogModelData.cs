using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Presentation.Model.Implementation
{
    public class CatalogModelData : ICatalogModelData
    {
        public IService service { get; }
        public CatalogModelData(IService service)
        {
            this.service = service;
        }
        public IEnumerable<ICatalog> Catalogs
        {
            get
            {
                IEnumerable<ICatalog> catalogs = service.GetAllCatalogs();
                return catalogs;
            }
        }
        public ICatalogModelView CreateCatalog(string author, string title)
        {
            return new CatalogModelView(author, title);
        }
    }
}
