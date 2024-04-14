using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public interface ICommunityServiceService
    {
        Task<List<CommunityServiceModel>> GetCommunityServiceList();
        Task<int> AddCommunityService(CommunityServiceModel communityServiceModel);
        Task<CommunityServiceModel> LoadCommunityServiceByID(int studentID, int communityId);
        Task<int> DeleteCommunityService(CommunityServiceModel communityServiceModel);
        Task<int> UpdateCommunityService(CommunityServiceModel communityServiceModel);

    }
}
