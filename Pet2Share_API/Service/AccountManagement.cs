﻿using System;
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
                System.Data.Entity.Core.Objects.ObjectResult<int?> uid = context.UserLogin(username, password);
                userId = uid.FirstOrDefault();
            }

            id = userId == null || userId == 0 ? -1 : userId.Value;
            isAuthenticated = userId == null || userId == 0 ? false : true;

            User user = new User(id);
            user.IsAuthenticated = isAuthenticated;

            return user;
        }

        public static User RegisterNewUser(string username, string password, string firstName, string lastName, DateTime? dob, string email, string alternateEmail
            , string phone, string alternatePhone, string addressLine1, string addressLine2, string city, string state, string country, string zipCode, int? socialMediaSourceId,
            string socialMediaId, int? userType)
        {
            //Validations
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                throw new Exception("username or password can not be blank");
            }

            //TODO: Check all params for rogue data

            UserType uType = new UserType(userType != null ? userType.Value : 0);

            Address addr = new Address(addressLine1, addressLine2, city, state, country, zipCode);

            Person pers = new Person(firstName, lastName, email, alternateEmail, dob, addr, phone, alternatePhone, null, null);

            //TODO: Create User Object

            User u = new User(username, password, pers, email, alternateEmail, socialMediaSourceId != null ? socialMediaSourceId.Value : 1, socialMediaId, uType);

            //TODO: Also add a virtual pet simultaneously
            

            return RegisterNewUser(u);
        }

        public static User RegisterNewUser(string username, string password, string firstName, string lastName, string email, DateTime? dob)
        {
            //Call to the most basic method
            return RegisterNewUser(username, password, firstName, lastName, dob, email, null, null, null, null, null, null, null, null, null, null, null, null);
        }

        public static User RegisterNewUser(User u)
        {
            int result = u.Save();
            if (result > 0)
            {
                u.Id = result;
                u.IsAuthenticated = true;
            }
            else
                return null;
            return u;
        }

        public static bool IsExistingUser(string username)
        {
            int count = 0;
            using (Pet2Share_API.DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                count = context.Users.Where(u => u.Username == username).Count();
            }

            if (count > 0)
                return true;
            else
                return false;
        }
    }
}
