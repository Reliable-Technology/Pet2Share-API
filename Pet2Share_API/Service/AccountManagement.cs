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
            int? userId = null;
            int id;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                System.Data.Objects.ObjectResult<int?> uid = context.UserLogin(username, password);
                userId = uid.FirstOrDefault();
            }

            id = userId == null || userId == 0 ? -1 : userId.Value;
            isAuthenticated = userId == null || userId == 0 ? false : true;

            User user = new User(id);
            user.IsAuthenticated = isAuthenticated;

            return user;
        }

        public static User RegisterNewUser(string username, string password, string firstName, string lastName, DateTime? dob, string email, string alternateEmail
            , string phone, string alternatePhone, string addressLine1, string addressLine2, string city, string state, string country, string zipCode, int? socialMediaSourceId, string socialMediaId, int? userType)
        {
            //Validations
            if (username == null || password == null || email == null)
            {
                throw new Exception("Register cant have empty fields for username and password");
            }
            //Create Address object

            //Create Person object

            //Create User Object

            //Save object
            return null;
        }

        public static User RegisterNewUser(string username, string password, string firstName, string lastName, string email)
        {
            //Call to the most basic method
            return null;
        }

        public static User RegisterNewUser(User u)
        {
            return null;
        }
    }
}
