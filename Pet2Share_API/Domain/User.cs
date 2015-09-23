using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    public class UserType
    {
        
    }

    public class User
    {
        #region members
        public int Id { get; set; }
        public string Username { get; set; }
        public bool IsAuthenticated { get; set; }
        public Person P;
        public string Email { get; set; }
        public string AlternameEmail { get; set; }
        public int SocialMediaSourceId { get; set; }
        public string SocialMediaId { get; set; }
        public UserType UType;
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsActive { get; set; }
        #endregion

        #region constructors

        public User()
        {

        }

        public User(int id)
        {

        }

        public User(string username, Person p, string email, string alternateEmail, int socialMediaSourceId, string socialMediaId, UserType uType)
        {

        }

        #endregion

        #region methods

        
        public int Save()
        {
            return -1;
        }

        public static int Save(User u)
        {
            return -1;
        }

        public bool Delete()
        {
            return false;
        }

        public bool DeleteById(int id)
        {
            return false;
        }

        #endregion
    }
}
