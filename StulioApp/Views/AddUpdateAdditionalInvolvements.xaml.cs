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

        private async void UpdateAdditionalInvolvementsCommand_Clicked(object sender, EventArgs e)
        {

            // Perform field validation
            if (string.IsNullOrWhiteSpace(_viewMode.AdditionalInvolvements.ActivityName))
            {
                await DisplayAlert("Error", "Activity Name cannot be empty", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(_viewMode.AdditionalInvolvements.Description))
            {
                await DisplayAlert("Error", "Description cannot be empty", "OK");
                return;
            }
      
            else
            {
                _viewMode.UpdateAdditionalInvolvementsCommand.Execute(null);

            }
        }

    }
}