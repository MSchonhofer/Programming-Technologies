using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Presentation.API;
using Presentation.ViewModel.MVVM;
using Service.API;

namespace Presentation.ViewModel
{
    public class ReaderViewModel : ViewModelBase
    {
        private IModel model;
        public ReaderViewModel(IModel model)
        {
            this.model = model;
            AddReaderCommand = new RelayCommand(AddReader);
            UpdateReaderCommand = new RelayCommand(UpdateReader);
            DeleteReaderCommand = new RelayCommand(DeleteReader);
            RefreshReaderCommand = new RelayCommand(RefreshReader);

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
