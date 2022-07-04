using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.Implementation;
using static Data.API.IDataRepository;

namespace Service.API
{
    public abstract class IService
    {
        //catalogs
        public abstract void AddCatalog(int id, string author, string title);
        public abstract ICatalog GetCatalogByTitle(string title);
        public abstract IEnumerable<ICatalog> GetCatalogByAuthor(string author);
        public abstract ICatalog GetCatalogByID(int id);
        public abstract IEnumerable<ICatalog> GetAllCatalogs();
        public abstract void UpdateCatalog(int id, string author, string name);
        public abstract void DeleteCatalog(int id);
        //readers
        public abstract void AddReader(int id, string name, string surname);
        public abstract IReader GetReader(int id);
        public abstract void UpdateReader(int id, string name, string surname);
        public abstract void DeleteReader(int id);
        public abstract IEnumerable<IReader> GetAllReaders();
        //actions
        public abstract void AddAction(int id, int cID, int rID);
        public abstract IAction GetAction(int id);
        public abstract IEnumerable<IAction> GetAllActions();

        public static IService CreateService(IDataRepository? dataRepository = default)
        {
            return new LibraryService(dataRepository ?? DataRepositoryFactory.CreateDataRepository());
        }
    }
}
