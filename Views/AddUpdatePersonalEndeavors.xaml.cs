
using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdatePersonalEndeavors : ContentPage
    {
        public AddUpdatePersonalEndeavors(AddUpdatePersonalEndeavorsViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}