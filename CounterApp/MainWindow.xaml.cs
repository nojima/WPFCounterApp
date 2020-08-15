using System;
using System.Windows;

namespace CounterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel viewModel;

        public MainWindow(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
            DataContext = viewModel;
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            viewModel.Dispose();
        }

        private void btnIncrement_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Increment();
        }

        private void btnDecrement_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Decrement();
        }
    }
}
