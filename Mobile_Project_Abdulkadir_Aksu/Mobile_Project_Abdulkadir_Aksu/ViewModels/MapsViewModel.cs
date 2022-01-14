using Project_Mobile_Abdulkadir_Aksu.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Project_Mobile_Abdulkadir_Aksu.ViewModels
{
    public class MapsViewModel : BaseViewModel
    {
        public Command LogoutCommand { get; }

        public MapsViewModel()
        {
            LogoutCommand = new Command(LogoutClicked);
        }
        private async void LogoutClicked(object obj)
        {
            App.IsUserLoggedIn = false;
            Preferences.Set("isLoggedIn", false);
            Preferences.Set("UserMail", string.Empty);
            Preferences.Set("UserPass", string.Empty);
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

        }

    }
}
