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
        public DateTime DOB { get; set; }
        [DataMember]
        public Address Addr { get; set; }
        [DataMember]
        public string PrimaryPhone { get; set; 
        }[DataMember]
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

        public Person(int personId)
        {

        }

        public Person()
        {
        }

        public Person(string firstName, string lastName, string email, DateTime? dob, Address addr, string primaryPhone, string secondaryPhone, string avatarURL)
        {

        }

        #endregion

        #region methods

        public int Save()
        {
            //TODO: Validate the fields on save
            this.Addr.Id = this.Addr.Save();
            int result = -1;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.InsertUpdatePerson(0, this.FirstName, this.LastName, this.Email, this.DOB, this.Addr.Id, this.PrimaryPhone, this.SecondaryPhone, this.AvatarURL, this.AboutMe);
                if (result > 0)
                    this.Id = result;
            }
            return result;
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
