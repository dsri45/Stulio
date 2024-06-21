using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public interface IAthleticParticipationService
    {
        Task<List<AthleticParticipationModel>> GetAthleticParticipationList(int studentID);
        Task<int> AddAthleticParticipation(AthleticParticipationModel athleticParticipationModel);
        Task<AthleticParticipationModel> LoadAthleticParticipationByID(int studentID, int atheleticId);
        Task<int> DeleteAthleticParticipation(AthleticParticipationModel athleticParticipationModel);
        Task<int> UpdateAthleticParticipation(AthleticParticipationModel athleticParticipationModel);

    }
}
