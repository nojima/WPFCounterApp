using System.Windows;

namespace CounterApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var counter = new Counter();
            var viewModel = new MainWindowViewModel(counter);
            var window = new MainWindow(viewModel);
            window.Show();
        }
    }
}
