
using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUserList();
        Task<int> AddUser(UserModel userModel);
        Task<UserModel> LoadUserByID(int UserID);
        Task<int> DeleteUser(UserModel userModel);
        Task<int> UpdateUser(UserModel userModel);

    }
}
