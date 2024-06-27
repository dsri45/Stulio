using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateClubsAndOrganizations : ContentPage
    {

        private AddUpdateClubsAndOrganizationsViewModel _viewMode;
        public AddUpdateClubsAndOrganizations(AddUpdateClubsAndOrganizationsViewModel viewModel)
        {
            InitializeComponent();
            _viewMode = viewModel;
            this.BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewMode.LoadClubsAndOrganizationsByID();

        }

        private async void UpdateClubsAndOrganizationsCommand_Clicked(object sender, EventArgs e)
        {

            // Perform field validation
            if (string.IsNullOrWhiteSpace(_viewMode.ClubsAndOrganizations.ClubName))
            {
                await DisplayAlert("Error", "Club Name cannot be empty", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(_viewMode.ClubsAndOrganizations.Role))
            {
                await DisplayAlert("Error", "Role cannot be empty", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(_viewMode.ClubsAndOrganizations.Description))
            {
                await DisplayAlert("Error", "Description cannot be empty", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(_viewMode.ClubsAndOrganizations.Achivements))
            {
                await DisplayAlert("Error", "Achivements cannot be empty", "OK");
                return;
            }

            // Perform validation
            if (_viewMode.ClubsAndOrganizations.EndDate < _viewMode.ClubsAndOrganizations.StartDate)
            {
                await DisplayAlert("Error", "End Date cannot be earlier than Start Date", "OK");
                return; // Prevent further execution
            }
            else
            {

                _viewMode.UpdateClubsAndOrganizationsCommand.Execute(null);

            }
        }
    }
}