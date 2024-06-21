
using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public interface IShowStudentProfileService
    {
        Task<StudentModel> GetStudent();
        Task<List<AcademicAchievementsModel>> GetAcademicAchievement();
        

    }
}
