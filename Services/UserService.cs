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


                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student2.db3");
                //string dbPath = @"C:\Users\dhana\AppData\Local\Student.db3";
                 _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<UserModel>();
            }
        }

        public async Task<int> AddUser(UserModel UserModel)
        {
            await SetUpDb();
            await _dbConnection.CreateTableAsync<UserModel>();
            await _dbConnection.InsertAsync(UserModel);
            Preferences.Set("UserID", UserModel.UserId);
            
            //Adding new studentmodel
            StudentModel studentModel = new StudentModel {
                FirstName = UserModel.FirstName,
                LastName= UserModel.LastName,
                SchoolName = UserModel.SchoolName,
                Email = UserModel.Email,
                PhoneNumber=UserModel.PhoneNumber
            };
            await _dbConnection.InsertAsync(studentModel);

            return UserModel.UserId;
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
                    PhoneNumber="123 456 345",
                    SchoolName = "Ceadarcrest High School, Duvall",
                };

   
    }

            // Save UserID
            Preferences.Set("UserID", userId);

            // Retrieve UserID
            //var UserID = Preferences.Get("UserID", defaultValue);
            return user;
        }

        public async Task<UserModel> LoadUserByUserName(string UserName, string Password)
        {
            try
            {
                await SetUpDb();
                var user = await _dbConnection.Table<UserModel>().Where(s => s.Username == UserName && s.Password == Password).FirstOrDefaultAsync();
                if (user == null)
                {

                    user = new UserModel
                    {
                        UserId = 1, // Default ID
                        Username = "Dhanasri",
                        Password = "Prabhu",
                        Email = "DhansriPrabhu03@gmail.com",
                        PhoneNumber = "123 456 345",
                        SchoolName = "Ceadarcrest High School, Duvall",
                    };


                }

                // Save UserID
                Preferences.Set("UserID", user.UserId);

                
                return user;
            }
            catch (Exception ex)
            {
                // Handle exceptions, such as database connectivity issues or SQL syntax errors
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
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
