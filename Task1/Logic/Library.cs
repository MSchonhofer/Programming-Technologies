using System;
using System.Collections.Generic;
using Data;

namespace Logic
{
    public class Library
    {
        private IDataRepository dataRepository;

        public Library(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        #region Book

        public IBook RentBook(string author, string title, IReader reader)
        {
            ICatalog catalog = dataRepository.GetCatalog(author, title);
            IBook book = dataRepository.GetBook(catalog);
            if (book != null)
            {
                catalog.Books.Remove(book);
                reader.Books.Add(book);
                dataRepository.AddAction(new RentBook(DateTime.Now, book, reader)); // tu trzeba sie pozbyc new RentBook
            }
            return book;
        }

        public void ReturnBook(IBook book, IReader reader)
        {
            if (reader.Books.Contains(book))
            {
                book.Catalog.Books.Add(book);
                reader.Books.Remove(book);
                dataRepository.AddAction(new ReturnBook(DateTime.Now, book, reader)); // tu trzeba sie pozbyc new ReturnBook
            }
        }

        #endregion
    }
}
