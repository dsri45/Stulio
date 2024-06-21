using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public interface IClassesService
    {
        Task<List<ClassesModel>> GetClassesList(int studentID);
        Task<int> AddClasses(ClassesModel classesModel);
        Task<ClassesModel> LoadClassesByID(int studentID, int classesId);
        Task<int> DeleteClasses(ClassesModel classesModel);
        Task<int> UpdateClasses(ClassesModel classesModel);

    }
}
