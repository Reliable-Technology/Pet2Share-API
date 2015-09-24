using Newtonsoft.Json;
using Pet2Share_API.DAL;
using Pet2Share_API.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
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

        public Stream LoginUser(LoginCL loginDetails)
        {
            string SerializedResult;
            try
            {
                var LoginResult = AccountManagement.Login(loginDetails.UserName, loginDetails.Password);
                if (LoginResult != null && LoginResult.IsAuthenticated == true && LoginResult.Id > 0)
                {
                    SerializedResult = JsonConvert.SerializeObject(new ResponseCL(1, (new object[] { LoginResult }), null));
                }
                else
                {
                    SerializedResult = JsonConvert.SerializeObject(new ResponseCL(0, null, new ErrorMessageCL(1, "Invalid Username or Password")));
                }
            }
            catch (Exception ex)
            {
                SerializedResult = JsonConvert.SerializeObject(new ResponseCL(0, null, new ErrorMessageCL(3, ex.Message)));
            }

            WebOperationContext.Current.OutgoingResponse.ContentType =
        "application/json; charset=utf-8";
            return new MemoryStream(Encoding.UTF8.GetBytes(SerializedResult));

            // return WebOperationContext.Current.CreateTextResponse(SerializedResult, "application/json; charset=utf-8", Encoding.UTF8);

        }

        public Stream RegisterUser(Pet2Share_API.Domain.User userDetails)
        {
            string SerializedResult;
            try
            {
                var Result = AccountManagement.RegisterNewUser(userDetails);
                if (Result != null && Result.Id > 0)
                {
                    SerializedResult = JsonConvert.SerializeObject(new ResponseCL(1, (new object[] { Result }), null));
                }
                else
                {
                    SerializedResult = JsonConvert.SerializeObject(new ResponseCL(0, null, new ErrorMessageCL(1, "There was some error while signing you up. Please try again!!")));
                }
            }
            catch (Exception ex)
            {
                SerializedResult = JsonConvert.SerializeObject(new ResponseCL(0, null, new ErrorMessageCL(3, ex.Message)));
            }
            // return WebOperationContext.Current.CreateTextResponse(SerializedResult, "application/json; charset=utf-8", Encoding.UTF8);

            WebOperationContext.Current.OutgoingResponse.ContentType =
       "application/json; charset=utf-8";
            return new MemoryStream(Encoding.UTF8.GetBytes(SerializedResult));


        }


    }
}
