using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class DataRepository : IDataRepository
    {
        internal class DataContext : IDataContext
        {
            public int ValidBookID { get; set; }
            public List<IReader> Readers { get; set; }
            public List<ICatalog> Catalogs { get; set; }
            public List<IAction> Actions { get; set; }

            public DataContext()
            {
                Readers = new List<IReader>();
                Catalogs = new List<ICatalog>();
                Actions = new List<IAction>();
                ValidBookID = 0;
            }
        }

        private DataContext data { get; set; }
        private IFill filler;

    public DataRepository(IFill filler)
    {
        data = new DataContext();
        this.filler = filler;
        this.filler.Fill(this);
    }

        #region Catalog

        public void AddCatalog(ICatalog catalog)
        {
            data.Catalogs.Add(catalog);
        }

        public void SetCatalogs(List<ICatalog> catalog)
        {
            data.Catalogs = catalog;
        }

        public ICatalog GetCatalog(string author, string title)
        {
            foreach (ICatalog catalog in data.Catalogs)
            {
                if (catalog.Author.Equals(author) && catalog.Title.Equals(title))
                {
                    return catalog;
                }

            }

                    return null;
            }
        

        public ICatalog GetCatalog(int index)
        {
            if(index >= 0 && index < data.Catalogs.Count)
            {
                return data.Catalogs[index];
            }

            return null;
        }

        public IEnumerable<ICatalog> GetAllCatalogs()
        {
            return data.Catalogs;
        }

        public void UpdateCatalog(int index, ICatalog catalog)
        {
            if (index >= 0 && index <= data.Catalogs.Count)
            {
                data.Catalogs[index] = catalog;
            }
        }

        public void UpdateCatalog(string author, string title, ICatalog catalog)
        {
            for (int i = 0; i < data.Catalogs.Count; i++)
            {
                if(data.Catalogs [i].Author.Equals(author) && data.Catalogs[i].Title.Equals(title))
                {
                    data.Catalogs[i] = catalog;
                    break;
                }
            }
        }

        public void DeleteCatalog(int index)
        {
            if (index >= 0 && index < data.Catalogs.Count)
            {
                data.Catalogs.RemoveAt (index);
            }
        }

        public void DeleteCatalog(string author, string title)
        {
            ICatalog catalog = GetCatalog(author, title);
            if (catalog != null)
            {
                data.Catalogs.Remove (catalog);
            }
        }

        #endregion

        #region Reader

        public void AddReader(IReader r)
        {
            data.Readers.Add(r);
        }

        public void SetReaders(List<IReader> r)
        {
            data.Readers = r;
        }

        public IReader GetReader(int readerID)
        {
            foreach(IReader r in data.Readers)
            {
                if (r.ReaderID == readerID)
                {
                    return r;
                }

            }

            return null;
        }

        public void UpdateReader(int readerID, IReader reader)
        {
            for (int i = 0; i < data.Readers.Count; i++)
            {
                if (data.Readers[i].ReaderID == readerID)
                {
                    data.Readers[i] = reader;
                    break;
                }
            }
        }

        public void DeleteReader(int readerID)
        {
            IReader reader = GetReader(readerID);
            if (reader != null)
            {
                data.Readers.Remove (reader);
            }
        }

        public IEnumerable<IReader> GetAllReaders()
        {
            return data.Readers;
        }

        #endregion

        #region Book

        public IBook GetBook(ICatalog catalog)
        {
            if (catalog.Books.Count != 0)
            {
                IBook    book = catalog.Books[catalog.Books.Count - 1];
                return book;
            }
            return null;
        }

        public void AddBook(IBook book)
        {
            if (book.Catalog != null)
            {
                book.Catalog.Books.Add (book);
                data.ValidBookID++;
            }
        }

        public int ValidBookID //current valid book ID
        {
            get { return data.ValidBookID; }
        }

        #endregion

        #region Actions

        public void AddAction(IAction action)
        {
            data.Actions.Add (action);
        }

        public IAction GetAction(int index)
        {
            if (index >= 0 && index < data.Actions.Count)
            {
                return data.Actions[index];
            }
            return null;
        }

        public IEnumerable<IAction> GetAllActions()
        {
            return data.Actions;
        }

        #endregion

    }
}
