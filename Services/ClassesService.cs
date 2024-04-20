using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public class ClassesService : IClassesService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {


                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student2.db3");
                //string dbPath = @"C:\Users\dhana\AppData\Local\Student.db3";
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<ClassesModel>();
            }
        }

        public async Task<int> AddClasses(ClassesModel classesModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(classesModel);
        }

        public async Task<int> DeleteClasses(ClassesModel classesModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(classesModel);
        }

        public async Task<List<ClassesModel>> GetClassesList(int studentID)
        {
            await SetUpDb();
            var classesList = await _dbConnection.Table<ClassesModel>().Where(s => s.StudentID == studentID).ToListAsync();
            return classesList;
        }
        public async Task<ClassesModel> LoadClassesByID(int studentID, int ClassId)
        {
            await SetUpDb();
            var classes = await _dbConnection.Table<ClassesModel>().Where(s => s.StudentID == studentID && s.ClassId == ClassId).FirstOrDefaultAsync();
            if(classes == null)
            {

                classes = new ClassesModel
                {
                    StudentID = 1, // Default ID
                    ClassId = 1,
                    Name= "",
                    ClassYear = "",
                    Grade = ""
    };
            }
            return classes;
        }

        public async Task<int> UpdateClasses(ClassesModel classesModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(classesModel);
        }
      

    }
}
