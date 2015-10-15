using Pet2Share_API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    [DataContract]
    public class Person : DomainBase
    {
        #region members
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string AlternateEmail { get; set; }
        [DataMember]
        public DateTime? DOB { get; set; }
        [DataMember]
        public Address Addr { get; set; }
        [DataMember]
        public string PrimaryPhone { get; set; }
        [DataMember]
        public string SecondaryPhone { get; set; }
        [DataMember]
        public string AvatarURL { get; set; }
        [DataMember]
        public string ProfilePictureURL { get { if (string.IsNullOrEmpty(AvatarURL)) return ""; else if (AvatarURL.Contains("http")) return AvatarURL; else return ConfigMember.ImageURL + AvatarURL; } set { } }
        [DataMember]
        public string CoverPicture { get; set; }
        [DataMember]
        public string CoverPictureURL { get { if (string.IsNullOrEmpty(CoverPicture)) return ""; else if (CoverPicture.Contains("http")) return CoverPicture; else return ConfigMember.ImageURL + CoverPicture; } set { } }
        [DataMember]
        public string AboutMe { get; set; }

        #endregion

        #region constructors

        public Person()
        {
            this.Id = -1;
            this.FirstName = "Guest";
            Addr = new Address();
        }

        public Person(int personId) : base()
        {
            Person p = Person.GetById(personId);
            this.Id = p.Id;
            this.FirstName = p.FirstName;
            this.LastName = p.LastName;
            this.Email = p.Email;
            this.DOB = p.DOB;
            this.Addr = p.Addr;
            this.PrimaryPhone = p.PrimaryPhone;
            this.SecondaryPhone = p.SecondaryPhone;
            this.AvatarURL = p.AvatarURL;
            this.CoverPicture = p.CoverPicture;
            this.AboutMe = p.AboutMe;
            this.DateAdded = p.DateAdded;
            this.DateModified = p.DateModified;
            this.IsActive = p.IsActive;
        }

        public Person(string firstName, string lastName, string email, string alternateEmail, DateTime? dob, Address addr, string primaryPhone, string secondaryPhone, string avatarURL, string coverPicture) : base()
        {
            this.Id = 0;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.DOB = dob;
            this.Addr = addr;
            this.PrimaryPhone = primaryPhone;
            this.SecondaryPhone = secondaryPhone;
            this.AvatarURL = avatarURL;
            this.CoverPicture = coverPicture;
        }

        public Person(DAL.Person p) : base()
        {
            this.Id = p.Id;
            this.FirstName = p.FirstName;
            this.LastName = p.LastName;
            this.Email = p.Email;
            this.DOB = p.DOB;
            this.Addr = new Address(p.AddressId.HasValue ? p.AddressId.Value : -1);
            this.PrimaryPhone = p.PrimaryPhone;
            this.SecondaryPhone = p.SecondaryPhone;
            this.AvatarURL = p.Avatar;
            this.CoverPicture = p.CoverPicture;
            this.AboutMe = p.AboutMe;
            this.DateAdded = p.DateAdded;
            this.DateModified = p.DateModified;
            this.IsActive = p.IsActive;
        }

        #endregion

        #region methods

        internal static Person GetById(int id)
        {
            Person person;
            DAL.Person personObject;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                personObject = context.People.Where(p => p.Id == id).FirstOrDefault();
            }

            person = new Person(personObject);

            return person;
        }

        internal static bool Validate(Person person)
        {
            if (string.IsNullOrEmpty(person.LastName) || string.IsNullOrEmpty(person.Email))
                return false;
            else
                return true;
        }

        internal bool Validate()
        {
            if (string.IsNullOrEmpty(this.LastName) || string.IsNullOrEmpty(this.Email))
                return false;
            else
                return true;
        }

        internal int Save()
        {
            int result = -1;
            //TODO: Validate the fields on save
            if (Validate())
            {
                this.Addr.Id = this.Addr.Save();

                using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
                {
                    result = Convert.ToInt32(context.InsertUpdatePerson(this.Id, this.FirstName, this.LastName, this.Email, this.AlternateEmail, this.DOB, this.Addr.Id, this.PrimaryPhone, this.SecondaryPhone, this.AvatarURL, this.CoverPicture, this.AboutMe).FirstOrDefault());
                    if (result > 0)
                        this.Id = result;
                }
            }
            return result;
        }

        internal bool Delete()
        {
            int result = -1;
            if (this.Id <= 0) return false;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.DeleteAddressById(this.Id);
                if (result > 0)
                    this.Id = result;
            }
            return result > 0 ? true : false;
        }

        internal static bool DeleteById(int id)
        {
            int result = -1;
            if (id <= 0) return false;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.DeleteAddressById(id);
                if (result > 0)
                    id = result;
            }
            return result > 0 ? true : false;
        }

        #endregion

    }
}
