
using Stulio.Models;
using Stulio.Services;
using Stulio.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace Stulio.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (IsCredentialCorrect(Username.Text, Password.Text))
        {
            //await SecureStorage.SetAsync("hasAuth", "true");
            //profilePageViewModel.LoadByStudentID()
            //StudentService studentService = new StudentService();
            //ProfilePageViewModel profilePageViewModel = new ProfilePageViewModel(studentService);
            //await App.Current.MainPage.Navigation.PushAsync(new ProfilePage(profilePageViewModel));
            //await Shell.Current.GoToAsync("ProfilePage");
            //await Navigation.PushAsync(new ProfilePage());
            App.Current.MainPage = new AppShell();


        }
        else
        {
            await DisplayAlert("Login failed", "Uusername or password if invalid", "Try again");
        }
    }


    bool IsCredentialCorrect(string username, string password)
    {
        return Username.Text == "admin" && Password.Text == "1234";
    }

    private async void SignUpButton_Clicked(object sender, EventArgs e)
    {
        // Navigate to sign-up page
       // var userViewModel = new UserViewModel();
       // await Navigation.PushAsync(new SignUpPage(userViewModel));

        //var navParam = new Dictionary<string, object>();
        //UserModel user = new UserModel();
        //navParam.Add("UserDetail", user);
        //await AppShell.Current.GoToAsync(nameof(SignUpPage), navParam);

        await Share.Default.RequestAsync(new ShareTextRequest
        {
            Uri = "https://example.com",
            Title = "Share Web Link"
        });
    }
}