using Presentation.API;
using Presentation.ViewModel.MVVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Presentation.ViewModel
{
    public class CatalogViewModel : ViewModelBase
    {
        private IModel model;
        public CatalogViewModel(IModel model)
        {
            this.model = model;
            AddCatalogCommand = new RelayCommand(AddCatalog);
            UpdateCatalogCommand = new RelayCommand(UpdateCatalog);
            DeleteCatalogCommand = new RelayCommand(DeleteCatalog);
            RefreshCatalogCommand = new RelayCommand(RefreshCatalog);

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
            set { text = value; OnPropertyChanged("Text");}
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

        public System.Action<string> MessageShowBoxDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageShowBoxDelegate)} must be assigned by view layer.");
    }
}
