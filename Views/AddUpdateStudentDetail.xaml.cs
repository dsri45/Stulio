using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateStudentDetail : ContentPage
    {
        public AddUpdateStudentDetail(AddUpdateStudentDetailViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}