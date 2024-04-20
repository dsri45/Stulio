
using Stulio.Views;
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
    public partial class AcademicAchievementsViewModel : ObservableObject
    {
            
        public static List<AcademicAchievementsModel> AcademicAchievementsListForSearch { get; private set; } = new List<AcademicAchievementsModel>();
        public ObservableCollection<AcademicAchievementsModel> AcademicAchievements { get; set; } = new ObservableCollection<AcademicAchievementsModel>();

        private readonly IAcademicAchievementsService _academicAchievementsService;
        public AcademicAchievementsViewModel(IAcademicAchievementsService academicAchievementservice)
        {
            _academicAchievementsService = academicAchievementservice;
        }



        [RelayCommand]
        public async void GetAcademicAchievementsList()
        {
            AcademicAchievements.Clear();
            var academicAchievementsList = await _academicAchievementsService.GetAcademicAchievementsList(Preferences.Get("UserID", 999));
            if (academicAchievementsList?.Count > 0)
            {
                academicAchievementsList = academicAchievementsList.OrderBy(f => f.Award).ToList();
                foreach (var academicAchievement in academicAchievementsList)
                {
                    AcademicAchievements.Add(academicAchievement);
                }
                AcademicAchievementsListForSearch.Clear();
                AcademicAchievementsListForSearch.AddRange(academicAchievementsList);
            }
        }


        [RelayCommand]
        public async void AddUpdateAcademicAchievements()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateAcademicAchievements));
        }

        [RelayCommand]
        public async void EditAcademicAchievements(AcademicAchievementsModel academicAchievementsModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("AcademicAchievementsDetail", academicAchievementsModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdateAcademicAchievements), navParam);
        }

        [RelayCommand]
        public async void DeleteAcademicAchievements(AcademicAchievementsModel academicAchievementsModel)
        {
            var delResponse = await _academicAchievementsService.DeleteAcademicAchievements(academicAchievementsModel);
            if (delResponse > 0)
            {
                GetAcademicAchievementsList();
            }
        }


        //[RelayCommand]
        //public async void DisplayAction(AcademicAchievementsModel academicAchievementsModel)
        //{
        //    var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
        //    if (response == "Edit")
        //    {
        //        var navParam = new Dictionary<string, object>();
        //        navParam.Add("StudentDetail", academicAchievementsModel);
        //        await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail), navParam);
        //    }
        //    else if (response == "Delete")
        //    {
        //        var delResponse = await _academicAchievementsService.DeleteAcademicAchievements(academicAchievementsModel);
        //        if (delResponse > 0)
        //        {
        //            GetAcademicAchievementsList();
        //        }
        //    }
        //}

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}