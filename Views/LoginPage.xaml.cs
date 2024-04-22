
using Stulio.Models;
using Stulio.Services;
using Stulio.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace Stulio.Views;

public partial class LoginPage : ContentPage
{

    private LoginPageViewModel _viewMode;
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;
    }

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();

    //    var userid = Preferences.Get("UserID", 999);
    //    if (userid == 999)
    //        _viewMode.LoginDetail.LoginStatus = "Invalid User/Passwod. Please try again";
    //    else
    //        _viewMode.LoginDetail.LoginStatus = "";
    //}

    //public LoginPage()
    //{
    //    InitializeComponent();
    //}

    //protected override bool OnBackButtonPressed()
    //{
    //    Application.Current.Quit();
    //    return true;
    //}

    //private async void LoginButton_Clicked(object sender, EventArgs e)
    //{
    //    if (IsCredentialCorrect(Username.Text, Password.Text))
    //    {
    //        App.Current.MainPage = new AppShell();
    //    }
    //    else
    //    {
    //        await DisplayAlert("Login failed", "Uusername or password if invalid", "Try again");
    //    }
    //}


    //bool IsCredentialCorrect(string username, string password)
    //{
    //    UserService userService = new UserService();
    //    UserModel user = userService.LoadUserByUserName(username, password).Result;
    //    return user.Username.Equals(username);
    //    //return Username.Text == "admin" && Password.Text == "1234";


    //}

    private async void SignUpButton_Clicked(object sender, EventArgs e)
    {
        // Navigate to sign-up page
        UserService userservice = new UserService();
        var userViewModel = new UserViewModel(userservice);
        await Navigation.PushAsync(new SignUpPage(userViewModel));

        //var navParam = new Dictionary<string, object>();
        //UserModel user = new UserModel();
        //navParam.Add("UserDetail", user);
        //await AppShell.Current.GoToAsync(nameof(SignUpPage), navParam);

        //await Share.Default.RequestAsync(new ShareTextRequest
        //{
        //    Uri = "https://google.com",
        //    Title = "Share Web Link"
        //});

        //string fileName = "signup4.png"; // Replace with your image file name
        //string filePath = Path.Combine(FileSystem.CacheDirectory, fileName);

        //// Write your image data to the file (e.g., download it from a URL)
        //// ...

        //await Share.Default.RequestAsync(new ShareFileRequest
        //{
        //    Title = "Share Image",
        //    File = new ShareFile(filePath)
        //});
    }

    private async void SignUpButton_Clickedd(object sender, TappedEventArgs e)
    {
        UserService userservice = new UserService();
        var userViewModel = new UserViewModel(userservice);
        await Navigation.PushAsync(new SignUpPage(userViewModel));
    }
}