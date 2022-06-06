using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.Implementation;

namespace Service.API
{
    public interface IService
    {
        #region Catalog
        void AddCatalog(Data.API.ICatalog catalog);
        ICatalog GetCatalog(string author, string title);
        ICatalog GetCatalog(int index);
        IEnumerable<ICatalog> GetAllCatalogs();
        void UpdateCatalog(int index, Data.API.ICatalog catalog);
        void UpdateCatalog(string author, string title, Data.API.ICatalog catalog);
        void DeleteCatalog(int index);
        void DeleteCatalog(string author, string title);

        #endregion

        #region Reader
        void AddReader(Data.API.IReader reader);
        void UpdateReader(int id, Data.API.IReader reader);
        void DeleteReader(int id);
        IReader GetReader(int id);
        IEnumerable GetAllReaders();
        #endregion

        #region Rent
        IBook RentBook(string author, string title, IReader reader);
        #endregion

        #region Return
        void ReturnBook(IBook book, IReader reader);
        #endregion

        public static IService CreateService(IDataRepository? dataRepository = default)
        {
            return new LibraryService(dataRepository ?? IDataRepository.CreateDataRepository());
        }
    }
}
