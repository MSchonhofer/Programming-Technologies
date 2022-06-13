using Presentation.ViewModel.MVVM;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModel
{
    public class CatalogViewModel : ViewModelBase
    {
        private IService service;
        public CatalogViewModel(IService service)
        {
            this.service = service;
            AddCatalogCommand = new RelayCommand(AddCatalog);
            UpdateCatalogByTitleCommand = new RelayCommand(UpdateCatalogByTitle);
            UpdateCatalogByIndexCommand = new RelayCommand(UpdateCatalogByIndex);
            DeleteCatalogByIndexCommand = new RelayCommand(DeleteCatalogByIndex);
            DeleteCatalogByTitleCommand = new RelayCommand(DeleteCatalogByTitle);
        }
        public RelayCommand AddCatalogCommand { get; private set; }
        public RelayCommand DeleteCatalogByIndexCommand { get; private set; }
        public RelayCommand DeleteCatalogByTitleCommand { get; private set; }
        public RelayCommand UpdateCatalogByIndexCommand { get; private set; }
        public RelayCommand UpdateCatalogByTitleCommand { get; private set; }

        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged("Text"); }
        }

        public Action<string> MessageBox { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBox)} must be assigned by the view layer");


        private string author;
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged("Title"); }
        }

        private int index;
        public int Index { get { return index; } set { index = value; OnPropertyChanged("Index"); } }

        private Data.API.ICatalog catalog;
        public Data.API.ICatalog Catalog
        {
            get { return catalog; }
            set { catalog = value; OnPropertyChanged("Catalog"); }
        }
        private void AddCatalog()
        {
            service.AddCatalog(catalog);
            text = "New catalog added.";
            MessageBox(text);
        }
        private void UpdateCatalogByIndex()
        {
            service.UpdateCatalog(index, catalog);
            text = "Catalog updated";
            MessageBox(text);
        }
        private void UpdateCatalogByTitle()
        {
            service.UpdateCatalog(author, title, catalog);
            text = "Catalog updated";
            MessageBox(text);
        }
        private void DeleteCatalogByIndex()
        {
            service.DeleteCatalog(index);
            text = "Catalog deleted";
            MessageBox(text);
        }
        private void DeleteCatalogByTitle()
        {
            service.DeleteCatalog(author, title);
            text = "Catalog deleted.";
            MessageBox(text);
        }
        private void RefreshCatalogs()
        {
            Catalogs = service.GetAllCatalogs();
        }

        private IEnumerable<ICatalog> catalogs;
        public IEnumerable<ICatalog> Catalogs
        {
            get { return catalogs; }
            set { catalogs = value; OnPropertyChanged("Catalogs"); }
        }
    }
}
