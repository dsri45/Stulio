using Stulio.ViewModels;

namespace Stulio.Views
{
    [QueryProperty(nameof(AcademicAchievements), "AcademicAchievements")]
    public partial class AddUpdateAcademicAchievements : ContentPage
    {
        private AddUpdateAcademicAchievementsViewModel _viewMode;
        public AddUpdateAcademicAchievements(AddUpdateAcademicAchievementsViewModel viewModel)
        {
            
            InitializeComponent();
            _viewMode = viewModel;
            this.BindingContext = viewModel;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewMode.LoadAcademicAchievementsByID();

        }

        private async void UpdateAcademicAchievementsCommand_Clicked(object sender, EventArgs e)
        {

            // Perform field validation
            if (string.IsNullOrWhiteSpace(_viewMode.AcademicAchievements.Class))
            {
                await DisplayAlert("Error", "Club Name cannot be empty", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(_viewMode.AcademicAchievements.Award))
            {
                await DisplayAlert("Error", "Organization cannot be empty", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(_viewMode.AcademicAchievements.Description))
            {
                await DisplayAlert("Error", "Description cannot be empty", "OK");
                return;
            }

            else
            {

                _viewMode.UpdateAcademicAchievementsCommand.Execute(null);

            }
        }
    }
}