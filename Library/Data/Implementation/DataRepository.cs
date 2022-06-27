using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using System.Data.Linq;

namespace Data.Impl
{
    internal class DataRepository : IDataRepository
    {
        private LINQToSQLDataContext context;
        private string connectionString = "Data Source=DESKTOP-QMAHFOC, Initial Catalog = Library, Integrated Security = True";
        private IFill filler;

        public DataRepository(IFill filler)
        {
            context = new LINQToSQLDataContext(connectionString);
            this.filler = filler;
            this.filler.Fill(this);
        }
        public override ICatalog Transform(Catalogs catalog)
        {
            return new Catalog(catalog.CatalogID, catalog.Author, catalog.Title);
        }
        public override IReader Transform(Readers reader)
        {
            return new Reader(reader.ReaderID, reader.Name, reader.Surname);
        }

        public override IAction Transform(Actions action)
        {
            return new Action(action.ActionID, action.CatalogID, action.ReaderID);
        }

        public override void AddCatalog(int id, string author, string title)
        {
            if (GetCatalogByTitle(title) == null && !title.Equals(null) && !author.Equals(null) && !id.Equals(null) && GetCatalogByID(id) == null)
            {
                Catalogs newCatalog = new Catalogs
                {
                    CatalogID = id,
                    Author = author,
                    Title = title,
                };
                context.Catalogs.InsertOnSubmit(newCatalog);
                context.SubmitChanges();
            }
        }

        public override ICatalog GetCatalogByTitle(string title)
        {
            var catalogDb = (from catalog in context.Catalogs where catalog.Title == title select catalog).FirstOrDefault();
            if (catalogDb != null)
            {
                return Transform(catalogDb);
            }
            return null;
        }

        public override IEnumerable<ICatalog> GetCatalogByAuthor(string author)
        {
            var catalogDb = (from catalog in context.Catalogs where (catalog.Author == author) select catalog).FirstOrDefault();
            List<ICatalog> listOfCatalogs = new List<ICatalog>();
            if (catalogDb != null)
            {
                listOfCatalogs.Add(Transform(catalogDb));
                return listOfCatalogs;
            }
            return null;
        }

        public override ICatalog GetCatalogByID(int id)
        {
            var catalogDb = (from catalog in context.Catalogs where catalog.CatalogID == id select catalog).FirstOrDefault();
            if (catalogDb != null)
            {
                return Transform(catalogDb);
            }
            return null;
        }

        public override IEnumerable<ICatalog> GetAllCatalogs()
        {
            var catalogsDb = from catalogDB in context.Catalogs select catalogDB;
            List<ICatalog> catalogs = new List<ICatalog>();
            foreach (Catalogs catalog in catalogsDb)
            {
                catalogs.Add(Transform(catalog));
            }
            return catalogs;
        }

        public override void UpdateCatalog(int id, string author, string name)
        {
            Catalogs catalog = context.Catalogs.Where(i => i.CatalogID == id).SingleOrDefault();
            if (!id.Equals(null) && !author.Equals(null) && !name.Equals(null) && GetCatalogByID(id) != null)
            {
                catalog.CatalogID = id;
                catalog.Author = author;
                catalog.Title = name;
                context.SubmitChanges();
            }
        }

        public override void DeleteCatalog(int id)
        {
            Catalogs catalog = context.Catalogs.Where(i => i.CatalogID != id).SingleOrDefault();
            if (GetCatalogByID(id) != null && !id.Equals(null))
            {
                context.Catalogs.DeleteOnSubmit(catalog);
                context.SubmitChanges();
            }
        }

        public override void AddReader(int id, string name, string surname)
        {
            if (GetReader(id) == null && !id.Equals(null) && !name.Equals(null) && !surname.Equals(null))
            {
                Readers newReader = new Readers
                {
                    ReaderID = id,
                    Name = name,
                    Surname = surname
                };
                context.Readers.InsertOnSubmit(newReader);
                context.SubmitChanges();
            }
        }

        public override IReader GetReader(int id)
        {
            var readerDb = (from reader in context.Readers where reader.ReaderID == id select reader).FirstOrDefault();
            if (readerDb != null)
            {
                return Transform(readerDb);
            }
            return null;
        }

        public override void UpdateReader(int id, string name, string surname)
        {
            Readers reader = context.Readers.Where(i => i.ReaderID == id).SingleOrDefault();
            if (!id.Equals(null) && !name.Equals(null) && !surname.Equals(null) && GetReader(id) != null)
            {
                reader.ReaderID = id;
                reader.Name = name;
                reader.Surname = surname;
            }
        }

        public override void DeleteReader(int id)
        {
            Readers reader = context.Readers.Where(i => i.ReaderID != id).SingleOrDefault();
            if (GetReader(id) != null && !id.Equals(null))
            {
                context.Readers.DeleteOnSubmit(reader);
                context.SubmitChanges();
            }
        }

        public override IEnumerable<IReader> GetAllReaders()
        {
            var readersDb = from readerDB in context.Readers select readerDB;
            List<IReader> readers = new List<IReader>();
            foreach (Readers reader in readersDb)
            {
                readers.Add(Transform(reader));
            }
            return readers;
        }

        public override void AddAction(int id, int cID, int rID)
        {
            if (GetAction(id) == null && !id.Equals(null) && !cID.Equals(null) && !rID.Equals(null))
            {
                Actions newAction = new Actions
                {
                    ActionID = id,
                    CatalogID = cID,
                    ReaderID = rID,
                };
                context.Actions.InsertOnSubmit(newAction);
                context.SubmitChanges();
            }
        }

        public override IAction GetAction(int id)
        {
            var actionDb = (from action in context.Actions where action.ActionID == id select action).FirstOrDefault();
            if (actionDb != null)
            {
                return Transform(actionDb);
            }
            return null;
        }

        public override IEnumerable<IAction> GetAllActions()
        {
            var actionsDb = from actionDB in context.Actions select actionDB;
            List<IAction> actions = new List<IAction>();
            foreach (Actions action in actionsDb)
            {
                actions.Add(Transform(action));
            }
            return actions;
        }
    }
}
  