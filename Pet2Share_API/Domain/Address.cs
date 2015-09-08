using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    class Address
    {
        #region members
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        #endregion

        #region constructors
        public Address()
        {

        }

        public Address(int id)
        {

        }

        public Address(string addressLine1, string addressLine2, string city, string state, string country)
        {
            
        }
        #endregion

        #region methods

        public string Save()
        {
            return "";
        }

        #endregion
    }
}
