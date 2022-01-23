using Mobile_Project_Abdulkadir_Aksu.Models;
using Mobile_Project_Abdulkadir_Aksu.Services;
using Mobile_Project_Abdulkadir_Aksu.ViewModels;
using Mobile_Project_Abdulkadir_Aksu.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_Project_Abdulkadir_Aksu.Views
{
    public partial class ItemsPage : ContentPage
    {
        public ObservableCollection<Item> Animals;
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ItemsViewModel();
            Animals = new ObservableCollection<Item>();
            

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ExecuteLoadAnimals();
            ItemsListView.ItemsSource = Animals;
            _viewModel.OnAppearing();
        }
        public async void ExecuteLoadAnimals()
        {
            try
            {
                Animals.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Animals.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ExecuteLoadAnimals();
            var searchTerm = e.NewTextValue;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = string.Empty;
            }
            searchTerm = searchTerm.ToLowerInvariant();
            var filteredItems = Animals.Where(item => item.Text.ToLowerInvariant().Contains(searchTerm)).ToList();
            foreach (var value in Animals.ToList())
            {
                if (!filteredItems.Contains(value))
                {
                    Animals.Remove(value);
                    
                }
                else if (!Animals.Contains(value))
                {
                    Animals.Add(value);
                    
                }
            }
            ItemsListView.ItemsSource = Animals;
        }
    }
}