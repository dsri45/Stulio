﻿//using Microsoft.Toolkit.Mvvm.ComponentModel;
//using Microsoft.Toolkit.Mvvm.Input;
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
    public partial class StudentListPageViewModel : ObservableObject
    {
        public static List<StudentModel> StudentsListForSearch { get; private set; } = new List<StudentModel>();
        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();

        private readonly IStudentService _studentService;
        public StudentListPageViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }



        [RelayCommand]
        public async void GetStudentList()
        {
            Students.Clear();
            var studentList = await _studentService.GetStudentList();
            if (studentList?.Count > 0)
            {
                studentList = studentList.OrderBy(f => f.FullName).ToList();
                foreach (var student in studentList)
                {
                    Students.Add(student);
                }
                StudentsListForSearch.Clear();
                StudentsListForSearch.AddRange(studentList);
            }
        }


        [RelayCommand]
        public async void AddUpdateStudent()
        {
            await AppShell.Current.GoToAsync(nameof(ShowStudentProfile));
        }

        [RelayCommand]
        public async void EditStudent(StudentModel studentModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("StudentDetail", studentModel);
            await AppShell.Current.GoToAsync(nameof(ShowStudentProfile), navParam);
        }

        [RelayCommand]
        public async void DeleteStudent(StudentModel studentModel)
        {
            var delResponse = await _studentService.DeleteStudent(studentModel);
            if (delResponse > 0)
            {
                GetStudentList();
            }
        }


        [RelayCommand]
        public async void DisplayAction(StudentModel studentModel)
        {
            Preferences.Set("ShowUserID", studentModel.StudentID);
            await AppShell.Current.GoToAsync(nameof(ShowStudentProfile));
            
        }
    }
}