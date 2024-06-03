
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
    [QueryProperty(nameof(AthleticParticipation), "AthleticParticipation")]
    public partial class AddUpdateAthleticParticipationViewModel : ObservableObject
    {
        [ObservableProperty]
        private AthleticParticipationModel _athleticParticipation = new AthleticParticipationModel();

        private readonly IAthleticParticipationService _Service;
        public AddUpdateAthleticParticipationViewModel(IAthleticParticipationService athleticParticipationService)
        {
            _Service = athleticParticipationService;
        }

        
        [RelayCommand]
        public async void UpdateAthleticParticipation()
        {
            int response = -1;
            if (AthleticParticipation.AthleticId > -1)
            {
                response = await _Service.UpdateAthleticParticipation(AthleticParticipation);
            }
            else
            {
                response = await _Service.AddAthleticParticipation(new Models.AthleticParticipationModel
                {
                    //AthleticId = AthleticParticipation.AthleticId,
                    StudentID = Preferences.Get("UserID", 999),
                    Sport = AthleticParticipation.Sport,
                    Role = AthleticParticipation.Role,
                    ParticpatedYears = AthleticParticipation.ParticpatedYears,
                    Achivements = AthleticParticipation.Achivements
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
        public async void DeleteAthleticParticipation(AthleticParticipationModel athleticParticipationModel)
        {
            var delResponse = await _Service.DeleteAthleticParticipation(athleticParticipationModel);
            if (delResponse > 0)
            {
                await Shell.Current.GoToAsync("..");
            }
        }
        [RelayCommand]
        public async void LoadAthleticParticipationByID()
        {
            int UserID = Microsoft.Maui.Storage.Preferences.Get("UserID", 1);
            int AthleticId = Microsoft.Maui.Storage.Preferences.Get("AthleticId", 1);
            AthleticParticipation = await _Service.LoadAthleticParticipationByID(UserID, AthleticId);

        }
    }
}