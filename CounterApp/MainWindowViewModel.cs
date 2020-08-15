using System;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Media;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace CounterApp
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDisposable
    {
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore

        private readonly CompositeDisposable disposable = new CompositeDisposable();

        public IReadOnlyReactiveProperty<string> CounterText { get; }
        public IReadOnlyReactiveProperty<Brush> CounterTextForeground { get; }
        public ReactiveCommand IncrementCommand { get; }
        public ReactiveCommand DecrementCommand { get; }

        public MainWindowViewModel(Counter counter)
        {
            CounterText = counter.Count
                .Select(c => c.ToString("+#;-#;0"))
                .ToReadOnlyReactivePropertySlim()
                .AddTo(disposable);

            CounterTextForeground = counter.Count
                .Select(c =>
                {
                    if (c < 0)
                        return (Brush)Brushes.Red;
                    if (c > 0)
                        return (Brush)Brushes.Green;
                    return (Brush)Brushes.Gray;
                })
                .ToReadOnlyReactivePropertySlim()
                .AddTo(disposable);

            IncrementCommand = new ReactiveCommand().AddTo(disposable);
            IncrementCommand.Subscribe(() => counter.Increment());

            DecrementCommand = new ReactiveCommand().AddTo(disposable);
            DecrementCommand.Subscribe(() => counter.Decrement());
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}
