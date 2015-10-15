using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    [DataContract]
    public class DomainBase
    {
        #region members
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime DateAdded { get; set; }
        [DataMember]
        public DateTime DateModified { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        #endregion
    }
}
