using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using Win_UI_Sample.Services;
using Win_UI_Sample.Repositories;
using Win_UI_Sample.Service;

namespace Win_UI_Sample.Pages
{
    public sealed partial class TraineeListPage : Page
    {
        private readonly ITraineeService _traineeService ;
        public List<Dictionary<string, object>> Trainees { get; set; }

        public TraineeListPage()
        {
            this.InitializeComponent();
            // Load trainees from the service
            //Trainees = _traineeService.GetTrainees();
            var traineeRepository = TraineeRepository.Instance;
            var traineesList = traineeRepository.GetAllTrainees();
            Trainees = new List<Dictionary<string, object>>(traineesList);

            // Bind the data to the ListView
            TraineeListView.ItemsSource = Trainees;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }
    }
}
