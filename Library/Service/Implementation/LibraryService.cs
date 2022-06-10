using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;
using Data.API;
using System.Collections;
using ICatalog = Data.API.ICatalog;
using IReader = Data.API.IReader;

namespace Service.Implementation
{
    internal class LibraryService : IService
    {
        
        private IDataRepository DataRepository;
        internal LibraryService(IDataRepository dataRepository)
        {
            this.DataRepository = dataRepository;
        }

        public override void AddCatalog(ICatalog catalog)
        {
            DataRepository.AddCatalog(catalog);
        }

        public override void AddReader(Data.API.IReader reader)
        {
            DataRepository.AddReader(reader);
        }

        public override void DeleteCatalog(int index)
        {
            DataRepository.DeleteCatalog(index);
        }

        public override void DeleteCatalog(string author, string title)
        {
            DataRepository.DeleteCatalog(author, title);
        }

        public override void DeleteReader(int id)
        {
            DataRepository.DeleteReader(id);
        }

        public override IEnumerable<API.ICatalog> GetAllCatalogs()
        {
            var catalogs = DataRepository.GetAllCatalogs();
            var catalogList = new List<API.ICatalog>();

            foreach (var catalog in catalogs)
            {
                Catalog catalog1 = new Catalog(catalog.Author, catalog.Title);
                catalogList.Add((API.ICatalog)catalog1);
            }
            return catalogList;
        }

        public override IEnumerable<API.IReader> GetAllReaders()
        {
            var readers = DataRepository.GetAllReaders();
            var readersList = new List<API.IReader>();

            foreach (var reader in readers)
            {
                Reader reader1 = new Reader(reader.ReaderID, reader.Name, reader.Surname);
                readersList.Add((API.IReader)reader1);
            }

            return readersList;
        }

        public override API.ICatalog GetCatalog(string author, string title)
        {
            return (API.ICatalog)DataRepository.GetCatalog(author, title);
        }

        public override API.ICatalog GetCatalog(int index)
        {
            return (API.ICatalog)DataRepository.GetCatalog(index);
        }

        public override API.IReader GetReader(int id)
        {
            return (API.IReader)DataRepository.GetReader(id);
        }
        public override IBook RentBook(string author, string title, Data.API.IReader reader)
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
        public override void ReturnBook(IBook book, Data.API.IReader reader)
        {
            if (reader.Books.Contains(book))
            {
                book.Catalog.Books.Add(book);
                reader.Books.Remove(book);
            }
        }

        public override void UpdateCatalog(int index, ICatalog catalog)
        {
            DataRepository.UpdateCatalog(index, catalog);
        }

        public override void UpdateCatalog(string author, string title, ICatalog catalog)
        {
            DataRepository.UpdateCatalog(author, title, catalog);
        }

        public override void UpdateReader(int id, IReader reader)
        {
            DataRepository.UpdateReader(id, reader);
        }
        
    }
}
