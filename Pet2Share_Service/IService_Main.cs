using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;

namespace Pet2Share_Service
{
    [ServiceContract]
    public interface IService_Main
    {


        [OperationContract]
        [WebInvoke(UriTemplate = "LoginUser", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        LoginResponse LoginUser(LoginRequest loginDetails);

        [OperationContract]
        [WebInvoke(UriTemplate = "Register", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        RegisterResponse RegisterUser(RegisterRequest userObj);

    }

}
