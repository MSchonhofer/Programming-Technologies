using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Catalog catalog1 = new("Dostoevsky", "Crime and Punishment");
            catalog1.Books.Add(new Book(catalog1, 1));
            catalog1.Books.Add(new Book(catalog1, 2));
            catalog1.Books.Add(new Book(catalog1, 3));
            catalog1.Books.Add(new Book(catalog1, 4));
            dataRepository.AddCatalog(catalog1);

            Catalog catalog2 = new("Conrad", "Heart of Darkness");
            catalog2.Books.Add(new Book(catalog2, 5));
            catalog2.Books.Add(new Book(catalog2, 6));
            catalog2.Books.Add(new Book(catalog2, 7));
            dataRepository.AddCatalog(catalog2);

            Catalog catalog3 = new("Tolkien", "Lord of Rings");
            catalog1.Books.Add(new Book(catalog3, 8));
            catalog1.Books.Add(new Book(catalog3, 9));
            catalog1.Books.Add(new Book(catalog3, 10));
            catalog1.Books.Add(new Book(catalog3, 11));
            catalog1.Books.Add(new Book(catalog3, 12));
            catalog1.Books.Add(new Book(catalog3, 13));
            dataRepository.AddCatalog(catalog3);

            Reader reader1 = new(1, "Jack", "Smith");
            reader1.Books.Add(new Book(catalog3, 14));
            reader1.Books.Add(new Book(catalog1, 15));
            reader1.Books.Add(new Book(catalog3, 16));
            dataRepository.AddReader(reader1);

            Reader reader2 = new(2, "Mary", "Carlisle");
            reader2.Books.Add(new Book(catalog2, 17));
            reader2.Books.Add(new Book(catalog1, 18));
            reader2.Books.Add(new Book(catalog3, 19));
            dataRepository.AddReader(reader2);

            Reader reader3 = new(3, "John", "Novak");
            reader3.Books.Add(new Book(catalog1, 20));
            reader3.Books.Add(new Book(catalog2, 21));
            dataRepository.AddReader(reader3);
        }
    }

}
