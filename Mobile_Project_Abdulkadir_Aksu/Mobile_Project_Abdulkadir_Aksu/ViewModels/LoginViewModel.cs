using Mobile_Project_Abdulkadir_Aksu.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace Mobile_Project_Abdulkadir_Aksu.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string email;
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

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public Command LoginCommand { get; }
        public Command GoToRegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            GoToRegisterCommand = new Command(OnRegisterTapped);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one


            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call GetUser function which we define in Firebase helper class    
                var user = await FirebaseHelper.GetUser(Email);
                //firebase return null valuse if user data not found in database    
                if (user!=null)
                    if (Email == user.Email && Password == user.Password)
                    {

                        //Navigate to Wellcom page after successfuly login    
                        //pass user email to welcom page    
                        await Shell.Current.GoToAsync($"//{nameof(MapsPage)}");
                        App.IsUserLoggedIn = true;
                        Preferences.Set("isLoggedIn", true);
                        Preferences.Set("UserMail", user.Email);
                        Preferences.Set("UserPass", user.Password);

                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
            }
        }
        private async void OnRegisterTapped(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegistrationPage)}");
        }

    }
}
