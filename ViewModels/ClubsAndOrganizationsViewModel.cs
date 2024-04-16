using Stulio.Views;
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
    public partial class ClubsAndOrganizationsViewModel : ObservableObject
    {
        public static List<ClubsAndOrganizationsModel> ClubsAndOrganizationsListForSearch { get; private set; } = new List<ClubsAndOrganizationsModel>();
        public ObservableCollection<ClubsAndOrganizationsModel> ClubsAndOrganizations { get; set; } = new ObservableCollection<ClubsAndOrganizationsModel>();

        private readonly IClubsAndOrganizationsService _clubsAndOrganizationsService;
        public ClubsAndOrganizationsViewModel(IClubsAndOrganizationsService clubsAndOrganizationsservice)
        {
            _clubsAndOrganizationsService = clubsAndOrganizationsservice;
        }

        [RelayCommand]
        public async void GetClubsAndOrganizationsList()
        {
            ClubsAndOrganizations.Clear();
            var clubsAndOrganizationsList = await _clubsAndOrganizationsService.GetClubsAndOrganizationsList();
            if (clubsAndOrganizationsList?.Count > 0)
            {
                clubsAndOrganizationsList = clubsAndOrganizationsList.OrderBy(f => f.ClubName).ToList();
                foreach (var clubsAndOrganizations in clubsAndOrganizationsList)
                {
                    ClubsAndOrganizations.Add(clubsAndOrganizations);
                }
                ClubsAndOrganizationsListForSearch.Clear();
                ClubsAndOrganizationsListForSearch.AddRange(clubsAndOrganizationsList);
            }
        }


        [RelayCommand]
        public async void AddUpdateClubsAndOrganizations()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateClubsAndOrganizations));
        }

        [RelayCommand]
        public async void EditClubsAndOrganizations(ClubsAndOrganizationsModel clubsAndOrganizationsModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("ClubsAndOrganizationsDetail", clubsAndOrganizationsModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdateClubsAndOrganizations), navParam);
        }

        [RelayCommand]
        public async void DeleteClubsAndOrganizations(ClubsAndOrganizationsModel clubsAndOrganizationsModel)
        {
            var delResponse = await _clubsAndOrganizationsService.DeleteClubsAndOrganizations(clubsAndOrganizationsModel);
            if (delResponse > 0)
            {
                GetClubsAndOrganizationsList();
            }
        }


        //[RelayCommand]
        //public async void DisplayAction(ClubsAndOrganizationsModel clubsAndOrganizationsModel)
        //{
        //    var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
        //    if (response == "Edit")
        //    {
        //        var navParam = new Dictionary<string, object>();
        //        navParam.Add("StudentDetail", clubsAndOrganizationsModel);
        //        await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail), navParam);
        //    }
        //    else if (response == "Delete")
        //    {
        //        var delResponse = await _clubsAndOrganizationsService.DeleteClubsAndOrganizations(clubsAndOrganizationsModel);
        //        if (delResponse > 0)
        //        {
        //            GetClubsAndOrganizationsList();
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
