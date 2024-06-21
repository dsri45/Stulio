
using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public interface IForumService
    {
        Task<ForumModel> CallChatGptAPI(string prompt);
        

    }
}
