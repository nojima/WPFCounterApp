namespace CounterApp
{
    public delegate void CountChanged();

    public class Counter
    {
        private const int MAX_COUNT = 10;
        private const int MIN_COUNT = -10;

        private int count;

        public Counter(int initialValue = 0)
        {
            count = initialValue;
        }

        public int Count
        {
            get => count;

            private set
            {
                count = value;
                CountChanged?.Invoke();
            }
        }

        public event CountChanged CountChanged;

        public void Increment()
        {
            if (Count < MAX_COUNT)
                Count++;
        }

        public void Decrement()
        {
            if (Count > MIN_COUNT)
                Count--;
        }
    }
}
