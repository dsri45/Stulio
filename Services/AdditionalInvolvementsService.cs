using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Services
{
    public class AdditionalInvolvementsService : IAdditionalInvolvementsService
    {

        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student2.db3");
                //string dbPath = @"C:\Users\dhana\AppData\Local\Student.db3";
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<AdditionalInvolvementsModel>();
            }
        }


        public async Task<int> AddAdditionalInvolvements(AdditionalInvolvementsModel additionalInvolvementsModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(additionalInvolvementsModel);
        }

        public async Task<int> DeleteAdditionalInvolvements(AdditionalInvolvementsModel additionalInvolvementsModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(additionalInvolvementsModel);
        }

        public async Task<List<AdditionalInvolvementsModel>> GetAdditionalInvolvementsList(int studentID)
        {
            await SetUpDb();
            var additionalInvolvementsList = await _dbConnection.Table<AdditionalInvolvementsModel>().Where(s => s.StudentID == studentID).ToListAsync();
            return additionalInvolvementsList;
        }

        public async Task<AdditionalInvolvementsModel> LoadAdditionalInvolvementsByID(int studentID, int involvementId)
        {
            await SetUpDb();
            var additionalInvolvements = await _dbConnection.Table<AdditionalInvolvementsModel>().Where(s => s.StudentID == studentID && s.InvolvementId == involvementId).FirstOrDefaultAsync();
            if (additionalInvolvements == null)
            {

                additionalInvolvements = new AdditionalInvolvementsModel
                {
                    StudentID = 1, // Default ID
                    InvolvementId = -1,
                    ActivityName = "",
                    ParticpatedYears = "",
                    Role = "",
                    Description = "",
                    Achivements = ""

                };
            }
            return additionalInvolvements;
        }

        public async Task<int> UpdateAdditionalInvolvements(AdditionalInvolvementsModel additionalInvolvementsModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(additionalInvolvementsModel);
        }
    }
}
