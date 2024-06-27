using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateCommunityService : ContentPage
    {
        private AddUpdateCommunityServiceViewModel _viewMode;
        public AddUpdateCommunityService(AddUpdateCommunityServiceViewModel viewModel)
        {
            InitializeComponent();
            _viewMode = viewModel;
            this.BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewMode.LoadCommunityServiceByID();

        }

        private async void UpdateCommunityServiceCommand_Clicked(object sender, EventArgs e)
        {

            // Perform field validation
            if (string.IsNullOrWhiteSpace(_viewMode.CommunityService.ServiceName))
            {
                await DisplayAlert("Error", "Service Name cannot be empty", "OK");
                return;
            }

           

            if (string.IsNullOrWhiteSpace(_viewMode.CommunityService.VoulnteeredHours))
            {
                await DisplayAlert("Error", "Voulnteered Hours cannot be empty", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(_viewMode.CommunityService.Description))
            {
                await DisplayAlert("Error", "Achivements cannot be empty", "OK");
                return;
            }

            // Perform validation
            if (_viewMode.CommunityService.EndDate < _viewMode.CommunityService.StartDate)
            {
                await DisplayAlert("Error", "End Date cannot be earlier than Start Date", "OK");
                return; // Prevent further execution
            }
            else
            {

                _viewMode.UpdateCommunityServiceCommand.Execute(null);

            }
        }
        }
}