using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;
using Presentation.API;

namespace Presentation.ViewModel
{
    public class ViewModel : ViewModelBase
    {
        private IModel model;
        public ViewModel(IModel model)
        {
            this.model = model;
            AddReaderCommand = new RelayCommand(AddReader);
            UpdateReaderCommand = new RelayCommand(UpdateReader);
            DeleteReaderCommand = new RelayCommand(DeleteReader);
            RefreshReaderCommand = new RelayCommand(RefreshReader);
            AddCatalogCommand = new RelayCommand(AddCatalog);
            UpdateCatalogCommand = new RelayCommand(UpdateCatalog);
            DeleteCatalogCommand = new RelayCommand(DeleteCatalog);
            RefreshCatalogCommand = new RelayCommand(RefreshCatalog);
            AddActionCommand = new RelayCommand(AddAction);
            RefreshActionCommand = new RelayCommand(RefreshAction);
        }
        private int cID;
        public int CatalogID
        {
            get
            {
                return cID;
            }
            set
            {
                cID = value;
                OnPropertyChanged("CatalogID");
            }
        }
        private int rID;
        public int ReaderID
        {
            get
            {
                return rID;
            }
            set
            {
                rID = value;
                OnPropertyChanged("ReaderID");
            }
        }
        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set { text = value; OnPropertyChanged("Text"); }
        }

        public RelayCommand AddActionCommand { get; private set; }
        public RelayCommand UpdateActionCommand { get; private set; }
        public RelayCommand DeleteActionCommand { get; private set; }
        public RelayCommand RefreshActionCommand { get; private set; }
        private void AddAction()
        {
            model.service.AddAction(ID, CatalogID, ReaderID);
            text = "Action added.";
            MessageShowBoxDelegate(Text);
        }
        private void RefreshAction()
        {
            actions = model.service.GetAllActions();
        }
        private IEnumerable<IAction> actions;
        public IEnumerable<IAction> Actions
        {
            get
            {
                return actions;
            }
            set
            {
                actions = value;
                OnPropertyChanged("Actions");
            }
        }
        private string author;
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public RelayCommand AddCatalogCommand { get; private set; }
        public RelayCommand UpdateCatalogCommand { get; private set; }
        public RelayCommand DeleteCatalogCommand { get; private set; }
        public RelayCommand RefreshCatalogCommand { get; private set; }
        private void AddCatalog()
        {
            model.service.AddCatalog(ID, Author, Title);
            text = "Book added.";
            MessageShowBoxDelegate(Text);
        }
        private void UpdateCatalog()
        {
            model.service.UpdateCatalog(ID, Author, Title);
            text = "Catalog updated.";
            MessageShowBoxDelegate(Text);
        }
        private void DeleteCatalog()
        {
            model.service.DeleteCatalog(ID);
            text = "Book deleted.";
            MessageShowBoxDelegate(Text);
        }
        private void RefreshCatalog()
        {
            Catalogs = model.service.GetAllCatalogs();
        }
        private IEnumerable<ICatalog> catalogs;
        public IEnumerable<ICatalog> Catalogs
        {
            get
            {
                return catalogs;
            }
            set
            {
                catalogs = value;
                OnPropertyChanged("Catalogs");
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public RelayCommand AddReaderCommand { get; private set; }
        public RelayCommand UpdateReaderCommand { get; private set; }
        public RelayCommand DeleteReaderCommand { get; private set; }
        public RelayCommand RefreshReaderCommand { get; private set; }
        private void AddReader()
        {
            model.service.AddReader(ID, Name, Surname);
            text = "Reader added.";
            MessageShowBoxDelegate(Text);
        }
        private void UpdateReader()
        {
            model.service.UpdateReader(ID, Name, Surname);
            text = "Reader updated.";
            MessageShowBoxDelegate(Text);
        }
        private void DeleteReader()
        {
            model.service.DeleteReader(ID);
            text = "Reader deleted.";
            MessageShowBoxDelegate(Text);
        }
        private void RefreshReader()
        {
            Readers = model.service.GetAllReaders();
        }
        private IEnumerable<IReader> readers;
        public IEnumerable<IReader> Readers
        {
            get
            {
                return readers;
            }
            set
            {
                readers = value;
                OnPropertyChanged("Readers");
            }
        }

        public System.Action<string> MessageShowBoxDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageShowBoxDelegate)} must be assigned by view layer.");
    }
}
