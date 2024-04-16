using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Stulio.Models;

namespace Stulio.Services
{
    public class ShowStudentProfileService : IShowStudentProfileService
    {
        StudentService _studentService = new StudentService();
        private StudentModel studentDetail;

        AcademicAchievementservice _academicAchievementservice = new AcademicAchievementservice();
        private AcademicAchievementsModel academicAchievementsmodel;

        ClubsAndOrganizationsService _clubsAndOrganizationsService = new ClubsAndOrganizationsService();
        private ClubsAndOrganizationsModel clubsAndOrganizationsModel;

        CommunityServiceService _communityServiceService = new CommunityServiceService();
        private CommunityServiceModel communityServiceModel;

        public async Task<StudentModel> GetStudent()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("UserID", 1);
            StudentModel studentDetail = await _studentService.LoadStudentByID(userID);
            return studentDetail;
        }

        public async Task<List<AcademicAchievementsModel>> GetAcademicAchievement()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("UserID", 1);
            List<AcademicAchievementsModel> academicAchievements = await _academicAchievementservice.GetAcademicAchievementsList();
            return academicAchievements;
        }

        public async Task<List<ClubsAndOrganizationsModel>> GetClubsAndOrganizations()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("UserID", 1);
            List<ClubsAndOrganizationsModel> clubsAndOrganizations = await _clubsAndOrganizationsService.GetClubsAndOrganizationsList();
            return clubsAndOrganizations;
        }

        public async Task<List<CommunityServiceModel>> GetCommunityService()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("UserID", 1);
            List<CommunityServiceModel> communityService = await _communityServiceService.GetCommunityServiceList();
            return communityService;
        }
    }

  
}
