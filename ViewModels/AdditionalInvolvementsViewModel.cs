
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
    public partial class AdditionalInvolvementsViewModel : ObservableObject
    {
            
        public static List<AdditionalInvolvementsModel> AdditionalInvolvementsListForSearch { get; private set; } = new List<AdditionalInvolvementsModel>();
        public ObservableCollection<AdditionalInvolvementsModel> AdditionalInvolvements { get; set; } = new ObservableCollection<AdditionalInvolvementsModel>();

        private readonly IAdditionalInvolvementsService _additionalInvolvementsService;
        public AdditionalInvolvementsViewModel(IAdditionalInvolvementsService additionalInvolvementsservice)
        {
            _additionalInvolvementsService = additionalInvolvementsservice;
        }



        [RelayCommand]
        public async void GetAdditionalInvolvementsList()
        {
            AdditionalInvolvements.Clear();
            var additionalInvolvementsList = await _additionalInvolvementsService.GetAdditionalInvolvementsList();
            if (additionalInvolvementsList?.Count > 0)
            {
                additionalInvolvementsList = additionalInvolvementsList.OrderBy(f => f.ActivityName).ToList();
                foreach (var additionalInvolvements in additionalInvolvementsList)
                {
                    AdditionalInvolvements.Add(additionalInvolvements);
                }
                AdditionalInvolvementsListForSearch.Clear();
                AdditionalInvolvementsListForSearch.AddRange(additionalInvolvementsList);
            }
        }


        [RelayCommand]
        public async void AddUpdateAdditionalInvolvements()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateAdditionalInvolvements));
        }

        [RelayCommand]
        public async void EditAdditionalInvolvements(AdditionalInvolvementsModel additionalInvolvementsModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("AdditionalInvolvementsDetail", additionalInvolvementsModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdateAdditionalInvolvements), navParam);
        }

        [RelayCommand]
        public async void DeleteAdditionalInvolvements(AdditionalInvolvementsModel additionalInvolvementsModel)
        {
            var delResponse = await _additionalInvolvementsService.DeleteAdditionalInvolvements(additionalInvolvementsModel);
            if (delResponse > 0)
            {
                GetAdditionalInvolvementsList();
            }
        }


        [RelayCommand]
        public async void DisplayAction(AdditionalInvolvementsModel additionalInvolvementsModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("StudentDetail", additionalInvolvementsModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _additionalInvolvementsService.DeleteAdditionalInvolvements(additionalInvolvementsModel);
                if (delResponse > 0)
                {
                    GetAdditionalInvolvementsList();
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