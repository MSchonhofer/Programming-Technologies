﻿using Presentation.ViewModel.MVVM;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModel
{
    public class ReaderViewModel : ViewModelBase
    {
        private IService service;
        public ReaderViewModel(IService service)
        {
            this.service = service;
            
        }
        public RelayCommand AddReaderCommand { get; private set; }
        public RelayCommand DeleteReaderCommand { get; private set; }
        public RelayCommand UpdateReaderCommand { get; private set; }

        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged("Text"); }
        }

        public Action<string> MessageBox { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBox)} must be assigned by the view layer");

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; OnPropertyChanged("Surname"); }
        }

    }
    
}
