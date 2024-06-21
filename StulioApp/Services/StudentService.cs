using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Services
{
    // This class implements the IStudentService interface to manage student data using a SQLite database.
    public class StudentService : IStudentService
    {
        // Private field to hold the SQLite asynchronous database connection
        private SQLiteAsyncConnection _dbConnection;

        // Sets up the database connection and creates the table if it doesn't exist
        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                // Define the database path in the local application data folder
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student2.db3");
                // Initialize the SQLite connection
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                // Create the StudentModel table if it does not already exist
                await _dbConnection.CreateTableAsync<StudentModel>();
            }
        }

        // Adds a new student to the database
        public async Task<int> AddStudent(StudentModel studentModel)
        {
            await SetUpDb();
            // Insert the new student into the database and return the result
            return await _dbConnection.InsertAsync(studentModel);
        }

        // Deletes a student from the database
        public async Task<int> DeleteStudent(StudentModel studentModel)
        {
            await SetUpDb();
            // Delete the specified student from the database and return the result
            return await _dbConnection.DeleteAsync(studentModel);
        }

        // Retrieves all students from the database
        public async Task<List<StudentModel>> GetStudentList()
        {
            await SetUpDb();
            // Retrieve and return the list of all students
            var studentList = await _dbConnection.Table<StudentModel>().ToListAsync();
            //studentList.Find(p => p.FirstName == "Adam").Profilepicture = "adam";
            //studentList.Find(p => p.FirstName == "Sophia").Profilepicture = "sophia";
           
            return studentList;
        }

        // Loads a student's data by their ID
        public async Task<StudentModel> LoadStudentByID(int studentID)
        {
            await SetUpDb();
            // Retrieve the first student matching the given ID or return null if not found
            var student = await _dbConnection.Table<StudentModel>().Where(s => s.StudentID == studentID).FirstOrDefaultAsync();
            if (student == null)
            {
                // Provide a default student if the specified ID is not found
                student = new StudentModel
                {
                    StudentID = 999, // Default ID
                    FirstName = "Dhanasri",
                    LastName = "Prabhu",
                    Email = "DhansriPrabhu03@gmail.com",
                    PhoneNumber = "425 606 9993",
                    AboutMe = "Passionate high school student deeply committed to the world of computer science, with a fervent interest in artificial intelligence (AI) and its applications. I am actively seeking opportunities to push boundaries and contribute to cutting-edge research. Motivated by the intersection of computer science and biology, I am excited to embark on a journey of exploration, leveraging technology to drive innovation and contribute to advancements in the field."
                };
            }

            // Save the student ID in preferences for later access
            Preferences.Set("studentID", student.StudentID);

            return student;
        }

        // Updates a student's details in the database
        public async Task<int> UpdateStudent(StudentModel studentModel)
        {
            await SetUpDb();
            // Update the student in the database and return the result
            return await _dbConnection.UpdateAsync(studentModel);
        }

        // Updates the "About Me" section of a student's profile in the database
        public async Task<int> UpdateAboutMe(StudentModel studentModel)
        {
            await SetUpDb();
            // Update the student's "About Me" in the database and return the result
            return await _dbConnection.UpdateAsync(studentModel);
        }
    }
}
