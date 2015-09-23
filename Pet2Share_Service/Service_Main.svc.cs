using Newtonsoft.Json;
using Pet2Share_API.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace Pet2Share_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements
    (RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service_Main : IService_Main
    {
        #region commented
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

        //public  string LoginUser(string Username, string Password)
        //{
        //    try
        //    {
        //        var LoginResult= AccountManagement.Login(Username, Password);
        //        if (LoginResult != null)
        //        {
        //            return LoginResult.Id.ToString();
        //        }
        //        else
        //        {
        //            return "Invalid username or password.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "There is some error while logging you in. Please try again later.";
        //    }
        //} 
        #endregion

        public System.ServiceModel.Channels.Message LoginUser(CLLogin LoginDetails)
        {
            string SerializedResult;
            try
            {
                var LoginResult = AccountManagement.Login(LoginDetails.UserName, LoginDetails.Password);
                if (LoginResult != null)
                {
                    SerializedResult = JsonConvert.SerializeObject(new ResponseCL(1, (new object[] { LoginResult }), null));
                    //return SerializedResult;//return LoginResult.Id.ToString();
                }
                else
                {
                    //return new ResponseCL { errorMessage = new errorMessageCL { reasonCode = 1, message = "Invalid username or password" }, results = (new object[] { }), total = 0 };//return LoginResult.Id.ToString();

                    SerializedResult = JsonConvert.SerializeObject(new ResponseCL(0, null, new ErrorMessageCL(1, "Invalid Username or Password")));


                }
            }
            catch (Exception ex)
            {
                //return new ResponseCL { errorMessage = new errorMessageCL { reasonCode = 3, message = ex.Message }, results = (new object[] { }), total = 0 };//return LoginResult.Id.ToString();
                //return ;
                SerializedResult = JsonConvert.SerializeObject(new ResponseCL(0, null, new ErrorMessageCL(3, ex.Message)));
                // return new CLLogin { UserName = "testusername", Password = "testPass" };
                // return "There is some error while logging you in. Please try again later.";
            }

            return WebOperationContext.Current.CreateTextResponse(SerializedResult, "application/json; charset=utf-8", Encoding.UTF8);

        }
    }
}
