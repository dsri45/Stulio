using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Services
{
    public class AthleticParticipationService : IAthleticParticipationService
    {

        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student2.db3");
                //string dbPath = @"C:\Users\dhana\AppData\Local\Student.db3";
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<AthleticParticipationModel>();
            }
        }


        public async Task<int> AddAthleticParticipation(AthleticParticipationModel athleticParticipationModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(athleticParticipationModel);
        }

        public async Task<int> DeleteAthleticParticipation(AthleticParticipationModel athleticParticipationModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(athleticParticipationModel);
        }

        public async Task<List<AthleticParticipationModel>> GetAthleticParticipationList(int studentID)
        {
            await SetUpDb();
            var athleticParticipationList = await _dbConnection.Table<AthleticParticipationModel>().Where(s => s.StudentID == studentID).ToListAsync();
            return athleticParticipationList;
        }

        public async Task<AthleticParticipationModel> LoadAthleticParticipationByID(int studentID, int atheleticId)
        {
            await SetUpDb();
            var athleticParticipation = await _dbConnection.Table<AthleticParticipationModel>().Where(s => s.StudentID == studentID && s.AthleticId == atheleticId).FirstOrDefaultAsync();
            if (athleticParticipation == null)
            {

                athleticParticipation = new AthleticParticipationModel
                {
                    StudentID = 1, // Default ID,
                    AthleticId = 1,
                    Sport = "",
                    Role = "",
                    ParticpatedYears = "",
                    Achivements = ""

                };
            }
            return athleticParticipation;
        }

        public async Task<int> UpdateAthleticParticipation(AthleticParticipationModel athleticParticipationModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(athleticParticipationModel);
        }
    }
}
