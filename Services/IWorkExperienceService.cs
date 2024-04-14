using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public interface IWorkExperienceService
    {
        Task<List<WorkExperienceModel>> GetWorkExperienceList();
        Task<int> AddWorkExperience(WorkExperienceModel workExperienceModel);
        Task<WorkExperienceModel> LoadWorkExperienceByID(int studentID, int workId);
        Task<int> DeleteWorkExperience(WorkExperienceModel workExperienceModel);
        Task<int> UpdateWorkExperience(WorkExperienceModel workExperienceModel);

    }
}
