
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stulio.Models;
using Stulio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.ViewModels
{

    [QueryProperty(nameof(LoginDetail), "LoginDetail")]
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private LoginModel _loginDetail = new LoginModel();

        private readonly IUserService _userService;
        public LoginPageViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [RelayCommand]
        public async void LoginUser()
        {
            int response = -1;
            var userExists = await _userService.LoadUserByUserName(LoginDetail.Username, LoginDetail.Password);
            if (userExists.Username == LoginDetail.Username)
            {
                App.Current.MainPage = new AppShell();
                //await Shell.Current.DisplayAlert("Student Signup", "SignUp Successful! Welcome to Stulio!", "OK");
                //await Shell.Current.GoToAsync("..");
            }
            else
            {
                LoginDetail.LoginStatus = "Invalid User. SignUp to Stulio!";
                //await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
                //await DisplayAlert("Login failed", "Uusername or password if invalid", "Try again");
            }
        }

    }
}