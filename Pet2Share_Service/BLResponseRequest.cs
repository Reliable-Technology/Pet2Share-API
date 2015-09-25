using Pet2Share_API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Pet2Share_Service
{
    [DataContract]
    public class RequestObject
    {
        [DataMember]
        public string ClientIP { get; set; }
        [DataMember]
        public string TimeStamp { get; set; }
    }

    [DataContract]
    public class ResponseObject
    {
        [DataMember]
        public int Total { get; set; }

        [DataMember]
        public CLErrorMessage ErrorMsg { get; set; }
    }

    [DataContract]
    public class CLErrorMessage
    {
        [DataMember]
        public int ReasonCode { get; set; }

        [DataMember]
        public string Msg { get; set; }

        public CLErrorMessage(int rsnCode, string msg)
        {
            ReasonCode = rsnCode;
            Msg = msg;
        }


    }

    [DataContract]
    public class LoginRequest : RequestObject
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

    }

    [DataContract]
    public class LoginResponse : ResponseObject
    {
        [DataMember]
        public User[] Results { get; set; }
    }


    [DataContract]
    public class RegisterRequest : RequestObject
    {
        [DataMember]
        public User UserDetails { get; set; }

    }

    [DataContract]
    public class RegisterResponse : ResponseObject
    {
        [DataMember]
        public User[] Results { get; set; }
    }

}