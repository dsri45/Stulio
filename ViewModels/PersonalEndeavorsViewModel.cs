
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
    public partial class PersonalEndeavorsViewModel : ObservableObject
    {
            
        public static List<PersonalEndeavorsModel> PersonalEndeavorsListForSearch { get; private set; } = new List<PersonalEndeavorsModel>();
        public ObservableCollection<PersonalEndeavorsModel> PersonalEndeavors { get; set; } = new ObservableCollection<PersonalEndeavorsModel>();

        private readonly IPersonalEndeavorsService _personalEndeavorsService;
        public PersonalEndeavorsViewModel(IPersonalEndeavorsService personalEndeavorsService)
        {
            _personalEndeavorsService = personalEndeavorsService;
        }



        [RelayCommand]
        public async void GetPersonalEndeavorsList()
        {
            PersonalEndeavors.Clear();
            var personalEndeavorsList = await _personalEndeavorsService.GetPersonalEndeavorsList(Preferences.Get("UserID", 999));
            if (personalEndeavorsList?.Count > 0)
            {
                personalEndeavorsList = personalEndeavorsList.OrderBy(f => f.Description).ToList();
                foreach (var personalEndeavors in personalEndeavorsList)
                {
                    PersonalEndeavors.Add(personalEndeavors);
                }
                PersonalEndeavorsListForSearch.Clear();
                PersonalEndeavorsListForSearch.AddRange(personalEndeavorsList);
            }
        }


        [RelayCommand]
        public async void AddUpdatePersonalEndeavors()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdatePersonalEndeavors));
        }

        [RelayCommand]
        public async void EditPersonalEndeavors(PersonalEndeavorsModel personalEndeavorsModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("PersonalEndeavorsDetail", personalEndeavorsModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdatePersonalEndeavors), navParam);
        }

        [RelayCommand]
        public async void DeletePersonalEndeavors(PersonalEndeavorsModel personalEndeavorsModel)
        {
            var delResponse = await _personalEndeavorsService.DeletePersonalEndeavors(personalEndeavorsModel);
            if (delResponse > 0)
            {
                GetPersonalEndeavorsList();
            }
        }



        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}