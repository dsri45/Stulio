using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateAdditionalInvolvements : ContentPage
    {
        public AddUpdateAdditionalInvolvements(AddUpdateAdditionalInvolvementsViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}