using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Utility
{
    public class BoolExt
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }

        //TODO: Need to work futher and add more fields probably

        public BoolExt(bool isSuccessful)
        {
            this.IsSuccessful = isSuccessful;
        }

        public BoolExt(bool isSuccessful, string message)
        {
            this.IsSuccessful = isSuccessful;
            this.Message = message;
        }
    }
}
