using Presentation.ViewModel.MVVM;
using Data.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModel
{
    internal class RentBookViewModel :ViewModelBase
    {
        private IService service;
        public RentBookViewModel(IService service)
        {
            this.service = service;
            RentBookCommand = new RelayCommand(RentBook);
        }
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged("Text"); }
        }
        public Action<string> MessageBox { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBox)} must be assigned by the view layer");
        public RelayCommand RentBookCommand { get; private set; }
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

        private Data.API.IReader reader;
        public Data.API.IReader Reader
        {
            get { return reader; }
            set { reader = value; OnPropertyChanged("Reader"); }
        }
        public void RentBook()
        {
            service.RentBook(Author, Title, reader);
            text = "Book rented.";
            MessageBox(text);
        }

    }
}

