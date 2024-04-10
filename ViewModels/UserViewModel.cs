
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
    [QueryProperty(nameof(UserDetail), "UserDetail")]
    public partial class UserViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserModel _userDetail = new UserModel();

        private readonly IUserService _userService;
        public UserViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [RelayCommand]
        public async void AddUpdateUser()
        {
            int response = -1;
            if (UserDetail.UserId > 0)
            {
                response = await _userService.UpdateUser(UserDetail);
            }
            else
            {
                response = await _userService.AddUser(new Models.UserModel
                {
                    UserId = UserDetail.UserId,
                    Password = UserDetail.Password,
                    Email = UserDetail.Email,
                    SchoolName = UserDetail.SchoolName              
                });
            }



            if (response > 0)
            {
                //await Shell.Current.DisplayAlert("Student Info Saved", "Record Saved", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }

    }
}