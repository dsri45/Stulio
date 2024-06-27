using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Services
{
    public class CommunityServiceService : ICommunityServiceService
    {

        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student2.db3");
                //string dbPath = @"C:\Users\dhana\AppData\Local\Student.db3";
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<CommunityServiceModel>();
            }
        }


        public async Task<int> AddCommunityService(CommunityServiceModel communityServiceModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(communityServiceModel);
        }

        public async Task<int> DeleteCommunityService(CommunityServiceModel communityServiceModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(communityServiceModel);
        }

        public async Task<List<CommunityServiceModel>> GetCommunityServiceList(int studentID)
        {
            await SetUpDb();
            var communityServiceList = await _dbConnection.Table<CommunityServiceModel>().Where(s => s.StudentID == studentID).ToListAsync();
            return communityServiceList;
        }

        public async Task<CommunityServiceModel> LoadCommunityServiceByID(int studentID, int communityId)
        {
            await SetUpDb();
            var communityService = await _dbConnection.Table<CommunityServiceModel>().Where(s => s.StudentID == studentID && s.CommunityId == communityId).FirstOrDefaultAsync();
            if (communityService == null)
            {

                communityService = new CommunityServiceModel
                {
                    StudentID = 1, // Default ID
                    CommunityId = -1,
                    ServiceName = "",
                    ParticpatedYears = "",
                    StartDate = new DateTime(2024, 6, 21),
                    EndDate = new DateTime(2024, 6, 21),
                    VoulnteeredHours = "",
                    Description = ""
 
                };
            }
            return communityService;
        }

        public async Task<int> UpdateCommunityService(CommunityServiceModel communityServiceModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(communityServiceModel);
        }
    }
}
