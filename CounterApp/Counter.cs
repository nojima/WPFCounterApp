using Reactive.Bindings;

namespace CounterApp
{
    public class Counter
    {
        private const int MAX_COUNT = 10;
        private const int MIN_COUNT = -10;

        private readonly ReactivePropertySlim<int> count;
 
        public Counter(int initialValue = 0)
        {
            count = new ReactivePropertySlim<int>(initialValue);
        }

        public IReadOnlyReactiveProperty<int> Count {
            get => count;
        }

        public void Increment()
        {
            if (count.Value < MAX_COUNT)
                count.Value++;
        }

        public void Decrement()
        {
            if (count.Value > MIN_COUNT)
                count.Value--;
        }
    }
}
