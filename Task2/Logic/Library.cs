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

        public override IBook RentBook(string author, string title, IReader reader)
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

        public override void ReturnBook(IBook book, IReader reader)
        {
            if (reader.Books.Contains(book))
            {
                book.Catalog.Books.Add(book);
                reader.Books.Remove(book);
            }
        }

        #endregion
    }
}
