using Project_Mobile_Abdulkadir_Aksu.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_Mobile_Abdulkadir_Aksu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyCVpvEpEmp9675RdtC5OxEGUNR3NUvKMY8";
        public RegistrationPage()
        {
            InitializeComponent();
            this.BindingContext = new RegistrationViewModel();
        }

        private async void GoToLogin(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        private async void OnRegistrationClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            try
            {
                //var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                //var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserName.Text, UserPass.Text);
                //string gettoken = auth.FirebaseToken;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}