using Project_Mobile_Abdulkadir_Aksu.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Project_Mobile_Abdulkadir_Aksu.ViewModels
{
    internal class SettingsViewModel : INotifyPropertyChanged
    {

        private string email = Preferences.Get("UserMail", string.Empty);

        public event PropertyChangedEventHandler PropertyChanged;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        //private string mail = Preferences.Get("UserMail", string.Empty);
        //private string pass = Preferences.Get("UserMail", string.Empty);

        
        public Command UpdateCommand

        {
            get { return new Command(Update); }
        }
        private async void Update()
        {
            try
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    var isupdate = await FirebaseHelper.UpdateUser(Email, Password);
                    if (isupdate)
                        await App.Current.MainPage.DisplayAlert("Update Success", "", "Ok");
                    else
                        await App.Current.MainPage.DisplayAlert("Error", "Record not update", "Ok");
                }
                else
                    await App.Current.MainPage.DisplayAlert("Password Require", "Please Enter your password", "Ok");
            }
            catch (Exception e)
            {

                Debug.WriteLine($"Error:{e}");
            }
        }
        public Command DeleteCommand

        {
            get { return new Command(Delete); }
        }
        private async void Delete()
        {
            try
            {
                var isdelete = await FirebaseHelper.DeleteUser(Email);
                if (isdelete)
                {
                    await App.Current.MainPage.DisplayAlert("Important", "Account has been deleted", "Ok");
                    Preferences.Set("isLoggedIn", false);
                    Preferences.Set("UserMail", string.Empty);
                    Preferences.Set("UserPass", string.Empty);
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

                }                
                else
                    await App.Current.MainPage.DisplayAlert("Error", "Record not delete", "Ok");
            }
            catch (Exception e)
            {

                Debug.WriteLine($"Error:{e}");
            }
        }
        public Command LogoutCommand

        {
            get { return new Command(Logout); }
        }

        private async void Logout()
        {
            App.IsUserLoggedIn = false;
            Preferences.Set("isLoggedIn", false);
            Preferences.Set("UserMail", string.Empty);
            Preferences.Set("UserPass", string.Empty);
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

        }
    }
}
