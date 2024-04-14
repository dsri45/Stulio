using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    public class StudentService : IStudentService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {


                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student2.db3");
                //string dbPath = @"C:\Users\dhana\AppData\Local\Student.db3";
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<StudentModel>();
            }
        }

        public async Task<int> AddStudent(StudentModel studentModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(studentModel);
        }

        public async Task<int> DeleteStudent(StudentModel studentModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(studentModel);
        }

        public async Task<List<StudentModel>> GetStudentList()
        {
            await SetUpDb();
            var studentList = await _dbConnection.Table<StudentModel>().ToListAsync();
            return studentList;
        }
        public async Task<StudentModel> LoadStudentByID(int studentID)
        {
            await SetUpDb();
            var student = await _dbConnection.Table<StudentModel>().Where(s => s.StudentID == studentID).FirstOrDefaultAsync();
            if(student == null)
            {

                student = new StudentModel
                {
                    StudentID = 1, // Default ID
                    FirstName = "Dhanasri",
                    LastName = "Prabhu",
                    Email = "DhansriPrabhu03@gmail.com",
                    PhoneNumber = "425 606 9993",
                    AboutMe = "Passionate high school student deeply committed to the world of computer science, with a fervent interest in artificial intelligence (AI) and its applications. I am actively seeking opportunities to push boundaries and contribute to cutting-edge research. Motivated by the intersection of computer science and biology, I am excited to embark on a journey of exploration, leveraging technology to drive innovation and contribute to advancements in the field."
                };
            }

            // Save studentID
            Preferences.Set("studentID", student.StudentID);

            // Retrieve studentID
            //var studentID = Preferences.Get("studentID", defaultValue);
            return student;
        }

        public async Task<int> UpdateStudent(StudentModel studentModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(studentModel);
        }
        public async Task<int> UpdateAboutMe(StudentModel studentModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(studentModel);
        }

    }
}
