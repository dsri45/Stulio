using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateCommunityService : ContentPage
    {
        public AddUpdateCommunityService(AddUpdateCommunityServiceViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}