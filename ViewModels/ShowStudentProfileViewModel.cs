
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stulio.Models;
using Stulio.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.ViewModels
{
    public partial class ShowStudentProfileViewModel : ObservableObject
    {

       
        private readonly ShowStudentProfileService _dataService;

        [ObservableProperty]
        public StudentModel showStudent;
        
        public ObservableCollection<AcademicAchievementsModel> ShowAcademicAchievements { get; set; } = new ObservableCollection<AcademicAchievementsModel>();
        public ObservableCollection<ClubsAndOrganizationsModel> ShowClubsAndOrganizations { get; set; } = new ObservableCollection<ClubsAndOrganizationsModel>();
        public ObservableCollection<CommunityServiceModel> ShowCommunityService { get; set; } = new ObservableCollection<CommunityServiceModel>();
        public ObservableCollection<AthleticParticipationModel> ShowAthleticParticipation { get; set; } = new ObservableCollection<AthleticParticipationModel>();
        public ObservableCollection<WorkExperienceModel> ShowWorkExperience { get; set; } = new ObservableCollection<WorkExperienceModel>();
        public ObservableCollection<AdditionalInvolvementsModel> ShowAdditionalInvolvements { get; set; } = new ObservableCollection<AdditionalInvolvementsModel>();



        public ShowStudentProfileViewModel()
            {
                _dataService = new ShowStudentProfileService();
                //LoadRecords();
            }

            public async Task LoadRecords()
            {
       
            // Retrieve data from DataService
            //var studentModels = await _dataService.GetStudent(); // Assuming GetStudentModels returns a list of StudentModel
            //var academicAchievements = await _dataService.GetAcademicAchievement(); // Assuming GetAcademicAchievements returns a list of AcademicAchievement

            GetAcademicAchievementsList();
            LoadByStudentID();
            GetClubsAndOrganizationsList();
            GetCommunityServiceList();
           }

       [RelayCommand]
        public async void GetAcademicAchievementsList()
        {
            ShowAcademicAchievements.Clear();
            var academicAchievementsList = await _dataService.GetAcademicAchievement();
            if (academicAchievementsList?.Count > 0)
            {
                academicAchievementsList = academicAchievementsList.OrderBy(f => f.Award).ToList();
                foreach (var academicAchievement in academicAchievementsList)
                {
                    ShowAcademicAchievements.Add(academicAchievement);
                }
             
            }
        }

       [RelayCommand]
        public async void LoadByStudentID()
        {
            int UserID = Preferences.Get("UserID", 1);
            ShowStudent = await _dataService.GetStudent();

        }

        [RelayCommand]
        public async void GetClubsAndOrganizationsList()
        {
            ShowClubsAndOrganizations.Clear();
            var clubsAndOrganizationsList = await _dataService.GetClubsAndOrganizations();
            if (clubsAndOrganizationsList?.Count > 0)
            {
                clubsAndOrganizationsList = clubsAndOrganizationsList.OrderBy(f => f.ClubName).ToList();
                foreach (var clubsAndOrganizations in clubsAndOrganizationsList)
                {
                    ShowClubsAndOrganizations.Add(clubsAndOrganizations);
                }
              
            }
        }

        [RelayCommand]
        public async void GetCommunityServiceList()
        {
            ShowCommunityService.Clear();
            var communityServiceList = await _dataService.GetCommunityService();
            if (communityServiceList?.Count > 0)
            {
                communityServiceList = communityServiceList.OrderBy(f => f.ServiceName).ToList();
                foreach (var communityService in communityServiceList)
                {
                    ShowCommunityService.Add(communityService);
                }

            }
        }

       
    }
    }

