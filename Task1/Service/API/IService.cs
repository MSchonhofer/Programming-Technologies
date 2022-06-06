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
        // catalogs
        Task AddCatalog(ICatalog catalog);
        Task UpdateCatalog(int index, ICatalog catalog);
        Task DeleteCatalog(int index);
        Task GetCatalog(int index);
        Task GetCatalog(string author, string title);
        Task DeleteCatalog(string author, string title);
        Task UpdateCatalog(string author, string title, ICatalog catalog);
        Task<IEnumerable<ICatalog>> GetAllCatalogs();

        // readers

        Task AddReader(IReader reader);
        Task UpdateReader(int id, IReader reader);
        Task DeleteReader(int id);
        Task GetReader(int id);
        Task<IEnumerable> GetAllReaders();

        // rent

        Task RentBook(IRentBook book);
        Task DeleteRent(string id);

        // return
        Task ReturnBook(IReturnBook book);
        Task DeleteReturn(string id);

        public static IService CreateService(IDataRepository? dataRepository = default)
        {
            return new LibraryService(dataRepository ?? IDataRepository.CreateDataRepository());
        }
    }
}
