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
            int userID = Preferences.Get("ShowUserID", 999);
            StudentModel studentDetail = await _studentService.LoadStudentByID(userID);
            return studentDetail;
        }

        public async Task<List<AcademicAchievementsModel>> GetAcademicAchievement()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("ShowUserID", 999);
            List<AcademicAchievementsModel> academicAchievements = await _academicAchievementservice.GetAcademicAchievementsList(userID);
            return academicAchievements;
        }

        public async Task<List<ClubsAndOrganizationsModel>> GetClubsAndOrganizations()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("ShowUserID", 999);
            List<ClubsAndOrganizationsModel> clubsAndOrganizations = await _clubsAndOrganizationsService.GetClubsAndOrganizationsList(userID);
            return clubsAndOrganizations;
        }

        public async Task<List<CommunityServiceModel>> GetCommunityService()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("ShowUserID", 999);
            List<CommunityServiceModel> communityService = await _communityServiceService.GetCommunityServiceList(userID);
            return communityService;
        }

        public async Task<List<AthleticParticipationModel>> GetAthleticParticipation()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("ShowUserID", 999);
            List<AthleticParticipationModel> athleticParticipation = await _athleticParticipationService.GetAthleticParticipationList(userID);
            return athleticParticipation;
        }

        public async Task<List<WorkExperienceModel>> GetWorkExperience()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("ShowUserID", 999);
            List<WorkExperienceModel> workExperience = await _workExperienceService.GetWorkExperienceList(userID);
            return workExperience;
        }

        public async Task<List<ClassesModel>> GetClasses()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("ShowUserID", 999);
            List<ClassesModel> classes = await _classesService.GetClassesList(userID);
            return classes;
        }

        public async Task<List<AdditionalInvolvementsModel>> GetAdditionalInvolvements()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("ShowUserID", 999);
            List<AdditionalInvolvementsModel> additionalInvolvements = await _additionalInvolvementsService.GetAdditionalInvolvementsList(userID);
            return additionalInvolvements;
        }

        public async Task<List<PersonalEndeavorsModel>> GetPersonalEndeavors()
        {
            // Simulated data retrieval from Model 1
            int userID = Preferences.Get("ShowUserID", 999);
            List<PersonalEndeavorsModel> personalEndeavors = await _personalEndeavorsService.GetPersonalEndeavorsList(userID);
            return personalEndeavors;
        }
    }

  
}
