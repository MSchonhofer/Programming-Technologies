using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TestFillStatic : IFill
    {
        public void Fill(DataRepository dataRepository)
        {
            Catalog catalog1 = new Catalog("Dostoevsky", "Crime and Punishment");
            catalog1.Books.Add(new Book(catalog1, 001));
            catalog1.Books.Add(new Book(catalog1, 002));
            catalog1.Books.Add(new Book(catalog1, 003));
            catalog1.Books.Add(new Book(catalog1, 004));
            dataRepository.AddCatalog(catalog1);

            Catalog catalog2 = new Catalog("Conrad", "Heart of Darkness");
            catalog2.Books.Add(new Book(catalog2, 004));
            catalog2.Books.Add(new Book(catalog2, 005));
            catalog2.Books.Add(new Book(catalog2, 006));

            Catalog catalog3 = new Catalog("Tolkien", "Lord of Rings");
            catalog1.Books.Add(new Book(catalog3, 007));
            catalog1.Books.Add(new Book(catalog3, 008));
            catalog1.Books.Add(new Book(catalog3, 009));
            catalog1.Books.Add(new Book(catalog3, 010));
            catalog1.Books.Add(new Book(catalog3, 011));
            catalog1.Books.Add(new Book(catalog3, 012));

            Reader reader1 = new Reader(1, "Jack", "Smith");
            reader1.Books.Add(new Book(catalog3, 010));
            reader1.Books.Add(new Book(catalog1, 002));

            Reader reader2 = new Reader(2, "Mary", "Carlisle");
            reader2.Books.Add(new Book(catalog2, 005));
            reader2.Books.Add(new Book(catalog1, 002));
            reader2.Books.Add(new Book(catalog3, 012));
        }
    }
}
