using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pet2Share_API.Domain;
using Pet2Share_API.Utility;

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

        public BoolExt AddProfile(string firstname, string lastname, string email, string alternateEmail, DateTime dob, string primaryPhone, string secondaryPhone, string avatarURL, string aboutMe
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

        public BoolExt UpdateProfile(int userId, string firstname, string lastname, string email, string alternateEmail, DateTime dob, string primaryPhone, string secondaryPhone, string avatarURL, string aboutMe
            , string addressLine1, string addressLine2, string city, string state, string country, string zipCode)
        {
            return new BoolExt(false);
        }
    }
}
