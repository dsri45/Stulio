
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

        private async void UpdatePersonalEndeavorsCommand_Clicked(object sender, EventArgs e)
        {

            // Perform field validation
            if (string.IsNullOrWhiteSpace(_viewMode.PersonalEndeavors.Title))
            {
                await DisplayAlert("Error", "Endeavor cannot be empty", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(_viewMode.PersonalEndeavors.Description))
            {
                await DisplayAlert("Error", "Description cannot be empty", "OK");
                return;
            }

            else
            {
                _viewMode.UpdatePersonalEndeavorsCommand.Execute(null);

            }
        }

    }
}