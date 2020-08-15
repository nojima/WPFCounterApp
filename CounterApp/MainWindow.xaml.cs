using System.Windows;
using System.Windows.Media;

namespace CounterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int MAX_COUNT = 10;
        private const int MIN_COUNT = -10;

        private int count = 0;

        public MainWindow()
        {
            InitializeComponent();
            UpdateView();
        }

        private void btnIncrement_Click(object sender, RoutedEventArgs e)
        {
            if (count < MAX_COUNT)
                count++;
            UpdateView();
        }

        private void btnDecrement_Click(object sender, RoutedEventArgs e)
        {
            if (count > MIN_COUNT)
                count--;
            UpdateView();
        }

        private void UpdateView()
        {
            tbCounter.Text = count.ToString("+#;-#;0"); // +符号を表示する

            if (count < 0)
                tbCounter.Foreground = Brushes.Red;
            else if (count > 0)
                tbCounter.Foreground = Brushes.Green;
            else
                tbCounter.Foreground = Brushes.Gray;
        }
    }
}
