
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

        private async void UpdateClassesCommand_Clicked(object sender, EventArgs e)
        {

            // Perform field validation
            if (string.IsNullOrWhiteSpace(_viewMode.Classes.Name))
            {
                await DisplayAlert("Error", "Class Name cannot be empty", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(_viewMode.Classes.Grade))
            {
                await DisplayAlert("Error", "Grade cannot be empty", "OK");
                return;
            }
            else
            {
                _viewMode.UpdateClassesCommand.Execute(null);
            }
        }
    }
}