using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Logic.API;

namespace Presentation.ViewModel.MVVM
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region bookModel
        private IEnumerable<IBook> booksModel;
        public IEnumerable<IBook> BooksModel
        {
            get { return booksModel; }
            set { booksModel = value; }
        }
        private IBook selectedBook;
        public IBook SelectedBook
        {
            get { return selectedBook; }
            set 
            { 
                selectedBook = value; 
                OnPropertyChanged(nameof(SelectedBook));
            }
        }
        public void ReturnBook()
        {
            
        }
        #endregion
    }
}

    
