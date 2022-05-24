using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModel.MVVM
{
    public abstract class ViewModelBase : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            // [CallerMemberName] is not required, but it allows to write OnPropertyChanged(); instead of
            // OnPropertyChanged("Some Property")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool SetProperty<T>(ref T strorage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(strorage, value))
                return false;
            strorage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
}
