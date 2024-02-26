using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class ProfilePage : ContentPage
    {
    
        public ProfilePage(ProfilePageViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}