using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.API;
using Presentation.ViewModel.MVVM;
using Service.API;

namespace Presentation.ViewModel
{
    internal class ActionViewModel : ViewModelBase
    {
        private IModel model;
        public ActionViewModel(IModel model)
        {
            this.model = model;
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

        public System.Action<string> MessageShowBoxDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageShowBoxDelegate)} must be assigned by view layer.");
    }
}
