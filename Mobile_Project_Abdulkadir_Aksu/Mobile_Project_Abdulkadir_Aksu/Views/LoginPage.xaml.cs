using Mobile_Project_Abdulkadir_Aksu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_Project_Abdulkadir_Aksu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        //private async void OnRegisterTapped(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync($"//{nameof(RegistrationPage)}");
        //}
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (Preferences.Get("isLoggedIn", false)  )
            {
                await Shell.Current.GoToAsync($"//{nameof(MapsPage)}");
            }
        }
    }
}