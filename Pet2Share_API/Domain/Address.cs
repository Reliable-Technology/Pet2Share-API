using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    [DataContract]
    public class Address
    {
        #region members
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string AddressLine1 { get; set; }
        [DataMember]
        public string AddressLine2 { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public bool IsBillingAddress { get; set; }
        [DataMember]
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
