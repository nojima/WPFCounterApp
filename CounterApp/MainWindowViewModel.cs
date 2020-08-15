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

        public ReadOnlyReactivePropertySlim<string> CounterText { get; }
        public ReadOnlyReactivePropertySlim<Brush> CounterTextForeground { get; }
        public ReactiveCommand IncrementCommand { get; } = new ReactiveCommand();
        public ReactiveCommand DecrementCommand { get; } = new ReactiveCommand();

        public MainWindowViewModel(Counter counter)
        {
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

            IncrementCommand.Subscribe(() => counter.Increment());
            DecrementCommand.Subscribe(() => counter.Decrement());
        }

        public void Dispose()
        {
            CounterText.Dispose();
            CounterTextForeground.Dispose();
            IncrementCommand.Dispose();
            DecrementCommand.Dispose();
        }
    }
}
