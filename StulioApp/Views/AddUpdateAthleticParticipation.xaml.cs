using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class AddUpdateAthleticParticipation : ContentPage
    {
        private AddUpdateAthleticParticipationViewModel _viewMode;
        public AddUpdateAthleticParticipation(AddUpdateAthleticParticipationViewModel viewModel)
        {
            InitializeComponent();
            _viewMode = viewModel;
            this.BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewMode.LoadAthleticParticipationByID();

        }
    }
}