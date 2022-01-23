using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile_Project_Abdulkadir_Aksu.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_Project_Abdulkadir_Aksu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {

        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel();
            string email = Preferences.Get("UserMail", string.Empty);
            LblEmail.Text = $"Welcome {email}";

        }
    }
}