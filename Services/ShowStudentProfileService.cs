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

        AthleticParticipationService _athleticParticipationService = new AthleticParticipationService();
        private AthleticParticipationModel athleticParticipationModel;

        WorkExperienceService _workExperienceService = new WorkExperienceService();
        private WorkExperienceModel workExperienceModel;

        ClassesService _classesService = new ClassesService();
        private ClassesModel classesModel;

        AdditionalInvolvementsService _additionalInvolvementsService = new AdditionalInvolvementsService();
        private AdditionalInvolvementsModel additionalInvolvementsModel;

        PersonalEndeavorsService _personalEndeavorsService = new PersonalEndeavorsService();
        private PersonalEndeavorsModel personalEndeavorsModel;


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

        public async Task<List<AthleticParticipationModel>> GetAthleticParticipation()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("UserID", 1);
            List<AthleticParticipationModel> athleticParticipation = await _athleticParticipationService.GetAthleticParticipationList();
            return athleticParticipation;
        }

        public async Task<List<WorkExperienceModel>> GetWorkExperience()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("UserID", 1);
            List<WorkExperienceModel> workExperience = await _workExperienceService.GetWorkExperienceList();
            return workExperience;
        }

        public async Task<List<ClassesModel>> GetClasses()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("UserID", 1);
            List<ClassesModel> classes = await _classesService.GetClassesList();
            return classes;
        }

        public async Task<List<AdditionalInvolvementsModel>> GetAdditionalInvolvements()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("UserID", 1);
            List<AdditionalInvolvementsModel> additionalInvolvements = await _additionalInvolvementsService.GetAdditionalInvolvementsList();
            return additionalInvolvements;
        }

        public async Task<List<PersonalEndeavorsModel>> GetPersonalEndeavors()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("UserID", 1);
            List<PersonalEndeavorsModel> personalEndeavors = await _personalEndeavorsService.GetPersonalEndeavorsList();
            return personalEndeavors;
        }
    }

  
}
