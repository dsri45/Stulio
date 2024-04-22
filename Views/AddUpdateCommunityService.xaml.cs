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
    }
}