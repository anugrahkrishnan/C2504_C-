using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CounterMvvmProject
{
    public class CounterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Counter _displayCount;
        public Counter DisplayCount
        {
            get { return _displayCount; }
            set
            {
                _displayCount = value;
                OnPropertyChanged(nameof(DisplayCount));
            }
        }

        public ICommand IncrementCount { get; }
        public ICommand DecrementCount { get; }

        public CounterViewModel()
        {
            DisplayCount = new Counter { Count = 0 };
            IncrementCount = new RelayCommand(Increment);
            DecrementCount = new RelayCommand(Decrement);
        }

        public void Increment()
        {
            DisplayCount.Count++;
            DisplayCount = DisplayCount;
        }
        public void Decrement()
        {
            DisplayCount.Count--;
            DisplayCount = DisplayCount;

        }
    }
}
