using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace VokabelTrainer3.ViewModels
{
    public class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Set<T>(ref T backingField, T value, [CallerMemberName] string callerName = null) where T : class
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value)) return;

            backingField = value;

            OnPropertyChanged(callerName);
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
