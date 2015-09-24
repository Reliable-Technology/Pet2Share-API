using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Domain
{
    public class Pet : Pet2Share_API.DAL.PetProfile
    {
        private string _name;
        public string Name { get { return _name; } }
    }


}
