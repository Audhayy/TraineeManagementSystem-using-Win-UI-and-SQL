using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Win_UI_Sample.Repositories;
using Win_UI_Sample.Service;
using Win_UI_Sample.Services;

namespace Win_UI_Sample.Pages
{
    public sealed partial class AddTraineePage : Page
    {
        private readonly Regex emailRegex = new(@"^[^@\s]+@[^@\s]+\.(com|in)$", RegexOptions.Compiled);
        private readonly ITraineeService _traineeService;

        // Constructor accepting TraineeRepository
        public AddTraineePage()
        {
            this.InitializeComponent();
            _traineeService = new TraineeService(); // Only initialize once
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IdTextBox.Text) ||
      string.IsNullOrWhiteSpace(TraineeNameTextBox.Text) ||
      string.IsNullOrWhiteSpace(MobileNumberTextBox.Text) ||
      string.IsNullOrWhiteSpace(TraineeAddressTextBox.Text) ||
      !DateOfBirthPicker.Date.HasValue ||
      string.IsNullOrWhiteSpace(TraineeQualificationTextBox.Text) ||
      string.IsNullOrWhiteSpace(TraineeEmailTextBox.Text) ||

      DepartmentComboBox.SelectedItem == null)
            {
                var dialogs = new ContentDialog
                {
                    Title = "Validation Error",
                    Content = "Please fill in all mandatory fields.",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };
                await dialogs.ShowAsync(); // Show the dialog asynchronously
                return;
            }
            string selectedDepartment = (DepartmentComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            var traineeData = new Dictionary<string, object>
            {
                { "Id", IdTextBox.Text },
                { "Name", TraineeNameTextBox.Text },
                { "MobileNumber", MobileNumberTextBox.Text },
                { "Address", TraineeAddressTextBox.Text },
                { "DateOfBirth", DateOfBirthPicker.Date.Value.Date },
                { "Qualification", TraineeQualificationTextBox.Text },
                { "Department", selectedDepartment },
                { "Email", TraineeEmailTextBox.Text },
                { "StartDate", StartDatePicker.Date.DateTime },
                { "EndDate", EndDatePicker.Date.DateTime }
            };


            //await _traineeService.AddTraineeAsync(traineeData);
            _traineeService.AddTrainee(traineeData);

            var dialog = new ContentDialog
            {
                Title = "Success",
                Content = "Trainee has been successfully stored.",
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot
            };

            await dialog.ShowAsync();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void IdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int cursorPosition = IdTextBox.SelectionStart;

            string filteredText = new string(IdTextBox.Text.Where(char.IsDigit).ToArray());

            if (IdTextBox.Text != filteredText)
            {
                IdTextBox.Text = filteredText;
                IdTextBox.SelectionStart = Math.Min(cursorPosition, filteredText.Length);
                IdError.Visibility = Visibility.Visible;
            }
            else
            {
                IdError.Visibility = Visibility.Collapsed;
            }
        }

        private void MobileTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int cursorPosition = MobileNumberTextBox.SelectionStart; // Corrected to MobileNumberTextBox

            string filteredText = new string(MobileNumberTextBox.Text.Where(char.IsDigit).ToArray());

            if (MobileNumberTextBox.Text != filteredText)
            {
                MobileNumberTextBox.Text = filteredText;
                MobileNumberTextBox.SelectionStart = Math.Min(cursorPosition, filteredText.Length);
                MobileError.Visibility = Visibility.Visible; // Ensure you have MobileError defined in XAML
            }
            else
            {
                MobileError.Visibility = Visibility.Collapsed;
            }
        }

        private void TraineeNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int cursorPosition = TraineeNameTextBox.SelectionStart;

            string filteredText = new string(TraineeNameTextBox.Text.Where(char.IsLetter).ToArray());

            if (TraineeNameTextBox.Text != filteredText)
            {
                TraineeNameTextBox.Text = filteredText;
                TraineeNameTextBox.SelectionStart = Math.Min(cursorPosition, filteredText.Length);
            }
        }

        private void TraineeEmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string email = TraineeEmailTextBox.Text;

            if (emailRegex.IsMatch(email))
            {
                EmailErrorTextBlock.Visibility = Visibility.Collapsed; 
            }
            else
            {
                EmailErrorTextBlock.Visibility = Visibility.Visible;
            }
        }
        private void EmptyTextBox()
        {
            IdTextBox.Text = string.Empty;
            TraineeNameTextBox.Text = string.Empty;
            MobileNumberTextBox.Text = string.Empty;
            TraineeAddressTextBox.Text = string.Empty;
            TraineeEmailTextBox.Text = string.Empty;
            TraineeQualificationTextBox.Text = string.Empty;
            DateOfBirthPicker.Date = DateTimeOffset.Now;
            DepartmentComboBox.SelectedItem = null;
            StartDatePicker.Date = DateTimeOffset.Now;
            EndDatePicker.Date = DateTimeOffset.Now;
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            EmptyTextBox();
        }
    }
}