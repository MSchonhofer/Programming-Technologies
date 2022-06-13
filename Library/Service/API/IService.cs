using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.Implementation;

namespace Service.API
{
    public abstract class IService
    {
        #region Catalog
        public abstract void AddCatalog(Data.API.ICatalog catalog);
        public abstract ICatalog GetCatalog(string author, string title);
        public abstract ICatalog GetCatalog(int index);
        public abstract IEnumerable<ICatalog> GetAllCatalogs();
        public abstract void UpdateCatalog(int index, Data.API.ICatalog catalog);
        public abstract void UpdateCatalog(string author, string title, Data.API.ICatalog catalog);
        public abstract void DeleteCatalog(int index);
        public abstract void DeleteCatalog(string author, string title);

        #endregion

        #region Reader
        public abstract void AddReader(Data.API.IReader reader);
        public abstract void UpdateReader(int id, Data.API.IReader reader);
        public abstract void DeleteReader(int id);
        public abstract Data.API.IReader GetReader(int id);
        public abstract IEnumerable<IReader> GetAllReaders();
        #endregion

        #region RentBook
        public abstract IBook RentBook(string author, string title, Data.API.IReader reader);
        #endregion

        #region ReturnBook
        public abstract void ReturnBook(IBook book, Data.API.IReader reader);
        #endregion

        public static IService CreateService(IDataRepository? dataRepository = default)
        {
            return new LibraryService(dataRepository ?? IDataRepository.CreateDataRepository());
        }
    }
}
