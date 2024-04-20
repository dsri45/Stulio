using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public class AcademicAchievementservice : IAcademicAchievementsService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {


                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student2.db3");
                //string dbPath = @"C:\Users\dhana\AppData\Local\Student.db3";
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<AcademicAchievementsModel>();
            }
        }

        public async Task<int> AddAcademicAchievements(AcademicAchievementsModel academicAchievementsModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(academicAchievementsModel);
        }

        public async Task<int> DeleteAcademicAchievements(AcademicAchievementsModel academicAchievementsModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(academicAchievementsModel);
        }

        public async Task<List<AcademicAchievementsModel>> GetAcademicAchievementsList(int studentID)
        {
            await SetUpDb();
            var academicAchievementsList = await _dbConnection.Table<AcademicAchievementsModel>().Where(s => s.StudentID == studentID ).ToListAsync();
            return academicAchievementsList;
        }
        public async Task<AcademicAchievementsModel> LoadAcademicAchievementsByID(int studentID, int AcademicId)
        {
            await SetUpDb();
            var academicAchievements = await _dbConnection.Table<AcademicAchievementsModel>().Where(s => s.StudentID == studentID && s.AcademicId==AcademicId).FirstOrDefaultAsync();
            if(academicAchievements == null)
            {

                academicAchievements = new AcademicAchievementsModel
                {
                    StudentID = 1, // Default ID
                    AcademicId = 1,
                    DateAchived= "",
                    Award = "",
                    Class = ""

    };
            }
            return academicAchievements;
        }

        public async Task<int> UpdateAcademicAchievements(AcademicAchievementsModel academicAchievementsModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(academicAchievementsModel);
        }
      

    }
}
