
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
    [QueryProperty(nameof(StudentDetail), "StudentDetail")]
    public partial class AddUpdateStudentViewModel : ObservableObject
    {
        [ObservableProperty]
        private StudentModel _studentDetail = new StudentModel();

        private readonly IStudentService _studentService;
        public AddUpdateStudentViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [RelayCommand]
        public async void AddUpdateStudent()
        {
            int response = -1;
            if (StudentDetail.StudentID > 0)
            {
                response = await _studentService.UpdateStudent(StudentDetail);
            }
            else
            {
                response = await _studentService.AddStudent(new Models.StudentModel
                {
                    Email = StudentDetail.Email,
                    FirstName = StudentDetail.FirstName,
                    LastName = StudentDetail.LastName,
                    PhoneNumber = StudentDetail.PhoneNumber,
                });
            }



            if (response > 0)
            {
                //await Shell.Current.DisplayAlert("Student Info Saved", "Record Saved", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }

    }
}