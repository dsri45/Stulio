﻿
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
    public partial class AboutMeViewModel : ObservableObject
    {
        [ObservableProperty]
        StudentModel studentDetail;
// private StudentModel _studentDetail = new StudentModel();

        private readonly IStudentService _studentService;
        public AboutMeViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [RelayCommand]
        public async void UpdateAboutMe()
        {
            int response = -1;
            if (studentDetail.StudentID > 0)
            {
                response = await _studentService.UpdateAboutMe(studentDetail);
            }
           

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Student Info Saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }

    }
}