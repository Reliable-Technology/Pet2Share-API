using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    [Serializable]
    public class Person
    {
        #region members

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public Address Addr { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string AvatarURL { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
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

        public bool Save()
        {
            return false;
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
