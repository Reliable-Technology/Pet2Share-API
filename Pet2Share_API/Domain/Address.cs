using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    [Serializable]
    public class Address
    {
        #region members
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public bool IsBillingAddress { get; set; }
        public bool IsShippingAddres { get; set; }
        #endregion

        #region constructors
        public Address()
        {

        }

        public Address(int id)
        {

        }

        public Address(string addressLine1, string addressLine2, string city, string state, string country, string zip)
        {
            
        }
        #endregion

        #region methods

        public int Save()
        {
            int result = -1;

            using (DAL.Pet2ShareEntities context = new DAL.Pet2ShareEntities())
            {
                result = context.InsertUpdateAddress(0, this.AddressLine1, this.AddressLine2, this.City, this.State, this.Country, true, true, this.ZipCode);
                if (result > 0)
                    this.Id = result;
            }
            return result;
        }

        #endregion
    }
}
