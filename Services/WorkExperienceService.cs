using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Services
{
    public class WorkExperienceService : IWorkExperienceService
    {

        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student2.db3");
                //string dbPath = @"C:\Users\dhana\AppData\Local\Student.db3";
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<WorkExperienceModel>();
            }
        }


        public async Task<int> AddWorkExperience(WorkExperienceModel workExperienceModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(workExperienceModel);
        }

        public async Task<int> DeleteWorkExperience(WorkExperienceModel workExperienceModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(workExperienceModel);
        }

        public async Task<List<WorkExperienceModel>> GetWorkExperienceList(int studentID)
        {
            await SetUpDb();
            var workExperienceList = await _dbConnection.Table<WorkExperienceModel>().Where(s => s.StudentID == studentID).ToListAsync();
            return workExperienceList;
        }

        public async Task<WorkExperienceModel> LoadWorkExperienceByID(int studentID, int workId)
        {
            await SetUpDb();
            var workExperience = await _dbConnection.Table<WorkExperienceModel>().Where(s => s.StudentID == studentID && s.WorkId == workId).FirstOrDefaultAsync();
            if (workExperience == null)
            {

                workExperience = new WorkExperienceModel
                {
                    StudentID = 1, // Default ID
                    WorkId = 1,
                    Establishment = "",
                    ParticpatedYears = "",
                    Role = "",
                    Description = ""

                };
            }
            return workExperience;
        }

        public async Task<int> UpdateWorkExperience(WorkExperienceModel workExperienceModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(workExperienceModel);
        }
    }
}
