
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
    [QueryProperty(nameof(PersonalEndeavors), "PersonalEndeavors")]
    public partial class AddUpdatePersonalEndeavorsViewModel : ObservableObject
    {
        [ObservableProperty]
        private PersonalEndeavorsModel _personalEndeavors = new PersonalEndeavorsModel();

        private readonly IPersonalEndeavorsService _Service;
        public AddUpdatePersonalEndeavorsViewModel(IPersonalEndeavorsService personalEndeavorsService)
        {
            _Service = personalEndeavorsService;
        }

        
        [RelayCommand]
        public async void UpdatePersonalEndeavors()
        {
            int response = -1;
            if (PersonalEndeavors.EndeavorId > 0)
            {
                response = await _Service.UpdatePersonalEndeavors(PersonalEndeavors);
            }
            else
            {
                response = await _Service.AddPersonalEndeavors(new Models.PersonalEndeavorsModel
                {
                    EndeavorId = PersonalEndeavors.EndeavorId,
                    StudentID = PersonalEndeavors.StudentID,
                    Title = PersonalEndeavors.Title,
                    Description = PersonalEndeavors.Description
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
        public async void DeletePersonalEndeavors(PersonalEndeavorsModel personalEndeavorsModel)
        {
            var delResponse = await _Service.DeletePersonalEndeavors(personalEndeavorsModel);
            if (delResponse > 0)
            {
                await Shell.Current.GoToAsync("..");
            }
        }

    }
}