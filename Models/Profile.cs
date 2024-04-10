using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Models 
{
    public class Profile
    {
        [PrimaryKey, AutoIncrement]
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public School School { get; set; }
        public string GradeLevel { get; set; }
        public int GraduationYear { get; set; }
        public AcademicAchievementsModel AcademicAchievements { get; set; }
        public List<ClubsAndOrganizationsModel> ClubsOrganizations { get; set; }
        public List<AthleticParticipationModel> AthleticParticipation { get; set; }
        public List<CommunityServiceModel> CommunityService { get; set; }
        public List<OtherExtracurriculars> OtherExtracurriculars { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

    }
}
