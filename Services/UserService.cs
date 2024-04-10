using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public class UserService : IUserService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {


                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                //string dbPath = @"C:\Users\dhana\AppData\Local\Student.db3";
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<UserModel>();
            }
        }

        public async Task<int> AddUser(UserModel UserModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(UserModel);
        }

        public async Task<int> DeleteUser(UserModel UserModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(UserModel);
        }

        public async Task<List<UserModel>> GetUserList()
        {
            await SetUpDb();
            var UserList = await _dbConnection.Table<UserModel>().ToListAsync();
            return UserList;
        }
        public async Task<UserModel> LoadUserByID(int userId)
        {
            await SetUpDb();
            var user = await _dbConnection.Table<UserModel>().Where(s => s.UserId == userId).FirstOrDefaultAsync();
            if(user == null)
            {

                user = new UserModel
                {
                    UserId = 1, // Default ID
                    Username = "Dhanasri",
                    Password = "Prabhu",
                    Email = "DhansriPrabhu03@gmail.com",
                    SchoolName = "425 606 9993",
                };

   
    }

            // Save UserID
            Preferences.Set("UserID", userId);

            // Retrieve UserID
            //var UserID = Preferences.Get("UserID", defaultValue);
            return user;
        }

        public async Task<int> UpdateUser(UserModel userModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(userModel);
        }
        public async Task<int> UpdateAboutMe(UserModel userModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(userModel);
        }

    }
}
