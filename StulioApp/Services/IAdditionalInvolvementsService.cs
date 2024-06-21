using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public interface IAdditionalInvolvementsService
    {
        Task<List<AdditionalInvolvementsModel>> GetAdditionalInvolvementsList(int studentID);
        Task<int> AddAdditionalInvolvements(AdditionalInvolvementsModel additionalInvolvementsModel);
        Task<AdditionalInvolvementsModel> LoadAdditionalInvolvementsByID(int studentID, int involvementId);
        Task<int> DeleteAdditionalInvolvements(AdditionalInvolvementsModel additionalInvolvementsModel);
        Task<int> UpdateAdditionalInvolvements(AdditionalInvolvementsModel additionalInvolvementsModel);

    }
}
