using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Models
{
    public class StudentModel
    {
        [PrimaryKey]
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Ignore]
        public string FullName => $"{FirstName} {LastName}";
        public string PhoneNumber { get; set; }
        public string  AboutMe { get; set; }
    }
}