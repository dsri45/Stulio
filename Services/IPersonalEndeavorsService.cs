using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public interface IPersonalEndeavorsService
    {
        Task<List<PersonalEndeavorsModel>> GetPersonalEndeavorsList();
        Task<int> AddPersonalEndeavors(PersonalEndeavorsModel personalEndeavorsModel);
        Task<PersonalEndeavorsModel> LoadPersonalEndeavorsByID(int studentID, int endeavorId);
        Task<int> DeletePersonalEndeavors(PersonalEndeavorsModel personalEndeavorsModel);
        Task<int> UpdatePersonalEndeavors(PersonalEndeavorsModel personalEndeavorsModel);

    }
}
