
using SQLite;
using Stulio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stulio.Services
{
    // Interface defining the operations for managing student data
    public interface IStudentService
    {
        // Retrieves a list of all students
        Task<List<StudentModel>> GetStudentList();

        // Adds a new student to the database
        Task<int> AddStudent(StudentModel studentModel);

        // Loads a single student's details by their ID
        Task<StudentModel> LoadStudentByID(int studentID);

        // Deletes a student from the database
        Task<int> DeleteStudent(StudentModel studentModel);

        // Updates a student's details in the database
        Task<int> UpdateStudent(StudentModel studentModel);

        // Specifically updates the "About Me" section of a student's profile
        Task<int> UpdateAboutMe(StudentModel studentModel);
    }
}
