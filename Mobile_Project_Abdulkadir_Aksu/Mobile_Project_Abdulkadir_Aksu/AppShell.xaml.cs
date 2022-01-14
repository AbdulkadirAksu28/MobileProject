using Project_Mobile_Abdulkadir_Aksu.ViewModels;
using Project_Mobile_Abdulkadir_Aksu.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Project_Mobile_Abdulkadir_Aksu
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        //private async void OnMenuItemClicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("//LoginPage");
        //}
    }
}
