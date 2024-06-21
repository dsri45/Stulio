
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
            StudentService studentService = new StudentService();
            StudentModel studentModel = new StudentModel(); 
            var userExists = await _userService.LoadUserByUserName(UserDetail.Username,UserDetail.Password);
            if (userExists.Username == UserDetail.Username)
            {
                response = await _userService.UpdateUser(UserDetail);
            }
            else
            {
                response = await _userService.AddUser(new Models.UserModel
                {
                    FirstName = UserDetail.FirstName, 
                    LastName = UserDetail.LastName,  
                    Email = UserDetail.Email,
                    SchoolName = UserDetail.SchoolName,
                    Username = UserDetail.Username,
                    Password = UserDetail.Password,
                    PhoneNumber= UserDetail.PhoneNumber
                });
            }
            if (response > -1)
            {
                var studentID = Preferences.Get("UserID", 999);
                //await studentService.AddStudent(new Models.StudentModel
                //{
                //    StudentID = studentID,
                //    FirstName = UserDetail.FirstName,
                //    LastName = UserDetail.LastName,
                //    Email = UserDetail.Email,
                //    SchoolName = UserDetail.SchoolName,
                //    PhoneNumber = UserDetail.PhoneNumber

                //});

                App.Current.MainPage = new AppShell();
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }

    }
}