using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    [DataContract]
    public class UserType : DomainBase
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }

        #region constructors

        public UserType()
        {
            this.Id = 0;
            this.Name = "Default User Type";
        }

        public UserType(int id)
        {
            //TODO: Implement the method
        }

        #endregion
    }

    [DataContract]
    public class User : DomainBase
    {
        #region members
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public bool IsAuthenticated { get; set; }
        [DataMember]
        public Person P;
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int SocialMediaSourceId { get; set; }
        [DataMember]
        public string SocialMediaId { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public UserType UType;
        [DataMember]
        public Pet[] Pets { get; set; }
        
        #endregion

        #region constructors

        public User()
        {
            this.Id = -1;
            this.IsAuthenticated = false;
            this.Username = "Guest";
            this.P = new Person();
            this.UType = new UserType();
            Pets = new Pet[] { };
        }

        public User(int id) : base()
        {
            User u = User.GetById(id);
            this.Id = u.Id;
            this.Username = u.Username;
            this.P = u.P;
            this.Email = u.Email;
            this.SocialMediaSourceId = u.SocialMediaSourceId;
            this.SocialMediaId = u.SocialMediaId;
            this.Phone = u.Phone;
            this.Pets = u.Pets;
            this.DateAdded = u.DateAdded;
            this.DateModified = u.DateModified;
            this.IsActive = u.IsActive;

            this.IsAuthenticated = this.Id > 0 ? true : false;
        }

        public User(User u) : base()
        {
            this.Id = u.Id;
            this.Username = u.Username;
            this.P = u.P;
            this.Email = u.Email;
            this.SocialMediaSourceId = u.SocialMediaSourceId;
            this.SocialMediaId = u.SocialMediaId;
            this.Phone = u.Phone;
            this.Pets = u.Pets;
            this.DateAdded = u.DateAdded;
            this.DateModified = u.DateModified;
            this.IsActive = u.IsActive;

            this.IsAuthenticated = this.Id > 0 ? true : false;
        }

        public User(DAL.User u) : base()
        {
            this.Id = u.Id;
            this.Username = u.Username;
            this.P = new Person(u.PrimaryPersonId);
            this.Email = u.Email;
            this.SocialMediaSourceId = Convert.ToInt32(u.SocialMediaSourceId);
            this.SocialMediaId = u.SocialMediaUsername;
            this.Phone = u.Phone;
            this.DateAdded = u.DateAdded;
            this.DateModified = u.DateModified;
            this.IsActive = u.IsActive;

            this.Pets = GetPetList();

            this.IsAuthenticated = this.Id > 0 ? true : false;
        }

        public User(string username, string password, Person p, string email, string alternateEmail, int socialMediaSourceId, string socialMediaId, UserType uType) : base()
        {
            this.Id = 0;
            this.Username = username;
            this.Password = password;
            this.P = p;
            this.Email = email;
            this.SocialMediaSourceId = socialMediaSourceId;
            this.SocialMediaId = socialMediaId;
        }

        #endregion

        #region methods

        public static User GetById(int id)
        {
            DAL.User userObj;
            List<Pet> petsList = new List<Pet>();

            using(DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                userObj = context.Users.Where(p => p.Id == id).FirstOrDefault();

                //Section to fetch pets under the user
                DAL.PetProfile[] petProfiles = context.PetProfiles.Where(p => p.UserId == id).ToArray<DAL.PetProfile>();
                foreach (DAL.PetProfile petProfile in petProfiles)
                {
                    Pet pet = new Pet(petProfile);
                    petsList.Add(pet);
                }
            }
            if (userObj != null)
            {
                User u = new User(userObj);
                u.Pets = petsList.ToArray();
                return u;
            }
            return new User();
        }

        public static bool Validate(User user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Email))
                return false;
            else
                return true;
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(this.Username) || string.IsNullOrEmpty(this.Email))
                return false;
            else
                return true;
        }

        public int Save()
        {
            //Check if all the objects in User's object is saved
            int result = -1;

            if (Validate())
            {
                this.P.Id = this.P.Save();

                using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
                {
                    result = Convert.ToInt32(context.InsertUpdateUser(this.Id, this.Username, this.Password, this.P.Id, this.Email, this.Phone, this.SocialMediaSourceId, this.SocialMediaId).FirstOrDefault());
                    if (result > 0)
                        this.Id = result;
                }
            }
            return result;
        }

        public static int Save(User u)
        {
            int result = -1;
            if (Validate(u))
            {
                u.P.Id = u.P.Save();

                using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
                {
                    result = Convert.ToInt32(context.InsertUpdateUser(u.Id, u.Username, u.Password, u.P.Id, u.Email, u.Phone, u.SocialMediaSourceId, u.SocialMediaId).FirstOrDefault());
                    if (result > 0)
                        u.Id = result;
                }
            }
            return result;
        }

        public bool Delete()
        {
            int result = -1;
            if (this.Id <= 0) return false;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.DeleteUserById(this.Id);
                if (result > 0)
                    this.Id = result;
            }
            return result > 0 ? true : false ;
        }

        public static bool DeleteById(int id)
        {
            int result = -1;
            if (id <= 0) return false;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.DeleteUserById(id);
                if (result > 0)
                    id = result;
            }
            return result > 0 ? true : false;
        }

        public Pet[] GetPetList(bool? isActive = null)
        {
            List<Pet> petsList = new List<Pet>();
            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                DAL.PetProfile[] petProfiles = context.PetProfiles.Where(p => p.UserId == this.Id).ToArray<DAL.PetProfile>();

                foreach (DAL.PetProfile petProfile in petProfiles)
                {
                    Pet pet = new Pet(petProfile);
                    petsList.Add(pet);
                }
            }
            return petsList.ToArray();
        }

        #endregion
    }
}
