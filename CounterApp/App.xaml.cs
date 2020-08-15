﻿using System.Windows;

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
            var window = new MainWindow(counter);
            window.Show();
        }
    }
}
