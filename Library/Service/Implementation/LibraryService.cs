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

        public Service.API.ICatalog Transfer(Data.API.ICatalog catalog)
        {
            if (catalog == null)
            {
                return null;
            }
            return new Catalog(catalog.CatalogID, catalog.Author, catalog.Title);
        }

        public Service.API.IReader Transfer(Data.API.IReader reader)
        {
            if (reader == null)
            {
                return null; 
            }
            return new Reader(reader.ReaderID, reader.Name, reader.Surname);
        }

        public Service.API.IAction Transfer(Data.API.IAction action)
        {
            if (action == null)
            {
                return null;
            }
            return new Action(action.ActionID, action.CatalogID, action.ReaderID);
        }

        public override void AddAction(int id, int cID, int rID)
        {
            DataRepository.AddAction(id, cID, rID);
        }

        public override void AddCatalog(int id, string author, string title)
        {
            DataRepository.AddCatalog(id, author, title);
        }

        public override void AddReader(int id, string name, string surname)
        {
            DataRepository.AddReader(id, name, surname);
        }

        public override void DeleteCatalog(int id)
        {
            DataRepository.DeleteCatalog(id);
        }

        public override void DeleteReader(int id)
        {
            DataRepository.DeleteReader(id);
        }

        public override API.IAction GetAction(int id)
        {
            return Transfer(DataRepository.GetAction(id));
        }

        public override IEnumerable<API.IAction> GetAllActions()
        {
            var actions = DataRepository.GetAllActions();
            var listOfActions = new List<API.IAction>();
            foreach (var action in actions)
            {
                listOfActions.Add(Transfer(action));
            }
            return listOfActions;
        }

        public override IEnumerable<API.ICatalog> GetAllCatalogs()
        {
            var catalogs = DataRepository.GetAllCatalogs();
            var listOfCatalogs = new List<API.ICatalog>();
            foreach (var catalog in catalogs)
            {
                listOfCatalogs.Add(Transfer(catalog));
            }
            return listOfCatalogs;
        }

        public override IEnumerable<API.IReader> GetAllReaders()
        {
            var readers = DataRepository.GetAllReaders();
            var listOfReaders = new List<API.IReader>();
            foreach (var reader in readers)
            {
                listOfReaders.Add(Transfer(reader));
            }
            return listOfReaders;
        }

        public override IEnumerable<API.ICatalog> GetCatalogByAuthor(string author)
        {
            var booksByAuthor = DataRepository.GetCatalogByAuthor(author);
            var listOfBooks = new List<API.ICatalog>();
            foreach(var book in booksByAuthor)
            {
                listOfBooks.Add(Transfer(book));
            }
            return listOfBooks;
        }

        public override API.ICatalog GetCatalogByID(int id)
        {
            return Transfer(DataRepository.GetCatalogByID(id));
        }

        public override API.ICatalog GetCatalogByTitle(string title)
        {
            return Transfer(DataRepository.GetCatalogByTitle(title));
        }

        public override API.IReader GetReader(int id)
        {
            return Transfer(DataRepository.GetReader(id));
        }

        public override void UpdateCatalog(int id, string author, string name)
        {
            DataRepository.UpdateCatalog(id, author, name);
        }

        public override void UpdateReader(int id, string name, string surname)
        {
            DataRepository.UpdateReader(id, name, surname);
        }
    }
}
