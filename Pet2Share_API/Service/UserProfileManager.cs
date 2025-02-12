﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pet2Share_API.Domain;
using Pet2Share_API.Utility;
using System.IO;

namespace Pet2Share_API.Service
{
    public class UserProfileManager
    {
        public User user { get; set; }
        public static int UserId { get; set; }

        private UserProfileManager()
        {

        }

        public UserProfileManager(int userId)
        {
            this.user = new User(userId);
        }

        public UserProfileManager(User u)
        {
            this.user = u;
        }

        public BoolExt UpdateAvatar(string avatarURL)
        {
            return new BoolExt(false);
        }

        public BoolExt ActivateProfile()
        {
            return new BoolExt(false);
        }

        public BoolExt DeactivateProfile(string reason)
        {
            return new BoolExt(false);
        }

        public BoolExt AddProfile()
        {
            return new BoolExt(false);
        }

        public static BoolExt AddProfile(User u)
        {
            return new BoolExt(false);
        }

        public BoolExt AddProfile(string firstname, string lastname, string email, string alternateEmail, DateTime? dob, string primaryPhone, string secondaryPhone, string avatarURL, string aboutMe
            , string addressLine1, string addressLine2, string city, string state, string country, string zipCode)
        {
            return new BoolExt(false);
        }

        public BoolExt UpdateProfile()
        {
            return new BoolExt(false);
        }

        public static BoolExt UpdateProfile(User u)
        {
            return new BoolExt(false);
        }

        public static BoolExt UpdateProfile(int userId, string firstname, string lastname, string email, string alternateEmail, DateTime? dob, string primaryPhone, string secondaryPhone, string avatarURL, string aboutMe
            , string addressLine1, string addressLine2, string city, string state, string country, string zipCode)
        {
            User u = new User(userId);

            u.Email = string.IsNullOrEmpty(email) ? u.Email : email;
            u.Phone = string.IsNullOrEmpty(primaryPhone) ? u.Phone : primaryPhone;
            
            u.P.FirstName = string.IsNullOrEmpty(firstname) ? u.P.FirstName : firstname;
            u.P.LastName = string.IsNullOrEmpty(lastname) ? u.P.LastName : lastname;
            u.P.Email = string.IsNullOrEmpty(email) ? u.P.Email : email;
            u.P.AlternateEmail = string.IsNullOrEmpty(alternateEmail) ? u.P.AlternateEmail : alternateEmail;
            u.P.DOB = dob == null ? u.P.DOB : dob;
            u.P.PrimaryPhone = string.IsNullOrEmpty(primaryPhone) ? u.P.PrimaryPhone : primaryPhone;
            u.P.SecondaryPhone = string.IsNullOrEmpty(secondaryPhone) ? u.P.SecondaryPhone : secondaryPhone;
            u.P.AvatarURL = string.IsNullOrEmpty(avatarURL) ? u.P.AvatarURL : avatarURL;
            u.P.AboutMe = string.IsNullOrEmpty(aboutMe) ? u.P.AboutMe : aboutMe;

            u.P.Addr.AddressLine1 = string.IsNullOrEmpty(addressLine1) ? u.P.Addr.AddressLine1 : addressLine1;
            u.P.Addr.AddressLine2 = string.IsNullOrEmpty(addressLine2) ? u.P.Addr.AddressLine2 : addressLine2;
            u.P.Addr.City = string.IsNullOrEmpty(city) ? u.P.Addr.City : city;
            u.P.Addr.State = string.IsNullOrEmpty(state) ? u.P.Addr.State : state;
            u.P.Addr.Country = string.IsNullOrEmpty(country) ? u.P.Addr.Country : country;
            u.P.Addr.ZipCode = string.IsNullOrEmpty(zipCode) ? u.P.Addr.ZipCode : zipCode;

            int result = u.Save();
            if (result == userId)
                return new BoolExt(true, "");
            else
                return new BoolExt(false, "Update Failed, Please check application logs for more details");

        }

        public BoolExt UpdateProfilePicture(Byte[] binaryImage, string filename, ImageType imageType)
        {
            string savePath = "";
            string relativePath = "";
            string fullFileName = "";

            relativePath = "/" + this.user.Id;
            fullFileName = user.Id.ToString() + "_" + filename;// +"." + imageType.ToString();

            savePath = ImageProcessor.Upload(binaryImage, imageType, fullFileName, relativePath);

            this.user.P.AvatarURL = relativePath + "/" + fullFileName;
            this.user.P.Save();

            BoolExt result = new BoolExt(true, ConfigMember.ImageURL + user.P.AvatarURL);

            return result;
        }

        public static BoolExt UpdateProfilePicture(Byte[] binaryImage, string filename, ImageType imageType, int userId)
        {
            string savePath = "";
            string relativePath = "";
            string fullFileName = "";

            relativePath = "/" + userId;
            fullFileName = userId.ToString() + "_" + filename;// +"." + imageType.ToString();

            savePath = ImageProcessor.Upload(binaryImage, imageType, fullFileName, relativePath);

            User user = new User(userId);

            user.P.AvatarURL = relativePath + "/" + fullFileName;
            user.P.Save();

            BoolExt result = new BoolExt(true, ConfigMember.ImageURL + user.P.AvatarURL); 

            return result;
        }

        public BoolExt UpdateCoverPicture(Byte[] binaryImage, string filename, ImageType imageType)
        {
            string savePath = "";
            string relativePath = "";
            string fullFileName = "";

            relativePath = "/" + this.user.Id;
            fullFileName = user.Id.ToString() + "_cover_" + filename;// +"." + imageType.ToString();

            savePath = ImageProcessor.Upload(binaryImage, imageType, fullFileName, relativePath);

            this.user.P.CoverPicture = relativePath + "/" + fullFileName;
            this.user.P.Save();

            BoolExt result = new BoolExt(true, ConfigMember.ImageURL + user.P.AvatarURL);

            return result;
        }

        public static BoolExt UpdateCoverPicture(Byte[] binaryImage, string filename, ImageType imageType, int userId)
        {
            string savePath = "";
            string relativePath = "";
            string fullFileName = "";

            User user = new User(userId);

            relativePath = "/" + userId;
            fullFileName = userId.ToString() + "_cover_" + filename;// +"." + imageType.ToString();

            savePath = ImageProcessor.Upload(binaryImage, imageType, fullFileName, relativePath);

            user.P.CoverPicture = relativePath + "/" + fullFileName;
            user.P.Save();

            BoolExt result = new BoolExt(true, ConfigMember.ImageURL + user.P.AvatarURL);

            return result;
        }

        public static SmallUser GetSmallUser(int userId)
        {
            SmallUser sUser = new SmallUser(userId);
            return sUser;
        }


        /// <summary>
        /// This method is used if you are logged into one account and check the profile of other user
        /// </summary>
        /// <param name="myUserId">Logged in user Id</param>
        /// <param name="otherUserId">User Id the of profile the is accessed by the user</param>
        /// <param name="connType">This outputs the type of connection between the two users</param>
        /// <returns>Returns the profile of queried user</returns>
        public static User GetOtherUserProfile(int myUserId, int otherUserId, out ConnectionType connType)
        {
            connType = ConnectionType.Connected;
            User user = new User(otherUserId);

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                int? result = context.ConnectionStatus(myUserId, otherUserId, false).FirstOrDefault();
                if (result != null)
                    connType = (ConnectionType)result.Value;
            }

            return user;
        }
    }

    public enum ConnectionType 
    {
        NotConnected,
        Connected,
        ConnectionPendingFromMe,
        ConnectionPendingFromFriend
    }
}
