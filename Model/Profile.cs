using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Model
{
    public class Profile
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public School School { get; set; }
        public string GradeLevel { get; set; }
        public int GraduationYear { get; set; }
        public AcademicAchievements AcademicAchievements { get; set; }
        public List<ClubsOrganizations> ClubsOrganizations { get; set; }
        public List<AthleticParticipation> AthleticParticipation { get; set; }
        public List<CommunityService> CommunityService { get; set; }
        public List<OtherExtracurriculars> OtherExtracurriculars { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

    }
}
