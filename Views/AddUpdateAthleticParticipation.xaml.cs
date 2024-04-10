using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateAthleticParticipation : ContentPage
    {
        public AddUpdateAthleticParticipation(AddUpdateAthleticParticipationViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}