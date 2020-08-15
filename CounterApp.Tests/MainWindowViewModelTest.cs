using System.Windows.Media;
using Xunit;

namespace CounterApp.Tests
{
    public class MainWindowViewModelTest
    {
        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "+1")]
        [InlineData(-1, "-1")]
        public void CounterText(int count, string expectedText)
        {
            var counter = new Counter(count);
            using var viewModel = new MainWindowViewModel(counter);
            Assert.Equal(expectedText, viewModel.CounterText.Value);
        }

        public static object[][] CounterTextForegroundInput = new object[][]
        {
            new object[] { 0, Brushes.Gray },
            new object[] { 1, Brushes.Green },
            new object[] { -1, Brushes.Red },
        };
        [Theory]
        [MemberData(nameof(CounterTextForegroundInput))]
        public void CounterTextForeground(int count, Brush expectedBrush)
        {
            var counter = new Counter(count);
            using var viewModel = new MainWindowViewModel(counter);
            Assert.Equal(expectedBrush, viewModel.CounterTextForeground.Value);
        }
    }
}
