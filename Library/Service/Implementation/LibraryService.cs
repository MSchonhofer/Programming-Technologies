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

        public override void AddAction(int id, int cID, int rID)
        {
            throw new NotImplementedException();
        }

        public override void AddCatalog(int id, string author, string title)
        {
            throw new NotImplementedException();
        }

        public override void AddReader(int id, string name, string surname)
        {
            throw new NotImplementedException();
        }

        public override void DeleteCatalog(int id)
        {
            throw new NotImplementedException();
        }

        public override void DeleteReader(int id)
        {
            throw new NotImplementedException();
        }

        public override IAction GetAction(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IAction> GetAllActions()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<API.ICatalog> GetAllCatalogs()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<API.IReader> GetAllReaders()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<API.ICatalog> GetCatalogByAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public override API.ICatalog GetCatalogByID(int id)
        {
            throw new NotImplementedException();
        }

        public override API.ICatalog GetCatalogByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public override API.IReader GetReader(int id)
        {
            throw new NotImplementedException();
        }

        public override void UpdateCatalog(int id, string author, string name)
        {
            throw new NotImplementedException();
        }

        public override void UpdateReader(int id, string name, string surname)
        {
            throw new NotImplementedException();
        }
    }
}
