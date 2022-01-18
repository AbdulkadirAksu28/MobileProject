using Mobile_Project_Abdulkadir_Aksu.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Mobile_Project_Abdulkadir_Aksu.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        private string email;

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
        private string confirmpassword;
        public string ConfirmPassword
        {
            get { return confirmpassword; }
            set
            {
                confirmpassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }

        public Command RegisterCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Password == ConfirmPassword)
                        OnRegistrationClicked();
                    else
                        App.Current.MainPage.DisplayAlert("", "Password must be same as above!", "OK");
                });
            }
        }

        private async void OnRegistrationClicked()
        {

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call AddUser function which we define in Firebase helper class    
                var user = await FirebaseHelper.AddUser(Email, Password);
                //AddUser return true if data insert successfuly     
                if (user)
                {
                    //Navigate to Wellcom page after successfuly SignUp    
                    //pass user email to welcom page    
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "SignUp Fail", "OK");

            }

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
      

        }
    }
}
