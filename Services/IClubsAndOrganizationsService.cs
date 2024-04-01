using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public interface IClubsAndOrganizationsService
    {
        Task<List<ClubsAndOrganizationsModel>> GetClubsAndOrganizationsList();
        Task<int> AddClubsAndOrganizations(ClubsAndOrganizationsModel clubsAndOrganizationsModel);
        Task<ClubsAndOrganizationsModel> LoadClubsAndOrganizationsByID(int studentID);
        Task<int> DeleteClubsAndOrganizations(ClubsAndOrganizationsModel clubsAndOrganizationsModel);
        Task<int> UpdateClubsAndOrganizations(ClubsAndOrganizationsModel clubsAndOrganizationsModel);

    }
}
