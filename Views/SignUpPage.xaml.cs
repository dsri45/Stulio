using Stulio.ViewModels;

namespace Stulio.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(UserViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}

