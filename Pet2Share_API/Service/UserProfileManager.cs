using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pet2Share_API.Domain;

namespace Pet2Share_API.Service
{
    public class UserProfileManager
    {
        public User user { get; set; }

        public UserProfileManager()
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

        public bool UpdateAvatar(string avatarURL)
        {
            return false;
        }

        public bool ActivateProfile()
        {
            return false;
        }

        public bool DeactivateProfile(string reason)
        {
            return false;
        }

        public bool AddProfile()
        {
            return false;
        }

        public static bool AddProfile(User u)
        {
            return false;
        }

        public bool AddProfile(int userId, string firstname, string lastname, string email, string alternateEmail, DateTime dob, string primaryPhone, string secondaryPhone, string avatarURL, string aboutMe
            , string addressLine1, string addressLine2, string city, string state, string country, string zipCode)
        {
            return false;
        }

        public bool UpdateProfile()
        {
            return false;
        }

        public static bool UpdateProfile(User u)
        {
            return false;
        }

        public bool UpdateProfile(int userId, string firstname, string lastname, string email, string alternateEmail, DateTime dob, string primaryPhone, string secondaryPhone, string avatarURL, string aboutMe
            , string addressLine1, string addressLine2, string city, string state, string country, string zipCode)
        {
            return false;
        }
    }
}
