using Microsoft.Maui.Controls;
using Stulio.ViewModels; // Replace with your actual namespace
using Xamarin.Essentials;
using Microsoft.Maui.Controls;

namespace Stulio.Views
{
    public partial class Resume : ContentPage
    {
        private readonly ShowStudentProfileViewModel _viewModel;

        public Resume(ShowStudentProfileViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Optionally, load initial data or perform actions when the page appears
            await _viewModel.LoadRecords(); // Example method to load student records
        }

        //private async void GenerateResumeButton_Clicked(object sender, EventArgs e)
        //{
        //    string fileName = "resume.pdf";
        //    string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

        //    await _viewModel.GenerateResumePdf(filePath);

        //    // Optionally, display a message or perform other actions after generating PDF
        //    // Example: await DisplayAlert("Resume Generated", "Resume PDF generated successfully.", "OK");
        //}
    }
}

