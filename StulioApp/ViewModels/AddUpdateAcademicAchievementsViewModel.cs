﻿
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stulio.Models;
using Stulio.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.ViewModels
{
    [QueryProperty(nameof(AcademicAchievements), "AcademicAchievements")]
    public partial class AddUpdateAcademicAchievementsViewModel : ObservableObject
    {
        [ObservableProperty]
        private AcademicAchievementsModel _academicAchievements = new AcademicAchievementsModel();

        private readonly IAcademicAchievementsService _Service;
        public AddUpdateAcademicAchievementsViewModel(IAcademicAchievementsService academicAchievementsService)
        {
            _Service = academicAchievementsService;
        }

        
        [RelayCommand]
        public async void UpdateAcademicAchievements(AcademicAchievementsModel academicAchievementsModel)
        {

            //var SomeProperty = AcademicAchievements[nameof(AcademicAchievementsModel)] as AcademicAchievementsModel;

            int response = -1;
            if (AcademicAchievements.AcademicId > -1)
            {
                response = await _Service.UpdateAcademicAchievements(AcademicAchievements);
                
            }
            else
            {
               
                response = await _Service.AddAcademicAchievements(new Models.AcademicAchievementsModel
               {
                   // AcademicId = AcademicAchievements.AcademicId,
                    StudentID = Preferences.Get("UserID", 999),
                    DateAchived = AcademicAchievements.DateAchived,
                    Award = AcademicAchievements.Award,
                    Class = AcademicAchievements.Class,
                    Description = AcademicAchievements.Description

                 });

               

            }
            if (response > 0)
            {
                //await Shell.Current.DisplayAlert("Academic Achievements Info Saved", "Record Saved", "OK");
                
                

                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        public async void DeleteAcademicAchievements(AcademicAchievementsModel academicAchievementsModel)
        {
            var delResponse = await _Service.DeleteAcademicAchievements(academicAchievementsModel);
            if (delResponse > 0)
            {
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        public async void LoadAcademicAchievementsByID()
        {
            int UserID = Microsoft.Maui.Storage.Preferences.Get("UserID", 1);
            int AcademicID = Microsoft.Maui.Storage.Preferences.Get("AcademicId", 1);
            AcademicAchievements = await _Service.LoadAcademicAchievementsByID(UserID, AcademicID);

        }

    }
}