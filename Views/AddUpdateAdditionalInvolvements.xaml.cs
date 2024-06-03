using Stulio.ViewModels;

namespace Stulio.Views
{

      public partial class AddUpdateAdditionalInvolvements : ContentPage
    {
        private AddUpdateAdditionalInvolvementsViewModel _viewMode;
        public AddUpdateAdditionalInvolvements(AddUpdateAdditionalInvolvementsViewModel viewModel)
        {
            InitializeComponent();
            _viewMode = viewModel;
            this.BindingContext = viewModel;
          
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewMode.LoadAdditionalInvolvementsByID();

        }

    }
}