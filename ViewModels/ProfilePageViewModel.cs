using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stulio.Models;
using Stulio.Services;
using Stulio.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.ViewModels
{
    //[QueryProperty(nameof(StudentDetail), "StudentDetail")]
    public partial class ProfilePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private StudentModel studentDetail;

        private readonly IStudentService _studentService;
        public ProfilePageViewModel(IStudentService studentService)
        {
            _studentService = studentService;

        }


        [RelayCommand]
        public async void LoadByStudentID()
        {
            StudentDetail = await _studentService.LoadStudentByID(1);

        }

        [RelayCommand]
        public async void UpdateAboutMe()
        {
            await AppShell.Current.GoToAsync(nameof(AboutMe), true, new Dictionary<string, object>
            { {"StudentDetail", StudentDetail } });

        }


        [RelayCommand]
        public async void AddUpdateStudent()
        {
            int response = -1;
            if (StudentDetail.StudentID > 0)
            {
                response = await _studentService.UpdateStudent(StudentDetail);
            }
            else
            {
                response = await _studentService.AddStudent(new Models.StudentModel
                {
                    Email = StudentDetail.Email,
                    FirstName = StudentDetail.FirstName,
                    LastName = StudentDetail.LastName,
                    PhoneNumber = StudentDetail.PhoneNumber,
                });
            }



            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Student Info Saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }

        [RelayCommand]
        async Task EnterAcademicAchievements(string s)
        {
            await Shell.Current.GoToAsync(nameof(AcademicAchievements));

        }

        [RelayCommand]
        async Task EnterClubsAndOrganizations(string s)
        {
            await Shell.Current.GoToAsync(nameof(ClubsAndOrganizationsView));
        }

        [RelayCommand]
        async Task EnterAthleticParticipation(string s)
        {
            await Shell.Current.GoToAsync(nameof(AthleticParticipationView));
        }

        [RelayCommand]
        async Task EnterCommunityService(string s)
        {
            await Shell.Current.GoToAsync(nameof(CommunityServiceView));
        }
    }

    }

