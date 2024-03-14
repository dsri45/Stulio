﻿
using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public interface IAcademicAchievementsService
    {
        Task<List<AcademicAchievementsModel>> GetAcademicAchievementsList();
        Task<int> AddAcademicAchievements(AcademicAchievementsModel academicAchievementsModel);
        Task<AcademicAchievementsModel> LoadAcademicAchievementsByID(int studentID);
        Task<int> DeleteAcademicAchievements(AcademicAchievementsModel academicAchievementsModel);
        Task<int> UpdateAcademicAchievements(AcademicAchievementsModel academicAchievementsModel);
       
    }
}
