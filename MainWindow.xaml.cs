using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Win_UI_Sample.Pages;
using Win_UI_Sample.Repositories;

namespace Win_UI_Sample
{
    public sealed partial class MainWindow : Window
    {
        // Shared instance of TraineeRepository

        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "Trainee Management";

            // Navigate to HomePage, passing TraineeRepository as a parameter
            MainFrame.Navigate(typeof(HomePage));
        }
    }
}
