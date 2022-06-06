using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;
using Data.API;
using System.Collections;
using ICatalog = Data.API.ICatalog;

namespace Service.Implementation
{
    internal class LibraryService : IService
    {
        private IDataRepository DataRepository;
        internal LibraryService(IDataRepository dataRepository)
        {
            this.DataRepository = dataRepository;
        }

        public void AddCatalog(ICatalog catalog)
        {
            DataRepository.AddCatalog(catalog);
        }

        public void AddReader(Data.API.IReader reader)
        {
            DataRepository.AddReader(reader);
        }

        public void DeleteCatalog(int index)
        {
            DataRepository.DeleteCatalog(index);
        }

        public void DeleteCatalog(string author, string title)
        {
            DataRepository.DeleteCatalog(author, title);
        }

        public void DeleteReader(int id)
        {
            DataRepository.DeleteReader(id);
        }

        public IEnumerable<API.ICatalog> GetAllCatalogs()
        {
            var catalogs = DataRepository.GetAllCatalogs();
            var catalogList = new List<API.ICatalog>();

            foreach (var catalog in catalogs)
            {
                catalogList.Add(new Catalog(catalog.Author, catalog.Title));
            }
            return catalogList;
        }

        public IEnumerable GetAllReaders()
        {
            var readers = DataRepository.GetAllReaders();
            var readersList = new List<API.Readers>();

            foreach (var reader in readers)
            {
                readersList.Add(new Reader(reader.ReaderID, reader.Name, reader.Surname));
            }

            return readersList;
        }

        public API.ICatalog GetCatalog(string author, string title)
        {
            return (API.ICatalog)DataRepository.GetCatalog(author, title);
        }

        public API.ICatalog GetCatalog(int index)
        {
            return (API.ICatalog)DataRepository.GetCatalog(index);
        }

        public API.IReader GetReader(int id)
        {
            return (API.IReader)DataRepository.GetReader(id);
        }
        public IBook RentBook(string author, string title, API.IReader reader)
        {
            ICatalog catalog = DataRepository.GetCatalog(author, title);
            IBook book = DataRepository.GetBook(catalog);
            if (book != null)
            {
                catalog.Books.Remove(book);
                reader.Books.Add(book);
            }
            return book;
        }
        public void ReturnBook(IBook book, API.IReader reader)
        {
            if (reader.Books.Contains(book))
            {
                book.Catalog.Books.Add(book);
                reader.Books.Remove(book);
            }
        }

        public void UpdateCatalog(int index, ICatalog catalog)
        {
            DataRepository.UpdateCatalog(index, catalog);
        }

        public void UpdateCatalog(string author, string title, ICatalog catalog)
        {
            DataRepository.UpdateCatalog(author, title, catalog);
        }

        public void UpdateReader(int id, IReader reader)
        {
            DataRepository.UpdateReader(id, reader);
        }

        public void UpdateReader(int id, Data.API.IReader reader)
        {
            throw new NotImplementedException();
        }
    }
