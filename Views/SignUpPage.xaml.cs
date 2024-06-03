using Stulio.ViewModels;

namespace Stulio.Views;

public partial class SignUpPage : ContentPage
{
    private UserViewModel _viewMode;
    public SignUpPage(UserViewModel viewModel)
	{
		InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;
    }
}

