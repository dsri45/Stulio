
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
    [QueryProperty(nameof(Classes), "Classes")]
    public partial class AddUpdateClassesViewModel : ObservableObject
    {
        [ObservableProperty]
        private ClassesModel _classes = new ClassesModel();

        private readonly IClassesService _Service;
        public AddUpdateClassesViewModel(IClassesService classesService)
        {
            _Service = classesService;
        }

        
        [RelayCommand]
        public async void UpdateClasses()
        {
            int response = -1;
            if (Classes.ClassId > 0)
            {
                response = await _Service.UpdateClasses(Classes);
            }
            else
            {
                response = await _Service.AddClasses(new Models.ClassesModel
                {
                    ClassId = Classes.ClassId,
                    StudentID = Preferences.Get("UserID", 999),
                    Name = Classes.Name,
                    ClassYear = Classes.ClassYear,
                    Grade = Classes.Grade
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
        public async void DeleteClasses(ClassesModel classesModel)
        {
            var delResponse = await _Service.DeleteClasses(classesModel);
            if (delResponse > 0)
            {
                await Shell.Current.GoToAsync("..");
            }
        }

    }
}