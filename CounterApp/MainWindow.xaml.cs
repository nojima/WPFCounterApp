using System;
using System.Windows;
using System.Windows.Media;

namespace CounterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Counter counter;

        public MainWindow(Counter counter)
        {
            this.counter = counter;

            InitializeComponent();
            UpdateView();
            counter.CountChanged += UpdateView;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            counter.CountChanged -= UpdateView;
        }

        private void btnIncrement_Click(object sender, RoutedEventArgs e)
        {
            counter.Increment();
        }

        private void btnDecrement_Click(object sender, RoutedEventArgs e)
        {
            counter.Decrement();
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
