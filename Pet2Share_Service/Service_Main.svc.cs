using Pet2Share_API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Pet2Share_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service_Main : IService_Main
    {
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}

        public  string LoginUser(string Username, string Password)
        {
            try
            {
                var LoginResult= AccountManagement.Login(Username, Password);
                if (LoginResult != null)
                {
                    return LoginResult.Id.ToString();
                }
                else
                {
                    return "Invalid username or password.";
                }
            }
            catch (Exception ex)
            {
                return "There is some error while logging you in. Please try again later.";
            }
        }


    }
}
