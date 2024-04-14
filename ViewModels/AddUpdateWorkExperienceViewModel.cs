
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
    [QueryProperty(nameof(WorkExperience), "WorkExperience")]
    public partial class AddUpdateWorkExperienceViewModel : ObservableObject
    {
        [ObservableProperty]
        private WorkExperienceModel _workExperience = new WorkExperienceModel();

        private readonly IWorkExperienceService _Service;
        public AddUpdateWorkExperienceViewModel(IWorkExperienceService workExperienceService)
        {
            _Service = workExperienceService;
        }

        
        [RelayCommand]
        public async void UpdateWorkExperience()
        {
            int response = -1;
            if (WorkExperience.WorkId > 0)
            {
                response = await _Service.UpdateWorkExperience(WorkExperience);
            }
            else
            {
                response = await _Service.AddWorkExperience(new Models.WorkExperienceModel
                {
                    WorkId = WorkExperience.WorkId,
                    StudentID = Preferences.Get("UserID", 1),
                    Role = WorkExperience.Role,
                    Establishment = WorkExperience.Establishment,
                    ParticpatedYears = WorkExperience.ParticpatedYears,
                    Description = WorkExperience.Description
                });
            }



            if (response > 0)
            {
                //await Shell.Current.DisplayAlert("WorkExperience Info Saved", "Record Saved", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        public async void DeleteWorkExperience(WorkExperienceModel workExperienceModel)
        {
            var delResponse = await _Service.DeleteWorkExperience(workExperienceModel);
            if (delResponse > 0)
            {
                await Shell.Current.GoToAsync("..");
            }
        }

    }
}