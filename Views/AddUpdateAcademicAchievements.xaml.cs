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
    }
}