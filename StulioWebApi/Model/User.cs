using System.ComponentModel.DataAnnotations;
namespace StulioWebAPI.Model
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string SchoolName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
