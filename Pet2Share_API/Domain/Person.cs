using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    [DataContract]
    public class Person
    {
        #region members
        [DataMember]
        public int Id { get; set; }
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
        public string AboutMe { get; set; }
        [DataMember]
        public DateTime DateAdded { get; set; }
        [DataMember]
        public DateTime DateModified { get; set; }
        [DataMember]
        public bool IsActive { get; set; }

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
            this.AboutMe = p.AboutMe;
            this.DateAdded = p.DateAdded;
            this.DateModified = p.DateModified;
            this.IsActive = p.IsActive;
        }

        public Person(string firstName, string lastName, string email, string alternateEmail, DateTime? dob, Address addr, string primaryPhone, string secondaryPhone, string avatarURL) : base()
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
            this.AboutMe = p.AboutMe;
            this.DateAdded = p.DateAdded;
            this.DateModified = p.DateModified;
            this.IsActive = p.IsActive;
        }

        #endregion

        #region methods

        public static Person GetById(int id)
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

        public int Save()
        {
            //TODO: Validate the fields on save
            this.Addr.Id = this.Addr.Save();
            int result = -1;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = Convert.ToInt32(context.InsertUpdatePerson(this.Id, this.FirstName, this.LastName, this.Email, this.AlternateEmail, this.DOB, this.Addr.Id, this.PrimaryPhone, this.SecondaryPhone, this.AvatarURL, this.AboutMe).FirstOrDefault());
                if (result > 0)
                    this.Id = result;
            }
            return result;
        }

        public bool Delete()
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

        public static bool DeleteById(int id)
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
