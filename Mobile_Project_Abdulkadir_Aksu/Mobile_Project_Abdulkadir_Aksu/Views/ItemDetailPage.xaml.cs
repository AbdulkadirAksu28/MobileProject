using Mobile_Project_Abdulkadir_Aksu.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Mobile_Project_Abdulkadir_Aksu.Views
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