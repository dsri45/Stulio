
using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateClasses : ContentPage
    {
        public AddUpdateClasses(AddUpdateClassesViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}