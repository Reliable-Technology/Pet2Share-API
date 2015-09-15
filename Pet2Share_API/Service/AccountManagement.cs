using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pet2Share_API.Domain;

namespace Pet2Share_API.Service
{
    public class AccountManagement
    {


        public static User Login(string username, string password)
        {
            bool isAuthenticated = false;

            User user = new User();

            user.Username = "Guest User";
            user.IsAuthenticated = false;

            return user;
        }

        public static User RegisterNewUser(string username, string password, string firstName, string lastName, DateTime? dob, string email, string alternateEmail, string phone, string alternatePhone, string addressLine1, string addressLine2, string city, string state, string country, string zipCode, int? socialMediaSourceId, string socialMediaId, int? userType)
        {
            //Create Address object

            //Create Person object

            //Create User Object

            //Save object
            return null;
        }

        public static User RegisterNewUser(string username, string password, string firstName, string lastName, string email)
        {
            return null;
        }

        public static User RegisterNewUser(User u)
        {
            return null;
        }
    }
}
