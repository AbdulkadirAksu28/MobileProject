using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Project_Mobile_Abdulkadir_Aksu.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://github.com/PXL-CMobile/project-def-2122-AbdulkadirAksu28"));
        }

        public ICommand OpenWebCommand { get; }
    }
}