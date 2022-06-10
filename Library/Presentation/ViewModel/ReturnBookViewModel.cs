using Presentation.ViewModel.MVVM;
using Service.API;
using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModel
{
    internal class ReturnBookViewModel : ViewModelBase
    {
        private IService service;
        public ReturnBookViewModel(IService service)
        {
            this.service = service;
            ReturnBookCommand = new RelayCommand(ReturnBook);
        }
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged("Text"); }
        }
        public Action<string> MessageBox { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBox)} must be assigned by the view layer");
        public RelayCommand ReturnBookCommand { get; private set; }
        private IBook book;
        public IBook Book
        {
            get { return book; }
            set
            {
                book = value;
                OnPropertyChanged("Book");
            }
        }
       
        private Data.API.IReader reader;
        public Data.API.IReader Reader
        {
            get { return reader;}
            set { reader = value; OnPropertyChanged("Reader"); }
        }
        public void ReturnBook()
        {
            service.ReturnBook(book, reader);
            text = "Book returned.";
            MessageBox(text);
        }

    }
}
