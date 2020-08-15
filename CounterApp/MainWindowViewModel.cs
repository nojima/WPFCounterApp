using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Windows.Media;
using Reactive.Bindings;

namespace CounterApp
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Counter counter;

        public ReadOnlyReactivePropertySlim<string> CounterText { get; }
        public ReadOnlyReactivePropertySlim<Brush> CounterTextForeground { get; }

        public MainWindowViewModel(Counter counter)
        {
            this.counter = counter;

            CounterText = counter.Count
                .Select(c => c.ToString("+#;-#;0"))
                .ToReadOnlyReactivePropertySlim();

            CounterTextForeground = counter.Count
                .Select(c =>
                {
                    if (c < 0)
                        return (Brush)Brushes.Red;
                    if (c > 0)
                        return (Brush)Brushes.Green;
                    return (Brush)Brushes.Gray;
                })
                .ToReadOnlyReactivePropertySlim();
        }

        public void Dispose()
        {
            CounterText.Dispose();
            CounterTextForeground.Dispose();
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
