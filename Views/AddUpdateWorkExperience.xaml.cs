using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateWorkExperience : ContentPage
    {
        public AddUpdateWorkExperience(AddUpdateWorkExperienceViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}