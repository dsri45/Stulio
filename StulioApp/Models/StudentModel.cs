using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Models
{
    // Class definition for a student model
    public class StudentModel
    {
        // Marks StudentID as the primary key in the database
        [PrimaryKey]
        public int StudentID { get; set; }

        // First name of the student
        public string FirstName { get; set; }

        // Last name of the student
        public string LastName { get; set; }

        // Name of the school the student is attending
        public string SchoolName { get; set; }

        // Email address of the student
        public string Email { get; set; }

        // Property to get the full name by concatenating first and last names; ignored in database schema
        [Ignore]
        public string FullName => $"{FirstName} {LastName}";

        // Phone number of the student
        public string PhoneNumber { get; set; }

        // Brief description or biography of the student
        public string AboutMe { get; set; }

        // URL or path to the student's profile picture
        public string Profilepicture { get; set; }
    }
}
