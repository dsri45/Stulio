using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateStudentDetail : ContentPage
    {
        public AddUpdateStudentDetail(AddUpdateStudentViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}