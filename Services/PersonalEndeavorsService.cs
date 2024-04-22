using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public class PersonalEndeavorsService : IPersonalEndeavorsService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {


                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student2.db3");
                //string dbPath = @"C:\Users\dhana\AppData\Local\Student.db3";
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<PersonalEndeavorsModel>();
            }
        }

        public async Task<int> AddPersonalEndeavors(PersonalEndeavorsModel personalEndeavorsModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(personalEndeavorsModel);
        }

        public async Task<int> DeletePersonalEndeavors(PersonalEndeavorsModel personalEndeavorsModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(personalEndeavorsModel);
        }

        public async Task<List<PersonalEndeavorsModel>> GetPersonalEndeavorsList(int studentID)
        {
            await SetUpDb();
            var personalEndeavorsList = await _dbConnection.Table<PersonalEndeavorsModel>().Where(s => s.StudentID == studentID).ToListAsync();
            return personalEndeavorsList;
        }
        public async Task<PersonalEndeavorsModel> LoadPersonalEndeavorsByID(int studentID, int EndeavorId)
        {
            await SetUpDb();
            var personalEndeavors = await _dbConnection.Table<PersonalEndeavorsModel>().Where(s => s.StudentID == studentID && s.EndeavorId == EndeavorId).FirstOrDefaultAsync();
            if(personalEndeavors == null)
            {

                personalEndeavors = new PersonalEndeavorsModel
                {
                    StudentID = 1, // Default ID
                    EndeavorId = -1,
                    Title= "",
                    Description = ""

    };
            }
            return personalEndeavors;
        }

        public async Task<int> UpdatePersonalEndeavors(PersonalEndeavorsModel personalEndeavorsModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(personalEndeavorsModel);
        }
      

    }
}
