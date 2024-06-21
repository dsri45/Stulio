
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
    [QueryProperty(nameof(AdditionalInvolvements), "AdditionalInvolvements")]
    public partial class AddUpdateAdditionalInvolvementsViewModel : ObservableObject
    {
        [ObservableProperty]
        private AdditionalInvolvementsModel _additionalInvolvements = new AdditionalInvolvementsModel();

        private readonly IAdditionalInvolvementsService _Service;
        public AddUpdateAdditionalInvolvementsViewModel(IAdditionalInvolvementsService additionalInvolvementsService)
        {
            _Service = additionalInvolvementsService;
        }

        
        [RelayCommand]
        public async void UpdateAdditionalInvolvements()
        {
            int response = -1;
            if (AdditionalInvolvements.InvolvementId > -1)
            {
                response = await _Service.UpdateAdditionalInvolvements(AdditionalInvolvements);
            }
            else
            {
                response = await _Service.AddAdditionalInvolvements(new Models.AdditionalInvolvementsModel
                {
                   // InvolvementId = AdditionalInvolvements.InvolvementId,
                    StudentID = Preferences.Get("UserID", 999),
                    ActivityName = AdditionalInvolvements.ActivityName,
                    ParticpatedYears = AdditionalInvolvements.ParticpatedYears,
                    Role = AdditionalInvolvements.Role,
                    Description = AdditionalInvolvements.Description,
                    Achivements = AdditionalInvolvements.Achivements
                });
            }



            if (response > 0)
            {
                //await Shell.Current.DisplayAlert("Additional Involvements Info Saved", "Record Saved", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        public async void DeleteAdditionalInvolvements(AdditionalInvolvementsModel additionalInvolvementsModel)
        {
            var delResponse = await _Service.DeleteAdditionalInvolvements(additionalInvolvementsModel);
            if (delResponse > 0)
            {
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        public async void LoadAdditionalInvolvementsByID()
        {
            int UserID = Microsoft.Maui.Storage.Preferences.Get("UserID", 1);
            int InvolvementId = Microsoft.Maui.Storage.Preferences.Get("InvolvementId", 1);
            AdditionalInvolvements = await _Service.LoadAdditionalInvolvementsByID(UserID, InvolvementId);

        }


    }
}