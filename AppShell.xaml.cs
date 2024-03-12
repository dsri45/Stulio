﻿using Stulio.Views;

namespace Stulio
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("home", typeof(ProfilePage));
            Routing.RegisterRoute(nameof(AddUpdateStudentDetail), typeof(AddUpdateStudentDetail));
            Routing.RegisterRoute(nameof(AboutMe), typeof(AboutMe));
            Routing.RegisterRoute(nameof(AcademicAchievements), typeof(AcademicAchievements));
            Routing.RegisterRoute("settings", typeof(SettingsPage));

        }
    }
}
