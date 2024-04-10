using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateClubsAndOrganizations : ContentPage
    {
        public AddUpdateClubsAndOrganizations(AddUpdateClubsAndOrganizationsViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}