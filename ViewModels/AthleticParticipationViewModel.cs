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
    public partial class AthleticParticipationViewModel : ObservableObject
    {
        public static List<AthleticParticipationModel> AthleticParticipationListForSearch { get; private set; } = new List<AthleticParticipationModel>();
        public ObservableCollection<AthleticParticipationModel> AthleticParticipation { get; set; } = new ObservableCollection<AthleticParticipationModel>();

        private readonly IAthleticParticipationService _athleticParticipationService;
        public AthleticParticipationViewModel(IAthleticParticipationService athleticParticipationservice)
        {
            _athleticParticipationService = athleticParticipationservice;
        }

        [RelayCommand]
        public async void GetAthleticParticipationList()
        {
            AthleticParticipation.Clear();
            var athleticParticipationList = await _athleticParticipationService.GetAthleticParticipationList();
            if (athleticParticipationList?.Count > 0)
            {
                athleticParticipationList = athleticParticipationList.OrderBy(f => f.Sport).ToList();
                foreach (var athleticParticipation in athleticParticipationList)
                {
                    AthleticParticipation.Add(athleticParticipation);
                }
                AthleticParticipationListForSearch.Clear();
                AthleticParticipationListForSearch.AddRange(athleticParticipationList);
            }
        }


        [RelayCommand]
        public async void AddUpdateAthleticParticipation()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateAthleticParticipation));
        }

        [RelayCommand]
        public async void EditAthleticParticipation(AthleticParticipationModel athleticParticipationModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("AthleticParticipationDetail", athleticParticipationModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdateAthleticParticipation), navParam);
        }

        [RelayCommand]
        public async void DeleteAthleticParticipation(AthleticParticipationModel athleticParticipationModel)
        {
            var delResponse = await _athleticParticipationService.DeleteAthleticParticipation(athleticParticipationModel);
            if (delResponse > 0)
            {
                GetAthleticParticipationList();
            }
        }


        [RelayCommand]
        public async void DisplayAction(AthleticParticipationModel athleticParticipationModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("StudentDetail", athleticParticipationModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _athleticParticipationService.DeleteAthleticParticipation(athleticParticipationModel);
                if (delResponse > 0)
                {
                    GetAthleticParticipationList();
                }
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
