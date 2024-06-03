using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stulio.Models;
using Stulio.Services;
using Stulio.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;


namespace Stulio.ViewModels
{
    // ViewModel for the Profile Page
    public partial class ProfilePageViewModel : ObservableObject
    {
        // Uses an observable property to track changes to studentDetail
        [ObservableProperty]
        private StudentModel studentDetail;

        // Dependency injection of IStudentService to handle student data management
        private readonly IStudentService _studentService;

        // Constructor that initializes the student service
        public ProfilePageViewModel(IStudentService studentService)
        {
            _studentService = studentService;

        }

        // Command to load student details by ID
        [RelayCommand]
        public async void LoadByStudentID()
        {
            int UserID = Microsoft.Maui.Storage.Preferences.Get("UserID",1);
            StudentDetail = await _studentService.LoadStudentByID(UserID);

        }

        // Retrieve the UserID from preferences and use it to load student details
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

        [RelayCommand]
        async Task EnterWorkExperience(string s)
        {
            await Shell.Current.GoToAsync(nameof(WorkExperienceView));
        }

        [RelayCommand]
        async Task EnterAdditionalInvolvements(string s)
        {
            await Shell.Current.GoToAsync(nameof(AdditionalInvolvementsView));
        }

        [RelayCommand]
        async Task EnterPersonalEndeavors(string s)
        {
            await Shell.Current.GoToAsync(nameof(PersonalEndeavorsView));
        }

        [RelayCommand]
        async Task EnterClasses(string s)
        {
            await Shell.Current.GoToAsync(nameof(ClassesView));
        }

        [RelayCommand]
        async Task CaptureScreenshot()
        {

            var screenshot = await Xamarin.Essentials.Screenshot.CaptureAsync();
            var stream = await screenshot.OpenReadAsync();
            var filename = "screenshot" + DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture) + ".png";
            var file = Path.Combine(Xamarin.Essentials.FileSystem.CacheDirectory, filename);
            using (FileStream fs = File.Open(file, FileMode.CreateNew))
            {
                await stream.CopyToAsync(fs);
                await fs.FlushAsync();
            }

            ShareFile(filename, file);
            //return file;
        }


      
        async Task ShareFile(string filename, string filepath)
        {
            await Xamarin.Essentials.Share.RequestAsync(new Xamarin.Essentials.ShareFileRequest()
            {
                Title = filename,
                File = new Xamarin.Essentials.ShareFile(filepath)
            });
        }

        
    }

    }

