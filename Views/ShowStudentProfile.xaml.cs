using Stulio.ViewModels;

namespace Stulio.Views
{

    public partial class ShowStudentProfile : ContentPage
    {
        private readonly ShowStudentProfileViewModel _viewModel;
        public ShowStudentProfile(ShowStudentProfileViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadRecords();
        }
    }
}