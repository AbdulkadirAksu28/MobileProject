using Firebase.Database;
using Firebase.Database.Query;
using Mobile_Project_Abdulkadir_Aksu.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Project_Abdulkadir_Aksu.ViewModels
{
    public class FirebaseHelper
    {
        public static FirebaseClient firebase = new FirebaseClient("https://mobileabdulkadirdatabase-default-rtdb.europe-west1.firebasedatabase.app/");
        //IFirebaseConfig static firebase = new FirebaseConfig()
        //{
        //    AuthSecret = "ldox1iQw3RECPejQh4Avgq2aMX27bjF6l4itNaoY",
        //    BasePath = "https://mobileabdulkadirdatabase-default-rtdb.europe-west1.firebasedatabase.app/"
        //};

        //Read All    
        public static async Task<List<Users>> GetAllUser()
        {
            try
            {
                var userlist = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Select(item =>
                new Users
                {
                    Email = item.Object.Email,
                    Password = item.Object.Password
                }).ToList();
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Read     
        public static async Task<Users> GetUser(string email)
        {
            try
            {
                var allUsers = await GetAllUser();
                await firebase
                .Child("Users")
                .OnceAsync<Users>();
                return allUsers.Where(a => a.Email == email).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Insert a user    
        public static async Task<bool> AddUser(string email, string password)
        {
            try
            {


                await firebase
                .Child("Users")
                .PostAsync(new Users() { Email = email, Password = password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Update     
        public static async Task<bool> UpdateUser(string email, string password)
        {
            try
            {


                var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(new Users() { Email = email, Password = password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Delete User    
        public static async Task<bool> DeleteUser(string email)
        {
            try
            {


                var toDeletePerson = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase.Child("Users").Child(toDeletePerson.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

    }
}

