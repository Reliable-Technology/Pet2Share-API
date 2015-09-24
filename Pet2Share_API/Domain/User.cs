using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    [Serializable]
    public class UserType
    {
        int id;
        string name;

        #region constructors

        public UserType(int id)
        {
            //TODO: Implement the method
        }

        #endregion
    }

    [Serializable]
    public class User
    {
        #region members
        public int Id { get; set; }
        public string Username { get; set; }
        private string _password;
        public bool IsAuthenticated { get; set; }
        public Person P;
        public string Email { get; set; }
        public string AlternameEmail { get; set; }
        public int SocialMediaSourceId { get; set; }
        public string Phone { get; set; }
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

        public User(string username, string password, Person p, string email, string alternateEmail, int socialMediaSourceId, string socialMediaId, UserType uType)
        {

        }

        #endregion

        #region methods

        
        public int Save()
        {
            //Check if all the objects in User's object is saved
            int result = -1;
            this.P.Id = this.P.Save();
            //TODO: Save User
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.InsertUpdateUser(0, this.Username, this._password, this.P.Id, this.Email, this.Phone, this.AlternameEmail, this.SocialMediaSourceId, this.SocialMediaId);
                if (result > 0)
                    this.Id = result;
            }
            return result;
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
