
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
    public partial class CommunityServiceViewModel : ObservableObject
    {
            
        public static List<CommunityServiceModel> CommunityServiceListForSearch { get; private set; } = new List<CommunityServiceModel>();
        public ObservableCollection<CommunityServiceModel> CommunityService { get; set; } = new ObservableCollection<CommunityServiceModel>();

        private readonly ICommunityServiceService _communityServiceService;
        public CommunityServiceViewModel(ICommunityServiceService communityServiceservice)
        {
            _communityServiceService = communityServiceservice;
        }



        [RelayCommand]
        public async void GetCommunityServiceList()
        {
            CommunityService.Clear();
            var communityServiceList = await _communityServiceService.GetCommunityServiceList();
            if (communityServiceList?.Count > 0)
            {
                communityServiceList = communityServiceList.OrderBy(f => f.ServiceName).ToList();
                foreach (var communityService in communityServiceList)
                {
                    CommunityService.Add(communityService);
                }
                CommunityServiceListForSearch.Clear();
                CommunityServiceListForSearch.AddRange(communityServiceList);
            }
        }


        [RelayCommand]
        public async void AddUpdateCommunityService()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateCommunityService));
        }

        [RelayCommand]
        public async void EditCommunityService(CommunityServiceModel communityServiceModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("CommunityServiceDetail", communityServiceModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdateCommunityService), navParam);
        }

        [RelayCommand]
        public async void DeleteCommunityService(CommunityServiceModel communityServiceModel)
        {
            var delResponse = await _communityServiceService.DeleteCommunityService(communityServiceModel);
            if (delResponse > 0)
            {
                GetCommunityServiceList();
            }
        }


        [RelayCommand]
        public async void DisplayAction(CommunityServiceModel communityServiceModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("StudentDetail", communityServiceModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _communityServiceService.DeleteCommunityService(communityServiceModel);
                if (delResponse > 0)
                {
                    GetCommunityServiceList();
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