
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
    [QueryProperty(nameof(ClubsAndOrganizations), "ClubsAndOrganizations")]
    public partial class AddUpdateClubsAndOrganizationsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ClubsAndOrganizationsModel _clubsAndOrganizations = new ClubsAndOrganizationsModel();

        private readonly IClubsAndOrganizationsService _Service;
        public AddUpdateClubsAndOrganizationsViewModel(IClubsAndOrganizationsService clubsAndOrganizationsService)
        {
            _Service = clubsAndOrganizationsService;
        }

        
        [RelayCommand]
        public async void UpdateClubsAndOrganizations()
        {
            int response = -1;
            if (ClubsAndOrganizations.ClubId > -1)
            {
                response = await _Service.UpdateClubsAndOrganizations(ClubsAndOrganizations);
            }
            else
            {
                response = await _Service.AddClubsAndOrganizations(new Models.ClubsAndOrganizationsModel
                {
                    //ClubId = ClubsAndOrganizations.ClubId,
                    StudentID = Preferences.Get("UserID", 999),
                    ClubName = ClubsAndOrganizations.ClubName,
                    ParticpatedYears = ClubsAndOrganizations.ParticpatedYears,
                    Role = ClubsAndOrganizations.Role,
                    Description = ClubsAndOrganizations.Description,
                    Achivements = ClubsAndOrganizations.Achivements
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
        public async void DeleteClubsAndOrganizations(ClubsAndOrganizationsModel clubsAndOrganizationsModel)
        {
            var delResponse = await _Service.DeleteClubsAndOrganizations(clubsAndOrganizationsModel);
            if (delResponse > 0)
            {
                await Shell.Current.GoToAsync("..");
            }
        }


        [RelayCommand]
        public async void LoadClubsAndOrganizationsByID()
        {
            int UserID = Microsoft.Maui.Storage.Preferences.Get("UserID", 1);
            int ClubId = Microsoft.Maui.Storage.Preferences.Get("ClubId", 1);
            ClubsAndOrganizations = await _Service.LoadClubsAndOrganizationsByID(UserID, ClubId);

        }
    }
}