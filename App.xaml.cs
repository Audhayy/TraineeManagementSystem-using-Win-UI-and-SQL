using Microsoft.UI.Xaml; // Make sure to include Microsoft.UI.Xaml for the App class and LaunchActivatedEventArgs
using Microsoft.UI.Xaml.Controls; // Necessary for controls like Window

namespace Win_UI_Sample
{
    public partial class App : Application
    {
        private MainWindow m_window; // Field to hold the instance of MainWindow

        /// <summary>
        /// Initializes the singleton application object. This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args) // Use the correct type here
        {
            if (m_window == null)
            {
                m_window = new MainWindow();
                m_window.Activate();
            }
        }
    }
}
