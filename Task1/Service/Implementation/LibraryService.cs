using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;
using Data.API;
using System.Collections;

namespace Service.Implementation
{
    internal class LibraryService : IService
    {
        private IDataRepository DataRepository;
        internal LibraryService(IDataRepository dataRepository)
        {
            this.DataRepository = dataRepository;
        }

        public async Task AddCatalog(API.ICatalog catalog)
        {
            await Task DataRepository.AddCatalog(new Catalog(catalog.Author, catalog.Title));
        }

        public async Task AddReader(API.IReader reader)
        {
            await DataRepository.AddReader(new Reader(reader.ReaderID, reader.Name, reader.Surname)); 
        }

        public async Task DeleteCatalog(int index)
        {
            return DataRepository.DeleteCatalog(index);
        }

        public Task DeleteCatalog(string author, string title)
        {
            return DataRepository.DeleteCatalog(author, title);
        }

        public Task DeleteReader(int id)
        {
            return DataRepository.DeleteReader(id);
        }

        // to be done
        public Task DeleteRent(string id)
        {
            throw new NotImplementedException();
        }

        // to be done
        public Task DeleteReturn(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<API.ICatalog>> GetAllCatalogs()
        {
            return DataRepository.GetAllCatalogs();
        }

        public Task<IEnumerable> GetAllReaders()
        {
            return DataRepository.GetAllReaders();
        }

        public Task GetCatalog(int index)
        {
            throw new NotImplementedException();
        }

        public Task GetCatalog(string author, string title)
        {
            throw new NotImplementedException();
        }

        public Task GetReader(int id)
        {
            throw new NotImplementedException();
        }

        public Task RentBook(API.IRentBook book)
        {
            throw new NotImplementedException();
        }

        public Task ReturnBook(API.IReturnBook book)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCatalog(int index, API.ICatalog catalog)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCatalog(string author, string title, API.ICatalog catalog)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReader(int id, API.IReader reader)
        {
            throw new NotImplementedException();
        }
    }


}
