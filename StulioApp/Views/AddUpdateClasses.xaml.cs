
using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateClasses : ContentPage
    {
        private AddUpdateClassesViewModel _viewMode;
        public AddUpdateClasses(AddUpdateClassesViewModel viewModel)
        {
            InitializeComponent();
            _viewMode = viewModel;
            this.BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewMode.LoadClassesByID();

        }
    }
}