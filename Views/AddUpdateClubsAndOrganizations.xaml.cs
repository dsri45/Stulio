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
    }
}