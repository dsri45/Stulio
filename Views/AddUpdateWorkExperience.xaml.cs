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
    }
}