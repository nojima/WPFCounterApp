namespace CounterApp
{
    public class Counter
    {
        private const int MAX_COUNT = 10;
        private const int MIN_COUNT = -10;

        public int Count { get; private set; } = 0;

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
