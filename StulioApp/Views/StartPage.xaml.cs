namespace Stulio.Views;
using Stulio.ViewModels;
using Stulio.Views;
using Stulio.Models;
using Stulio.Services;


public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
        
    }
    private async void Login_Clicked(object sender, EventArgs e)
    {
        UserService userservice = new UserService();
        var userViewModel = new LoginPageViewModel(userservice);
        await Navigation.PushAsync(new LoginPage(userViewModel));
    }

    private async void SignUpButton_Clicked(object sender, EventArgs e)
    {
        UserService userservice = new UserService();
        var userViewModel = new UserViewModel(userservice);
        await Navigation.PushAsync(new SignUpPage(userViewModel));
    }


}