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
            Catalog c1 = new("Dostoevsky", "Crime and Punishment");
            c1.Books.Add(new Book(c1, 1));
            c1.Books.Add(new Book(c1, 2));
            c1.Books.Add(new Book(c1, 3));
            c1.Books.Add(new Book(c1, 4));
            dataRepository.AddCatalog(c1);

            Catalog c2 = new("Conrad", "Heart of Darkness");
            c2.Books.Add(new Book(c2, 5));
            c2.Books.Add(new Book(c2, 6));
            c2.Books.Add(new Book(c2, 7));
            dataRepository.AddCatalog(c2);

            Catalog c3 = new("Tolkien", "Lord of Rings");
            c3.Books.Add(new Book(c3, 8));
            c3.Books.Add(new Book(c3, 9));
            c3.Books.Add(new Book(c3, 10));
            c3.Books.Add(new Book(c3, 11));
            c3.Books.Add(new Book(c3, 12));
            c3.Books.Add(new Book(c3, 13));
            dataRepository.AddCatalog(c3);

            Reader r1 = new(1, "Jack", "Smith");
            r1.Books.Add(new Book(c3, 14));
            r1.Books.Add(new Book(c1, 15));
            r1.Books.Add(new Book(c3, 16));
            dataRepository.AddReader(r1);

            Reader r2 = new(2, "Mary", "Carlisle");
            r2.Books.Add(new Book(c2, 17));
            r2.Books.Add(new Book(c1, 18));
            r2.Books.Add(new Book(c3, 19));
            dataRepository.AddReader(r2);

            Reader r3 = new(3, "John", "Novak");
            r3.Books.Add(new Book(c1, 20));
            r3.Books.Add(new Book(c2, 21));
            dataRepository.AddReader(r3);
        }
    }

}
