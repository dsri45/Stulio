using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class ProfilePage : ContentPage
    {
        private ProfilePageViewModel _viewMode;
        public ProfilePage(ProfilePageViewModel viewModel)
        {
            InitializeComponent();
            _viewMode = viewModel;
            this.BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewMode.LoadByStudentIDCommand.Execute(null);
        }

    }
}


