using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface IService
    {
        // catalogs
        Task<ICatalog> AddCatalog(ICatalog catalog);
        Task<ICatalog> UpdateCatalog(int index, ICatalog catalog);
        Task<ICatalog> DeleteCatalog(int index);
        Task<ICatalog> GetCatalog(int index);
        Task<ICatalog> GetCatalog(string author, string title);
        Task<ICatalog> DeleteCatalog(string author, string title);
        Task<ICatalog> UpdateCatalog(string author, string title, ICatalog catalog);
        Task<IEnumerable<ICatalog>> GetAllCatalogs();

        // readers

        Task<IReader> AddReader(IReader reader);
        Task<IReader> UpdateReader(int id, IReader reader);
        Task<IReader> DeleteReader(int id);
        Task<IReader> GetReader(int id);
        Task<IEnumerable> GetAllReaders();

        // rent

        Task<IRentBook> RentBook(IRentBook book);
    }
}
