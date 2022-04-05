using System;
using System.Collections.Generic;
using Data;

namespace Logic
{
    public class Library
    {
        private DataRepository dataRepository;

        public Library(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        #region Book

        public Book GetBook(string author, string title)
        {
            return dataRepository.GetBook(dataRepository.GetCatalog(author, title));
        }

        public Book RentBook(string author, string title, Reader reader)
        {
            Catalog catalog = dataRepository.GetCatalog(author, title);
            Book book = dataRepository.GetBook(catalog);
            if (book != null)
            {
                catalog.Books.Remove(book);
                reader.Books.Add(book);
                dataRepository.AddAction(new RentBook(DateTime.Now, book, reader));
            }
            return book;
        }

        public void ReturnBook(Book book, Reader reader)
        {
            if (reader.Books.Contains(book))
            {
                book.Catalog.Books.Add(book);
                reader.Books.Remove(book);
                dataRepository.AddAction(new ReturnBook(DateTime.Now, book, reader));
            }
        }

        public void DeleteBook(Book book)
        {
            book.Catalog.Books.Remove(book);
            dataRepository.AddAction(new DeleteBook(DateTime.Now, book));
        }

        public void AddBook(Book book)
        {
            if (book.Catalog != null)
            {
                dataRepository.AddBook(book);
                dataRepository.AddAction(new AddBook(DateTime.Now, book));
            }

        }

        public void AddBook(string author, string title)
        {
            Catalog catalog = dataRepository.GetCatalog(author, title);
            if (catalog != null)
            {
                Book book = new Book(catalog, dataRepository.ValidBookID);
                dataRepository.AddBook(book);
                dataRepository.AddAction(new AddBook(DateTime.Now, book));
            }
        }

        #endregion

        #region Reader

        public Reader GetReader(int id)
        {
            return dataRepository.GetReader(id);
        }

        public void AddReader(Reader reader)
        {
            dataRepository.AddReader(reader);
            dataRepository.AddAction(new AddReader(DateTime.Now, reader));
        }

        public void AddReader(int id, string fistName, string lastName)
        {
            Reader reader = new Reader(id, fistName, lastName);
            dataRepository.AddReader(reader);
            dataRepository.AddAction(new AddReader(DateTime.Now, reader));
        }

        public void DeleteReader(Reader reader)
        {
            dataRepository.DeleteReader(reader.ReaderID);
            dataRepository.AddAction(new DeleteReader(DateTime.Now, reader));
        }

        public void DeleteReader(int id)
        {
            Reader reader = dataRepository.GetReader(id);
            if (reader != null)
            {
                dataRepository.DeleteReader(id);
                dataRepository.AddAction(new DeleteReader(DateTime.Now, reader));
            }
        }

        public void UpdateReader(int id, Reader reader)
        {
            Reader r = dataRepository.GetReader(id);
            if (r != null)
            {
                dataRepository.UpdateReader(id, reader);
                dataRepository.AddAction(new UpdateReader(DateTime.Now, reader));
            }
        }

        public IEnumerable<Reader> GetAllReaders()
        {
            return dataRepository.GetAllReaders();
        }

        #endregion

        #region Catalog

        public Catalog GetCatalog(string author, string title)
        {
            return dataRepository.GetCatalog(author, title);
        }

        public void AddCatalog(Catalog catalog)
        {
            dataRepository.AddCatalog(catalog);
            dataRepository.AddAction(new AddCatalog(DateTime.Now, catalog));
        }

        public void AddCatalog(string author, string title)
        {
            Catalog catalog = new Catalog(author, title);
            dataRepository.AddCatalog(catalog);
            dataRepository.AddAction(new AddCatalog(DateTime.Now, catalog));
        }

        public void UpdateCatalog(int index, Catalog catalog)
        {
            Catalog c = dataRepository.GetCatalog(index);
            if (c != null)
            {
                dataRepository.UpdateCatalog(index, catalog);
                dataRepository.AddAction(new UpdateCatalog(DateTime.Now, catalog));
            }
        }

        public void DeleteCatalog(int index)
        {
            Catalog catalog = dataRepository.GetCatalog(index);
            if (catalog != null)
            {
                dataRepository.DeleteCatalog(index);
                dataRepository.AddAction(new DeleteCatalog(DateTime.Now, catalog));
            }
        }

        public void DeleteCatalog(string author, string title)
        {
            Catalog catalog = dataRepository.GetCatalog(author, title);
            if (catalog != null)
            {
                dataRepository.DeleteCatalog(author, title);
                dataRepository.AddAction(new DeleteCatalog(DateTime.Now, catalog));
            }
        }

        public IEnumerable<Catalog> GetAllCatalogs()
        {
            return dataRepository.GetAllCatalogs();
        }

        #endregion

        #region Action
        public IEnumerable<IAction> GetAllActions()
        {
            return dataRepository.GetAllActions();
        }

        public IEnumerable<IAction> GetActionsForReader(Reader reader)
        {
            List<IAction> userActions = new List<IAction>();
            foreach (IAction iAction in GetAllActions())
            {
                if (iAction.GetActionType() == ActionType.AddReader ||
                    iAction.GetActionType() == ActionType.UpdateReader ||
                    iAction.GetActionType() == ActionType.DeleteReader)
                {
                    ActionReader ActionReader = iAction as ActionReader;
                    if (ActionReader.Reader == reader)
                    {
                        userActions.Add(ActionReader);
                    }
                }
                else if (iAction.GetActionType() == ActionType.RentBook)
                {
                    RentBook rentBook = iAction as RentBook;
                    if (rentBook.Reader == reader)
                    {
                        userActions.Add(rentBook);
                    }
                }
                else if (iAction.GetActionType() == ActionType.ReturnBook)
                {
                    ReturnBook returnBook = iAction as ReturnBook;
                    if (returnBook.Reader == reader)
                    {
                        userActions.Add(returnBook);
                    }
                }
            }
            return userActions;
        }

        public IEnumerable<IAction> GetActionsForCatalog(Catalog catalog)
        {
            List<IAction> catalogActions = new List<IAction>();
            foreach (IAction iAction in GetAllActions())
            {
                if (iAction.GetActionType() == ActionType.AddCatalog ||
                    iAction.GetActionType() == ActionType.UpdateCatalog ||
                    iAction.GetActionType() == ActionType.DeleteCatalog)
                {
                    ActionCatalog ActionCatalog = iAction as ActionCatalog;
                    if (ActionCatalog.Catalog == catalog)
                    {
                        catalogActions.Add(ActionCatalog);
                    }
                }
            }
            return catalogActions;
        }


        public IEnumerable<IAction> GetActionsForBook(Book book)
        {
            List<IAction> bookActions = new List<IAction>();
            foreach (IAction iAction in GetAllActions())
            {
                if (iAction.GetActionType() == ActionType.AddBook ||
                    iAction.GetActionType() == ActionType.DeleteBook ||
                    iAction.GetActionType() == ActionType.RentBook ||
                    iAction.GetActionType() == ActionType.ReturnBook)
                {
                    ActionBook ActionBook = iAction as ActionBook;
                    if (ActionBook.Book == book)
                    {
                        bookActions.Add(ActionBook);
                    }
                }
            }
            return bookActions;
        }

        public IEnumerable<IAction> GetActionsBetweenDates(DateTime startDate, DateTime endDate)
        {
            List<IAction> Actions = new List<IAction>();
            foreach (IAction iAction in GetAllActions())
            {
                if (iAction.GetDateTime() >= startDate && iAction.GetDateTime() <= endDate)
                {
                    Actions.Add(iAction);
                }
            }
            return Actions;
        }

        #endregion
    }
}