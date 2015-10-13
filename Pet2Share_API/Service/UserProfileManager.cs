using System;
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
            fullFileName = user.Id.ToString() + "_" + filename + imageType.ToString();

            savePath = ImageProcessor.Upload(binaryImage, imageType, fullFileName, relativePath);

            this.user.P.AvatarURL = relativePath;
            this.user.P.Save();

            BoolExt result = new BoolExt(true, savePath);

            return result;
        }

        public static BoolExt UpdateProfilePicture(Byte[] binaryImage, string filename, ImageType imageType, int userId)
        {
            string savePath = "";
            string relativePath = "";
            string fullFileName = "";

            relativePath = "/" + userId;
            fullFileName = userId.ToString() + "_" + filename + imageType.ToString();

            savePath = ImageProcessor.Upload(binaryImage, imageType, fullFileName, relativePath);

            User u = new User(userId);

            u.P.AvatarURL = relativePath;
            u.P.Save();

            BoolExt result = new BoolExt(true, savePath);

            return result;
        }

        public BoolExt UpdateCoverPicture(Byte[] binaryImage, string filename, ImageType imageType)
        {
            string savePath = "";
            string relativePath = "";
            string fullFileName = "";

            relativePath = "/" + this.user.Id;
            fullFileName = user.Id.ToString() + "_" + filename + imageType.ToString();

            //savePath = ImageProcessor.Upload(binaryImage, imageType, fullFileName, relativePath);

            //this.user.P.AvatarURL = relativePath;
            //this.user.P.Save();

            BoolExt result = new BoolExt(true, savePath);

            return result;
        }

        public static BoolExt UpdateCoverPicture(Byte[] binaryImage, string filename, ImageType imageType, int userId)
        {
            string savePath = "";
            string relativePath = "";
            string fullFileName = "";

            relativePath = "/" + userId;
            fullFileName = userId.ToString() + "_" + filename + imageType.ToString();

            //savePath = ImageProcessor.Upload(binaryImage, imageType, fullFileName, relativePath);

            //this.user.P.AvatarURL = relativePath;
            //this.user.P.Save();

            BoolExt result = new BoolExt(true, savePath);

            return result;
        }
    }
}
