using System;
using Data.API;
using Logic.API;

namespace Logic
{
    internal class Library : ILibrary
    {
        private IDataRepository DataRepository;

        public Library(IDataRepository dataRepository)
        {
            DataRepository = dataRepository;
        }

        #region Book

        public IBook RentBook(string author, string title, IReader reader)
        {
            ICatalog catalog = DataRepository.GetCatalog(author, title);
            IBook book = DataRepository.GetBook(catalog);
            if (book != null)
            {
                catalog.Books.Remove(book);
                reader.Books.Add(book);
                DataRepository.AddAction(new RentBook(DateTime.Now, book, reader)); // tu trzeba sie pozbyc new RentBook
            }
            return book;
        }

        public void ReturnBook(IBook book, IReader reader)
        {
            if (reader.Books.Contains(book))
            {
                book.Catalog.Books.Add(book);
                reader.Books.Remove(book);
                DataRepository.AddAction(new ReturnBook(DateTime.Now, book, reader)); // tu trzeba sie pozbyc new ReturnBook
            }
        }

        #endregion
    }
}
