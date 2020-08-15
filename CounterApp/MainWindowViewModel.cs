using System;
using System.ComponentModel;
using System.Windows.Media;

namespace CounterApp
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Counter counter;

        public MainWindowViewModel(Counter counter) {
            this.counter = counter;
            counter.CountChanged += OnCountChanged;
        }

        public void Dispose()
        {
            counter.CountChanged -= OnCountChanged;
        }

        private void OnCountChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CounterText)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CounterTextForeground)));
        }

        public string CounterText
        {
            get => counter.Count.ToString("+#;-#;0"); // +符号を表示する
        }

        public Brush CounterTextForeground
        {
            get
            {
                if (counter.Count < 0)
                    return Brushes.Red;
                if (counter.Count > 0)
                    return Brushes.Green;
                return Brushes.Gray;
            }
        }

        public void Increment()
        {
            counter.Increment();
        }

        public void Decrement()
        {
            counter.Decrement();
        }
    }
}
