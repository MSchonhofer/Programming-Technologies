using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Impl;

namespace Data.API
{
    public abstract class IDataRepository
    {

        //catalogs
        public abstract void AddCatalog(ICatalog catalog);
        public abstract void SetCatalogs(List<ICatalog> catalog);
        public abstract ICatalog GetCatalog(string author, string title);
        public abstract ICatalog GetCatalog(int index);
        public abstract IEnumerable<ICatalog> GetAllCatalogs();
        public abstract void UpdateCatalog(int index, ICatalog catalog);
        public abstract void UpdateCatalog(string author, string title, ICatalog catalog);
        public abstract void DeleteCatalog(int index);
        public abstract void DeleteCatalog(string author, string title);

        //readers
        public abstract void AddReader(IReader r);
        public abstract void SetReaders(List<IReader> r);
        public abstract IReader GetReader(int readerID);
        public abstract void UpdateReader(int readerID, IReader reader);
        public abstract void DeleteReader(int readerID);
        public abstract IEnumerable<IReader> GetAllReaders();

        //books
        public abstract IBook GetBook(ICatalog catalog);
        public abstract void AddBook(IBook book);
        //public abstract int ValidBookID; // co z tym?

        //actions
        public abstract void AddAction(IAction action);
        public abstract IAction GetAction(int index);
        public abstract IEnumerable<IAction> GetAllActions();

        public static IDataRepository CreateDataRepository(IFill fill = default)
        {
            return new DataRepository(fill);
        }
    }
}

