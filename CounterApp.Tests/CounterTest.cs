using Xunit;

namespace CounterApp.Tests
{
    public class CounterTest
    {
        [Fact(DisplayName = "初期値が 0 であること")]
        public void InitialValueIsZero()
        {
            var counter = new Counter();
            Assert.Equal(0, counter.Count);
        }

        [Theory(DisplayName = "n回インクリメントする")]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(11, 10)]
        public void Increment(int n, int expectedCount)
        {
            var counter = new Counter();
            for (int i = 0; i < n; i++)
                counter.Increment();
            Assert.Equal(expectedCount, counter.Count);
        }

        [Theory(DisplayName = "n回デクリメントする")]
        [InlineData(1, -1)]
        [InlineData(10, -10)]
        [InlineData(11, -10)]
        public void Decrement(int n, int expectedCount)
        {
            var counter = new Counter();
            for (int i = 0; i < n; i++)
                counter.Decrement();
            Assert.Equal(expectedCount, counter.Count);
        }
    }
}
