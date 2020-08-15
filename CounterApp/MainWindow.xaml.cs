using System.Windows;

namespace CounterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnIncrement_Click(object sender, RoutedEventArgs e)
        {
            count++;
            tbCounter.Text = count.ToString();
        }

        private void btnDecrement_Click(object sender, RoutedEventArgs e)
        {
            count--;
            tbCounter.Text = count.ToString();
        }
    }
}
