
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
    public partial class ClassesViewModel : ObservableObject
    {
            
        public static List<ClassesModel> ClassesListForSearch { get; private set; } = new List<ClassesModel>();
        public ObservableCollection<ClassesModel> Classes { get; set; } = new ObservableCollection<ClassesModel>();

        private readonly IClassesService _classesService;
        public ClassesViewModel(IClassesService classeservice)
        {
            _classesService = classeservice;
        }



        [RelayCommand]
        public async void GetClassesList()
        {
            Classes.Clear();
            var classesList = await _classesService.GetClassesList();
            if (classesList?.Count > 0)
            {
                classesList = classesList.OrderBy(f => f.Name).ToList();
                foreach (var clas in classesList)
                {
                    Classes.Add(clas);
                }
                ClassesListForSearch.Clear();
                ClassesListForSearch.AddRange(classesList);
            }
        }


        [RelayCommand]
        public async void AddUpdateClasses()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateClasses));
        }

        [RelayCommand]
        public async void EditClasses(ClassesModel classesModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("ClassesDetail", classesModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdateClasses), navParam);
        }

        [RelayCommand]
        public async void DeleteClasses(ClassesModel classesModel)
        {
            var delResponse = await _classesService.DeleteClasses(classesModel);
            if (delResponse > 0)
            {
                GetClassesList();
            }
        }


       

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}