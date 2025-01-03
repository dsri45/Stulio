﻿
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
    [QueryProperty(nameof(CommunityService), "CommunityService")]
    public partial class AddUpdateCommunityServiceViewModel : ObservableObject
    {
        [ObservableProperty]
        private CommunityServiceModel _communityService = new CommunityServiceModel();

        private readonly ICommunityServiceService _Service;
        public AddUpdateCommunityServiceViewModel(ICommunityServiceService communityServiceService)
        {
            _Service = communityServiceService;
        }

        
        [RelayCommand]
        public async void UpdateCommunityService()
        {
            int response = -1;
           
            if (CommunityService.CommunityId > -1)
            {
                response = await _Service.UpdateCommunityService(CommunityService);
            }
            else
            {
                response = await _Service.AddCommunityService(new Models.CommunityServiceModel
                {
                    //CommunityId = CommunityService.CommunityId,
                    StudentID = Preferences.Get("UserID", 999),
                    ServiceName = CommunityService.ServiceName,
                    ParticpatedYears = CommunityService.ParticpatedYears,
                    VoulnteeredHours = CommunityService.VoulnteeredHours,
                    Description = CommunityService.Description
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
        public async void DeleteCommunityService(CommunityServiceModel communityServiceModel)
        {
            var delResponse = await _Service.DeleteCommunityService(communityServiceModel);
            if (delResponse > 0)
            {
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        public async void LoadCommunityServiceByID()
        {
            int UserID = Microsoft.Maui.Storage.Preferences.Get("UserID", 1);
            int CommunityId = Microsoft.Maui.Storage.Preferences.Get("CommunityId", 1);
            CommunityService = await _Service.LoadCommunityServiceByID(UserID, CommunityId);

        }

    }
}