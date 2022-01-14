using Project_Mobile_Abdulkadir_Aksu.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Project_Mobile_Abdulkadir_Aksu.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}