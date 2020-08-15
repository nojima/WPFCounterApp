using System.Windows;
using System.Windows.Media;

namespace CounterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Counter counter = new Counter();

        public MainWindow()
        {
            InitializeComponent();
            UpdateView();
        }

        private void btnIncrement_Click(object sender, RoutedEventArgs e)
        {
            counter.Increment();
            UpdateView();
        }

        private void btnDecrement_Click(object sender, RoutedEventArgs e)
        {
            counter.Decrement();
            UpdateView();
        }

        private void UpdateView()
        {
            tbCounter.Text = counter.Count.ToString("+#;-#;0"); // +符号を表示する

            if (counter.Count < 0)
                tbCounter.Foreground = Brushes.Red;
            else if (counter.Count > 0)
                tbCounter.Foreground = Brushes.Green;
            else
                tbCounter.Foreground = Brushes.Gray;
        }
    }
}
