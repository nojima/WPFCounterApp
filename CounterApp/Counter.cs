using System;
using System.Reactive.Subjects;

namespace CounterApp
{
    public class Counter
    {
        private const int MAX_COUNT = 10;
        private const int MIN_COUNT = -10;

        private readonly BehaviorSubject<int> count;
 
        public Counter(int initialValue = 0)
        {
            count = new BehaviorSubject<int>(initialValue);
        }

        public IObservable<int> Count {
            get => count;
        }

        public void Increment()
        {
            if (count.Value < MAX_COUNT)
                count.OnNext(count.Value + 1);
        }

        public void Decrement()
        {
            if (count.Value > MIN_COUNT)
                count.OnNext(count.Value - 1);
        }
    }
}
