using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet2Share_API.Utility
{
    public class ErrorHandler
    {
        //Define error codes and their descripion
        //  Error Code      Description
        //  100             
        //

        public int ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public Exception IntenralException { get; set; }


        //This has a table of 
        public static string GetDescription(int errorCode)
        {
            return "";
        }
    }
}
