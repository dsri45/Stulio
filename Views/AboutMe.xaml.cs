using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AboutMe : ContentPage
    {
        public AboutMe(AboutMeViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}