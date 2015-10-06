using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    public class SocialMediaSource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
