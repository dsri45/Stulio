
using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdatePersonalEndeavors : ContentPage
    {
        private AddUpdatePersonalEndeavorsViewModel _viewMode;
        public AddUpdatePersonalEndeavors(AddUpdatePersonalEndeavorsViewModel viewModel)
        {
            InitializeComponent();
            _viewMode = viewModel;
            this.BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewMode.LoadPersonalEndeavorsByID();

        }
    }
}