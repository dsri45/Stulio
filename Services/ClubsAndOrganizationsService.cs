using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Services
{
    public class ClubsAndOrganizationsService : IClubsAndOrganizationsService
    {

        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                //string dbPath = @"C:\Users\dhana\AppData\Local\Student.db3";
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<ClubsAndOrganizationsModel>();
            }
        }


        public async Task<int> AddClubsAndOrganizations(ClubsAndOrganizationsModel clubsAndOrganizationsModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(clubsAndOrganizationsModel);
        }

        public async Task<int> DeleteClubsAndOrganizations(ClubsAndOrganizationsModel clubsAndOrganizationsModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(clubsAndOrganizationsModel);
        }

        public async Task<List<ClubsAndOrganizationsModel>> GetClubsAndOrganizationsList()
        {
            await SetUpDb();
            var clubsAndOrganizationsList = await _dbConnection.Table<ClubsAndOrganizationsModel>().ToListAsync();
            return clubsAndOrganizationsList;
        }

        public async Task<ClubsAndOrganizationsModel> LoadClubsAndOrganizationsByID(int studentID)
        {
            await SetUpDb();
            var clubsAndOrganizations = await _dbConnection.Table<ClubsAndOrganizationsModel>().Where(s => s.StudentID == studentID).FirstOrDefaultAsync();
            if (clubsAndOrganizations == null)
            {

                clubsAndOrganizations = new ClubsAndOrganizationsModel
                {
                    StudentID = 1, // Default ID
                    ClubName = "",
                    ParticpatedYears = "",
                    Role = "",
                    Description = "",
                    Achivements = ""

                };
            }
            return clubsAndOrganizations;
        }

        public async Task<int> UpdateClubsAndOrganizations(ClubsAndOrganizationsModel clubsAndOrganizationsModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(clubsAndOrganizationsModel);
        }
    }
}
