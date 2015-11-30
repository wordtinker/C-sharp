using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Add Reference dialog box and add a reference to WindowsBase.dll,
// PresentationCore.dll, System.Xaml.dll, and PresentationFramework.dll.

namespace WpfAppAllCode
{
    class MainWindow : Window
    {
        // Our UI element.
        private Button btnExitApp = new Button();

        public MainWindow(string windowTitle, int height, int width)
        {
            // Configure button and set the child control.
            btnExitApp.Click += btnExitApp_Clicked;
            btnExitApp.Content = "Exit Application";
            btnExitApp.Height = 25;
            btnExitApp.Width = 100;

            // Set the content of this window to a single button.
            this.Content = btnExitApp;

            this.Title = windowTitle;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Height = height;
            this.Width = width;

            this.Closing += MainWindow_Closing;
            this.Closed += MainWindow_Closed;
            this.MouseMove += MainWindow_MouseMove;
            this.KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            btnExitApp.Content = e.Key.ToString();
        }

        private void MainWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Title = e.GetPosition(this).ToString();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("See ya!");
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // See if the user really wants to shut down this window.
            string msg = "Do you want to close without saving?";
            MessageBoxResult result = MessageBox.Show(msg,
            "My App", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                // If user doesn't want to close, cancel closure.
                e.Cancel = true;
            }
        }

        private void btnExitApp_Clicked(object sender, RoutedEventArgs e)
        {
            // Did user enable /godmode?
            if ((bool)Application.Current.Properties["GodMode"])
                MessageBox.Show("Cheater!");

            // Close the window.
            this.Close(); ;
        }
    }

    class Program: Application
    {
        [STAThread]
        static void Main(string[] args)
        {
            Program app = new Program();
            app.Startup += AppStartup;
            app.Exit += AppExit;
            app.Run();
        }

        private static void AppStartup(object sender, StartupEventArgs e)
        {
            // Check the incoming command-line arguments and see if they
            // specified a flag for /GODMODE.
            Application.Current.Properties["GodMode"] = false;
            foreach (string arg in e.Args)
            {
                if (arg.ToLower() == "/godmode")
                {
                    Application.Current.Properties["GodMode"] = true;
                    break;
                }
            }

            MainWindow mainWindow = new MainWindow("My first app!", 200, 300);
            mainWindow.Show();
        }

        private static void AppExit(object sender, ExitEventArgs e)
        {
            MessageBox.Show("App has exited.");
        }
    }
}
