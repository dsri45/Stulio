using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateWorkExperience : ContentPage
    {
        private AddUpdateWorkExperienceViewModel _viewMode;
        public AddUpdateWorkExperience(AddUpdateWorkExperienceViewModel viewModel)
        {
            InitializeComponent();
            _viewMode = viewModel;
            this.BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewMode.LoadWorkExperienceByID();

        }

        private async void UpdateWorkExperienceCommand_Clicked(object sender, EventArgs e)
        {

            // Perform field validation
            if (string.IsNullOrWhiteSpace(_viewMode.WorkExperience.Role))
            {
                await DisplayAlert("Error", "Role cannot be empty", "OK");
                return;
            }


            if (string.IsNullOrWhiteSpace(_viewMode.WorkExperience.Establishment))
            {
                await DisplayAlert("Error", "Establishment cannot be empty", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(_viewMode.WorkExperience.Description))
            {
                await DisplayAlert("Error", "Achivements cannot be empty", "OK");
                return;
            }

            // Perform validation
            if (_viewMode.WorkExperience.EndDate < _viewMode.WorkExperience.StartDate)
            {
                await DisplayAlert("Error", "End Date cannot be earlier than Start Date", "OK");
                return; // Prevent further execution
            }
            else
            {

                _viewMode.UpdateWorkExperienceCommand.Execute(null);

            }
        }
    }
}