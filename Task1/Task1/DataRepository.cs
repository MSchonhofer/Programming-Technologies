using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataRepository
    {
        public class DataContext
        {
            public int ValidBookID { get; set; }
            public List<Reader> Readers { get; set; }
            public List<Catalog> Catalogs { get; set; }
            public List<IAction> Actions { get; set; }

            public DataContext()
            {
                Readers = new List<Reader>();
                Catalogs = new List<Catalog>();
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

        public void AddCatalog(Catalog catalog)
        {
            data.Catalogs.Add(catalog);
        }

        public void SetCatalogs(List<Catalog> catalog)
        {
            data.Catalogs = catalog;
        }

        public Catalog GetCatalog(string author, string title)
        {
            foreach(Catalog catalog in data.Catalogs)
            {
                if (catalog.Author.Equals(author) && catalog.Title.Equals(title))
                {
                    return catalog;
                }
                return null;
            }
        }

        public Catalog GetCatalog(int index)
        {
            if(index >= 0 && index < data.Catalogs.Count)
            {
                return data.Catalogs[index];
            }
            return null;
        }

        public IEnumerable<Catalog> GetAllCatalogs()
        {
            return data.Catalogs;
        }

        public void UpdateCatalog(int index, Catalog catalog)
        {
            if (index >= 0 && index <= data.Catalogs.Count)
            {
                data.Catalogs[index] = catalog;
            }
        }

        public void UpdateCatalog(string author, string title, Catalog catalog)
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
            Catalog catalog = GetCatalog(author, title);
            if (catalog != null)
            {
                data.Catalogs.Remove (catalog);
            }
        }

        #endregion

        #region Reader

        public void AddReader(Reader reader)
        {
            data.Readers.Add (reader);
        }

        public void SetReaders(List<Reader> readers)
        {
            data.Readers = readers;
        }

        public Reader GetReader(int readerID)
        {
            foreach(Reader reader in data.Readers)
            {
                if (reader.ReaderID == readerID)
                {
                    return reader;
                }
            }
        }

       public void UpdateReader(int readerID, Reader reader)
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
            Reader reader = GetReader(readerID);
            if (reader != null)
            {
                data.Readers.Remove (reader);
            }
        }

        public IEnumerable<Reader> GetAllReaders()
        {
            return data.Readers;
        }

        #endregion

        #region Book

        public Book GetBook(Catalog catalog)
        {
            if (catalog.Books.Count != 0)
            {
                Book book = catalog.Books[catalog.Books.Count - 1];
                return book;
            }
            return null;
        }

        public void AddBook(Book book)
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
