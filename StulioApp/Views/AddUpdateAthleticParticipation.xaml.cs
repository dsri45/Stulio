using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateAthleticParticipation : ContentPage
    {
        private AddUpdateAthleticParticipationViewModel _viewMode;
        public AddUpdateAthleticParticipation(AddUpdateAthleticParticipationViewModel viewModel)
        {
            InitializeComponent();
            _viewMode = viewModel;
            this.BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewMode.LoadAthleticParticipationByID();

        }

        private async void UpdateAthleticParticipationCommand_Clicked(object sender, EventArgs e)
        {

           
            if (string.IsNullOrWhiteSpace(_viewMode.AthleticParticipation.Sport))
            {
                await DisplayAlert("Error", "Sport cannot be empty", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(_viewMode.AthleticParticipation.Role))
            {
                await DisplayAlert("Error", "Role cannot be empty", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(_viewMode.AthleticParticipation.Achivements))
            {
                await DisplayAlert("Error", "Achivements cannot be empty", "OK");
                return;
            }

            else
            {

                _viewMode.UpdateAthleticParticipationCommand.Execute(null);

            }
        }
    }
}