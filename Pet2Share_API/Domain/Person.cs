using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
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
