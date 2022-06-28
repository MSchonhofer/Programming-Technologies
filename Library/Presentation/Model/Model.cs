using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.API;
using Service.API;

namespace Presentation.Model
{
    internal class Model : IModel
    {
        public IService service { get; }
        public Model(IService service)
        {
            this.service = service;
        }

        public IEnumerable<ICatalog> catalogsList
        {
            get
            {
                IEnumerable<ICatalog> catalogs = service.GetAllCatalogs();
                return catalogs;
            }
        }
        public IEnumerable<IReader> readersList
        {
            get
            {
                IEnumerable<IReader> readers = service.GetAllReaders();
                return readers;
            }
        }
        public IEnumerable<IAction> actionsList
        {
            get
            {
                IEnumerable<IAction> actions = service.GetAllActions();
                return actions;
            }
        }
        public ICatalogModelView CreateCatalog(int id, string author, string title)
        {
            return new CatalogModelView(id, author, title);
        }
        public IReaderModelView CreateReader(int id, string name, string surname)
        {
            return new ReaderModelView(id, name, surname);
        }
        public IActionModelView CreateAction(int id, int cID, int rID)
        {
            return new ActionModelView(id, cID, rID);
        }
    }
}
