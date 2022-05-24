using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.API;
using Data.Impl;
using Logic;
using Logic.API;
using System;
using System.Text;
namespace Tests
{

    internal class Book : IBook
    {
        public ICatalog Catalog { get; set; }
        public int BookID { get; set; }
        public Book(ICatalog catalog, int id)
        {
            Catalog = catalog;
            BookID = id;
        }
    }
    public class TestFillStatic : IFill
    {
        public override void Fill(IDataRepository dataRepository)
        {
            ICatalog c1 = new Catalog("Dostoevsky", "Crime and Punishment");
            c1.Books.Add(new Book(c1, 1));
            c1.Books.Add(new Book(c1, 2));
            c1.Books.Add(new Book(c1, 3));
            c1.Books.Add(new Book(c1, 4));
            dataRepository.AddCatalog(c1);

            ICatalog c2 = new Catalog("Conrad", "Heart of Darkness");
            c2.Books.Add(new Book(c2, 5));
            c2.Books.Add(new Book(c2, 6));
            c2.Books.Add(new Book(c2, 7));
            dataRepository.AddCatalog(c2);

            ICatalog c3 = new Catalog("Tolkien", "Lord of Rings");
            c3.Books.Add(new Book(c3, 8));
            c3.Books.Add(new Book(c3, 9));
            c3.Books.Add(new Book(c3, 10));
            c3.Books.Add(new Book(c3, 11));
            c3.Books.Add(new Book(c3, 12));
            c3.Books.Add(new Book(c3, 13));
            dataRepository.AddCatalog(c3);

            IReader r1 = new Reader(1, "Jack", "Smith");
            r1.Books.Add(new Book(c3, 14));
            r1.Books.Add(new Book(c1, 15));
            r1.Books.Add(new Book(c3, 16));
            dataRepository.AddReader(r1);

            IReader r2 = new Reader(2, "Mary", "Carlisle");
            r2.Books.Add(new Book(c2, 17));
            r2.Books.Add(new Book(c1, 18));
            r2.Books.Add(new Book(c3, 19));
            dataRepository.AddReader(r2);

            IReader r3 = new Reader(3, "John", "Novak");
            r3.Books.Add(new Book(c1, 20));
            r3.Books.Add(new Book(c2, 21));
            dataRepository.AddReader(r3);
        }
    }
}
