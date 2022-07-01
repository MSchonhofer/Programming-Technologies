using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Tests
{
    public class TestFillStatic : IFill
    {
        public override void Fill(IDataRepository dataRepository)
        {
            ICatalog c1 = new Catalog(1, "Dostoevsky", "Crime and Punishment");
            dataRepository.AddCatalog(1, "Dostoevsky", "Crime and Punishment");

            ICatalog c2 = new Catalog(2, "Conrad", "Heart of Darkness");
            dataRepository.AddCatalog(2, "Conrad", "Heart of Darkness");

            ICatalog c3 = new Catalog(3, "Tolkien", "Lord of Rings");
            dataRepository.AddCatalog(3, "Tolkien", "Lord of Rings");

            ICatalog c4 = new Catalog(4, "Dostoevsky", "Crime and Punishment");
            dataRepository.AddCatalog(4, "Dostoevsky", "Crime and Punishment");

            ICatalog c5 = new Catalog(5, "Dostoevsky", "Crime and Punishment");
            dataRepository.AddCatalog(5, "Dostoevsky", "Crime and Punishment");

            ICatalog c6 = new Catalog(6, "Dostoevsky", "Crime and Punishment");
            dataRepository.AddCatalog(6, "Dostoevsky", "Crime and Punishment");

            ICatalog c7 = new Catalog(7, "Conrad", "Heart of Darkness");
            dataRepository.AddCatalog(7, "Conrad", "Heart of Darkness");

            ICatalog c8 = new Catalog(8, "Conrad", "Heart of Darkness");
            dataRepository.AddCatalog(8, "Conrad", "Heart of Darkness");

            ICatalog c9 = new Catalog(9, "Conrad", "Heart of Darkness");
            dataRepository.AddCatalog(9, "Conrad", "Heart of Darkness");

            ICatalog c10 = new Catalog(10, "Tolkien", "Lord of Rings");
            dataRepository.AddCatalog(10, "Tolkien", "Lord of Rings");

            ICatalog c11 = new Catalog(11, "Tolkien", "Lord of Rings");
            dataRepository.AddCatalog(11, "Tolkien", "Lord of Rings");

            ICatalog c12 = new Catalog(12, "Tolkien", "Lord of Rings");
            dataRepository.AddCatalog(12, "Tolkien", "Lord of Rings");

            IReader r1 = new Reader(1, "Jack", "Smith");
            dataRepository.AddReader(1, "Jack", "Smith");

            IReader r2 = new Reader(2, "Mary", "Carlisle");
            dataRepository.AddReader(2, "Mary", "Carlisle");

            IReader r3 = new Reader(3, "John", "Novak");
            dataRepository.AddReader(3, "John", "Novak");

            IAction a1 = new Action(1, 1, 1);
            dataRepository.AddAction(1, 1, 1);

            IAction a2 = new Action(2, 2, 1);
            dataRepository.AddAction(2, 2, 1);

            IAction a3 = new Action(3, 4, 2);
            dataRepository.AddAction(3, 4, 2);

            IAction a4 = new Action(4, 3, 3);
            dataRepository.AddAction(4, 3, 3);

            IAction a5 = new Action(5, 12, 1);
            dataRepository.AddAction(5, 12, 1);

            IAction a6 = new Action(6, 10, 1);
            dataRepository.AddAction(6, 10, 1);

            IAction a7 = new Action(7, 8, 2);
            dataRepository.AddAction(7, 8, 2);

            IAction a8 = new Action(8, 7, 2);
            dataRepository.AddAction(8, 7, 2);
        }
    }
}
