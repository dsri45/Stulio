
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
    public partial class WorkExperienceViewModel : ObservableObject
    {
            
        public static List<WorkExperienceModel> WorkExperienceListForSearch { get; private set; } = new List<WorkExperienceModel>();
        public ObservableCollection<WorkExperienceModel> WorkExperience { get; set; } = new ObservableCollection<WorkExperienceModel>();

        private readonly IWorkExperienceService _workExperienceService;
        public WorkExperienceViewModel(IWorkExperienceService workExperienceservice)
        {
            _workExperienceService = workExperienceservice;
        }

        

        [RelayCommand]
        public async void GetWorkExperienceList()
        {
            WorkExperience.Clear();
            var workExperienceList = await _workExperienceService.GetWorkExperienceList(Preferences.Get("UserID", 999));
            if (workExperienceList?.Count > 0)
            {
                workExperienceList = workExperienceList.OrderBy(f => f.Establishment).ToList();
                foreach (var workExperience in workExperienceList)
                {
                    WorkExperience.Add(workExperience);
                }
                WorkExperienceListForSearch.Clear();
                WorkExperienceListForSearch.AddRange(workExperienceList);
            }
        }


        [RelayCommand]
        public async void AddUpdateWorkExperience()
        {
            Preferences.Set("WorkId", -1);
            await AppShell.Current.GoToAsync(nameof(AddUpdateWorkExperience));
        }

        [RelayCommand]
        public async void EditWorkExperience(WorkExperienceModel workExperienceModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("WorkExperienceDetail", workExperienceModel);
            Preferences.Set("WorkId", workExperienceModel.WorkId);
            await AppShell.Current.GoToAsync(nameof(AddUpdateWorkExperience), navParam);
        }

        [RelayCommand]
        public async void DeleteWorkExperience(WorkExperienceModel workExperienceModel)
        {
            var delResponse = await _workExperienceService.DeleteWorkExperience(workExperienceModel);
            if (delResponse > 0)
            {
                GetWorkExperienceList();
            }
        }


        //[RelayCommand]
        //public async void DisplayAction(WorkExperienceModel workExperienceModel)
        //{
        //    var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
        //    if (response == "Edit")
        //    {
        //        var navParam = new Dictionary<string, object>();
        //        navParam.Add("StudentDetail", workExperienceModel);
        //        await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail), navParam);
        //    }
        //    else if (response == "Delete")
        //    {
        //        var delResponse = await _workExperienceService.DeleteWorkExperience(workExperienceModel);
        //        if (delResponse > 0)
        //        {
        //            GetWorkExperienceList();
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