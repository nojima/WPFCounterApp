using Reactive.Bindings;

namespace CounterApp
{
    public class Counter
    {
        private const int MAX_COUNT = 10;
        private const int MIN_COUNT = -10;

        public ReactivePropertySlim<int> Count { get; }

        public Counter(int initialValue = 0)
        {
            Count = new ReactivePropertySlim<int>(initialValue);
        }

        public void Increment()
        {
            if (Count.Value < MAX_COUNT)
                Count.Value++;
        }

        public void Decrement()
        {
            if (Count.Value > MIN_COUNT)
                Count.Value--;
        }
    }
}
