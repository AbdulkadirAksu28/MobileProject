using Mobile_Project_Abdulkadir_Aksu.Services;
using Xamarin.Essentials;
using Mobile_Project_Abdulkadir_Aksu.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_Project_Abdulkadir_Aksu
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; internal set; }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
