
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Stulio.Models;
using Stulio.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using iText.Kernel.Pdf; // Namespace for iText PDF functionality
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using System.Globalization;
using Xamarin.Essentials;
using iText.Layout.Properties;
using iText.Kernel.Pdf.Action;

namespace Stulio.ViewModels
{
    public partial class ShowStudentProfileViewModel : ObservableObject
    {

       
        private readonly ShowStudentProfileService _dataService;

        [ObservableProperty]
        public StudentModel showStudent;

        public ObservableCollection<ClassesModel> ShowClasses { get; set; } = new ObservableCollection<ClassesModel>();
        public ObservableCollection<AcademicAchievementsModel> ShowAcademicAchievements { get; set; } = new ObservableCollection<AcademicAchievementsModel>();
        public ObservableCollection<ClubsAndOrganizationsModel> ShowClubsAndOrganizations { get; set; } = new ObservableCollection<ClubsAndOrganizationsModel>();
        public ObservableCollection<CommunityServiceModel> ShowCommunityService { get; set; } = new ObservableCollection<CommunityServiceModel>();
        public ObservableCollection<AthleticParticipationModel> ShowAthleticParticipation { get; set; } = new ObservableCollection<AthleticParticipationModel>();
        public ObservableCollection<WorkExperienceModel> ShowWorkExperience { get; set; } = new ObservableCollection<WorkExperienceModel>();
        public ObservableCollection<AdditionalInvolvementsModel> ShowAdditionalInvolvements { get; set; } = new ObservableCollection<AdditionalInvolvementsModel>();
        public ObservableCollection<PersonalEndeavorsModel> ShowPersonalEndeavors { get; set; } = new ObservableCollection<PersonalEndeavorsModel>();

        public ICommand GenerateResumeCommand { get; }


        public ShowStudentProfileViewModel()
            {
                _dataService = new ShowStudentProfileService();
                 GenerateResumeCommand = new Command(async () => await ExecuteGenerateResume());
            //LoadRecords();
        }



            public async Task LoadRecords()
            {
            //Microsoft.Maui.Storage.Preferences.Set("ShowUserID", ShowStudent.StudentID);
            // Retrieve data from DataService
            //var studentModels = await _dataService.GetStudent(); // Assuming GetStudentModels returns a list of StudentModel
            //var academicAchievements = await _dataService.GetAcademicAchievement(); // Assuming GetAcademicAchievements returns a list of AcademicAchievement
            LoadByStudentID();
            GetAcademicAchievementsList();
            GetClubsAndOrganizationsList();
            GetCommunityServiceList();
            GetAthleticParticipationList();
            GetWorkExperienceList();
            GetPersonalEndeavorsList();
            GetClassesList();
            GetAdditionalInvolvementsList();
           }

       [RelayCommand]
        public async void GetAcademicAchievementsList()
        {
            ShowAcademicAchievements.Clear();
            var academicAchievementsList = await _dataService.GetAcademicAchievement();
            if (academicAchievementsList?.Count > 0)
            {
                academicAchievementsList = academicAchievementsList.OrderBy(f => f.Award).ToList();
                foreach (var academicAchievement in academicAchievementsList)
                {
                    ShowAcademicAchievements.Add(academicAchievement);
                }
             
            }
        }

       [RelayCommand]
        public async void LoadByStudentID()
        {

            ShowStudent = await _dataService.GetStudent();

        }

        [RelayCommand]
        public async void GetClubsAndOrganizationsList()
        {
            ShowClubsAndOrganizations.Clear();
            var clubsAndOrganizationsList = await _dataService.GetClubsAndOrganizations();
            if (clubsAndOrganizationsList?.Count > 0)
            {
                clubsAndOrganizationsList = clubsAndOrganizationsList.OrderBy(f => f.ClubName).ToList();
                foreach (var clubsAndOrganizations in clubsAndOrganizationsList)
                {
                    ShowClubsAndOrganizations.Add(clubsAndOrganizations);
                }
              
            }
        }

        [RelayCommand]
        public async void GetCommunityServiceList()
        {
            ShowCommunityService.Clear();
            var communityServiceList = await _dataService.GetCommunityService();
            if (communityServiceList?.Count > 0)
            {
                communityServiceList = communityServiceList.OrderBy(f => f.ServiceName).ToList();
                foreach (var communityService in communityServiceList)
                {
                    ShowCommunityService.Add(communityService);
                }

            }
        }

        [RelayCommand]
        public async void GetAthleticParticipationList()
        {
            ShowAthleticParticipation.Clear();
            var athleticParticipationList = await _dataService.GetAthleticParticipation();
            if (athleticParticipationList?.Count > 0)
            {
                athleticParticipationList = athleticParticipationList.OrderBy(f => f.Sport).ToList();
                foreach (var athleticParticipation in athleticParticipationList)
                {
                    ShowAthleticParticipation.Add(athleticParticipation);
                }

            }
        }

        [RelayCommand]
        public async void GetWorkExperienceList()
        {
            ShowWorkExperience.Clear();
            var workExperienceList = await _dataService.GetWorkExperience();
            if (workExperienceList?.Count > 0)
            {
                workExperienceList = workExperienceList.OrderBy(f => f.Establishment).ToList();
                foreach (var workExperience in workExperienceList)
                {
                    ShowWorkExperience.Add(workExperience);
                }

            }
        }

        [RelayCommand]
        public async void GetClassesList()
        {
            ShowClasses.Clear();
            var classesList = await _dataService.GetClasses();
            if (classesList?.Count > 0)
            {
                classesList = classesList.OrderBy(f => f.Name).ToList();
                foreach (var classes in classesList)
                {
                    ShowClasses.Add(classes);
                }

            }
        }

        [RelayCommand]
        public async void GetPersonalEndeavorsList()
        {
            ShowPersonalEndeavors.Clear();
            var personalEndeavorsList = await _dataService.GetPersonalEndeavors();
            if (personalEndeavorsList?.Count > 0)
            {
                personalEndeavorsList = personalEndeavorsList.OrderBy(f => f.Title).ToList();
                foreach (var personalEndeavors in personalEndeavorsList)
                {
                    ShowPersonalEndeavors.Add(personalEndeavors);
                }

            }
        }

        [RelayCommand]
        public async void GetAdditionalInvolvementsList()
        {
            ShowAdditionalInvolvements.Clear();
            var additionalInvolvementsList = await _dataService.GetAdditionalInvolvements();
            if (additionalInvolvementsList?.Count > 0)
            {
                additionalInvolvementsList = additionalInvolvementsList.OrderBy(f => f.ActivityName).ToList();
                foreach (var additionalInvolvements in additionalInvolvementsList)
                {
                    ShowAdditionalInvolvements.Add(additionalInvolvements);
                }

            }
        }

        public async Task GenerateResumePdf(string filePath)
        {
            try
            {
                //Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                //LoadRecords();
                // Create a new PDF document
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    
                    var writer = new PdfWriter(stream);
                    var pdf = new PdfDocument(writer);
                    var document = new Document(pdf);

                    // Add title
                    document.Add(new Paragraph($"{ShowStudent.FullName}")
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                        .SetFontSize(20)
                        .SetBold()
                        .SetMarginBottom(0));

                    // Add personal details

                    //string email = $"{ShowStudent.Email}";
                    //PdfAction emailAction = PdfAction.CreateURI(email);
                    //Link emailLink = new Link($"{ShowStudent.Email}", emailAction);

                    //// Add the link to a paragraph
                    //Paragraph paragraph = new Paragraph($"{ShowStudent.Email}").Add(emailLink);

                    //// Add the paragraph to the document
                    //document.Add(paragraph.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    //    .SetFontSize(12)
                    //    .SetMarginBottom(0)); 

                    document.Add(new Paragraph($"Email: {ShowStudent.Email}")
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                        .SetFontSize(12)
                        .SetMarginBottom(0));
                    document.Add(new Paragraph($"Phone: {ShowStudent.PhoneNumber}")
                       .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                       .SetFontSize(12)
                       .SetMarginBottom(0));
                 
                    document.Add(new Paragraph("Objective")
                     .SetBold()
                     .SetUnderline()
                     .SetMarginTop(10)
                     .SetFontSize(18));
                    document.Add(new Paragraph($"{ShowStudent.AboutMe}")
                      .SetMarginTop(0)
                      .SetFontSize(9));

                    document.Add(new Paragraph("Experiences")
                     .SetBold()
                     .SetUnderline()
                     .SetMarginTop(5)
                     .SetFontSize(18));

                    document.Add(new Paragraph("Work Experience")
                      .SetBold()
                      .SetUnderline()
                      .SetMarginTop(-5)
                      .SetFontSize(13));

                    if (ShowWorkExperience.Count > 0)
                    {
                        foreach (var experience in ShowWorkExperience)
                        {
                            document.Add(new Paragraph(experience.Role).SetFontSize(12).SetBold().SetMarginBottom(-5));
                            document.Add(new Paragraph(experience.Establishment).SetFontSize(10).SetMarginBottom(-5));
                            document.Add(new Paragraph(experience.Description).SetFontSize(9).SetMarginBottom(5));



                        }
                    }

                    document.Add(new Paragraph("Clubs and Organizations")
                      .SetBold()
                      .SetUnderline()
                      .SetMarginTop(5)
                      .SetFontSize(13));

                    if (ShowClubsAndOrganizations.Count > 0)
                    {
                        foreach (var club in ShowClubsAndOrganizations)
                        {
                            document.Add(new Paragraph(club.ClubName).SetFontSize(12).SetBold().SetMarginBottom(-5));
                            document.Add(new Paragraph(club.Role).SetFontSize(12).SetMarginBottom(-5));
                            document.Add(new Paragraph(club.Description).SetFontSize(9).SetMarginBottom(-5));
                            document.Add(new Paragraph(club.Achivements).SetFontSize(9).SetMarginBottom(5));



                        }
                    }

                    document.Add(new Paragraph("Community Service")
                      .SetBold()
                      .SetUnderline()
                      .SetMarginTop(5)
                      .SetFontSize(13));

                    if (ShowCommunityService.Count > 0)
                    {
                        foreach (var service in ShowCommunityService)
                        {
                            document.Add(new Paragraph(service.ServiceName).SetFontSize(12).SetBold().SetMarginBottom(-5));
                            //document.Add(new Paragraph(service.VoulnteeredHours).SetFontSize(10).SetMarginBottom(5));
                            document.Add(new Paragraph(service.Description).SetFontSize(9).SetMarginBottom(5));

                        }


                    }

                    document.Add(new Paragraph("Personal Endeavors")
                     .SetBold()
                     .SetUnderline()
                     .SetMarginTop(5)
                     .SetFontSize(13));

                    if (ShowPersonalEndeavors.Count > 0)
                    {
                        foreach (var endeavors in ShowPersonalEndeavors)
                        {
                            document.Add(new Paragraph(endeavors.Title).SetFontSize(12).SetBold().SetMarginBottom(-5));
                            document.Add(new Paragraph(endeavors.Description).SetFontSize(9).SetMarginBottom(5));

                            //document.Add(new AreaBreak());

                        }
                    }

                    document.Add(new Paragraph("Academic Achievements")
                     .SetBold()
                     .SetUnderline()
                     .SetMarginTop(5)
                     .SetFontSize(13));
                    // List list = new List();
                    if (ShowAcademicAchievements.Count > 0)
                    {
                        foreach (var achievements in ShowAcademicAchievements)
                        {
                            document.Add(new Paragraph(achievements.Award).SetFontSize(12).SetBold().SetMarginBottom(-5));
                            document.Add(new Paragraph(achievements.Class).SetFontSize(10).SetMarginBottom(-5));
                            document.Add(new Paragraph(achievements.Description).SetFontSize(9).SetMarginBottom(5));
                            // list.Add(new ListItem(achievements.Award + "-" + achievements.Class + "-" + achievements.Description)); 


                        }
                        // document.Add(list);
                    }

                    document.Add(new Paragraph("Additional Involvements")
                     .SetBold()
                     .SetUnderline()
                     .SetMarginTop(5)
                     .SetFontSize(13));

                    if (ShowAdditionalInvolvements.Count > 0)
                    {
                        foreach (var involvements in ShowAdditionalInvolvements)
                        {
                            document.Add(new Paragraph(involvements.ActivityName).SetFontSize(12).SetBold().SetMarginBottom(-5));
                            document.Add(new Paragraph(involvements.Description).SetFontSize(9).SetMarginBottom(5));

                        }
                    }



                    //// Add academic achievements
                    //document.Add(new Paragraph("Academic Achievements")
                    //    .SetBold()
                    //    .SetFontSize(16));
                    //var academicTable = new Table(UnitValue.CreatePercentArray(new float[] { 4, 6 }));
                    //academicTable.SetWidth(UnitValue.CreatePercentValue(100));
                    //academicTable.AddHeaderCell("Award");
                    //academicTable.AddHeaderCell("Description");
                    //foreach (var achievement in ShowAcademicAchievements)
                    //{
                    //    academicTable.AddCell(new Paragraph(achievement.Award).SetFontSize(12));
                    //    academicTable.AddCell(new Paragraph(achievement.Description).SetFontSize(12));
                    //}
                    //document.Add(academicTable);

                    //// Add work experience
                    //document.Add(new Paragraph("Work Experience")
                    //    .SetBold()
                    //    .SetFontSize(16));
                    //var workTable = new Table(UnitValue.CreatePercentArray(new float[] { 4, 4, 4 }));
                    //workTable.SetWidth(UnitValue.CreatePercentValue(100));
                    //workTable.AddHeaderCell("Role");
                    //workTable.AddHeaderCell("Establishment");
                    //workTable.AddHeaderCell("Description");
                    //foreach (var experience in ShowWorkExperience)
                    //{
                    //    workTable.AddCell(new Paragraph(experience.Role).SetFontSize(12));
                    //    workTable.AddCell(new Paragraph(experience.Establishment).SetFontSize(12));
                    //    workTable.AddCell(new Paragraph(experience.Description).SetFontSize(12)); // Add Description in your model if not present
                    //}
                    //document.Add(workTable);

                    //// Add clubs and organizations
                    //document.Add(new Paragraph("Clubs and Organizations")
                    //    .SetBold()
                    //    .SetFontSize(16));
                    //var clubsTable = new Table(UnitValue.CreatePercentArray(new float[] { 4, 6 }));
                    //clubsTable.SetWidth(UnitValue.CreatePercentValue(100));
                    //clubsTable.AddHeaderCell("Club Name");
                    //clubsTable.AddHeaderCell("Role");
                    //foreach (var club in ShowClubsAndOrganizations)
                    //{
                    //    clubsTable.AddCell(new Paragraph(club.ClubName).SetFontSize(12));
                    //    clubsTable.AddCell(new Paragraph(club.Role).SetFontSize(12));
                    //}
                    //document.Add(clubsTable);

                    document.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or debug the exception message
                Console.WriteLine($"Exception during PDF generation: {ex.Message}");
                throw; // Rethrow the exception or handle as appropriate
            }

           
        }

        private async Task EmailResume(string filePath)
        {
            try
            {
                var message = new Xamarin.Essentials.EmailMessage
                {
                    Subject = "Resume",
                    Body = "Please find the attached resume.",
                    Attachments = { new Xamarin.Essentials.EmailAttachment(filePath) }
                };
                await Xamarin.Essentials.Email.ComposeAsync(message);
            }
            catch (Xamarin.Essentials.FeatureNotSupportedException ex)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }

        [RelayCommand]
        private async Task ExecuteGenerateResume()
        {
            // int UserID = Microsoft.Maui.Storage.Preferences.Get("UserID", 999);
            

            string fileName = "resume.pdf";
            string filePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, fileName);
           // var filename = "resume" + DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture) + ".pdf";
           // var filePath = Path.Combine(Xamarin.Essentials.FileSystem.CacheDirectory, filename);
            await GenerateResumePdf(filePath);

            await EmailResume(filePath);
            // Optionally, show a message or perform other actions after generating PDF
            // Example: await Application.Current.MainPage.DisplayAlert("Success", "Resume PDF generated.", "OK");
           
        }


    }
    }

