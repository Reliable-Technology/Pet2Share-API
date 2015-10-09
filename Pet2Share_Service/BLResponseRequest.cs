using Pet2Share_API.Domain;
using Pet2Share_API.Utility;
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
        //[DataMember]
        //public User UserDetails { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }
 

    }

    [DataContract]
    public class RegisterResponse : ResponseObject
    {
        [DataMember]
        public User[] Results { get; set; }
    }

    [DataContract]
    public class UserProfileUpdateRequest : RequestObject
    {
        // [DataMember]
        // public User UserDetails { get; set; }

        [DataMember]
        public int UserId { get; set; }
 
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string AlternateEmail { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        public string PrimaryPhone { get; set; }

        [DataMember]
        public string SecondaryPhone { get; set; }

        [DataMember]
        public string AvatarUrl { get; set; }

        [DataMember]
        public string AboutMe { get; set; }

        [DataMember]
        public string AddressLine1 { get; set; }

        [DataMember]
        public string AddressLine2 { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string ZipCode { get; set; }



        //TODO: Need to add more fields later
    }

    [DataContract]
    public class UserProfileUpdateResponse : ResponseObject
    {
        [DataMember]
        public BoolExt Results { get; set; }

        //TODO: Need to add more fields later
    }

    [DataContract]
    public class UserProfileGetRequest : RequestObject
    {
        [DataMember]
        public int UserId { get; set; }

        //TODO: Need to add more fields later
    }

    [DataContract]
    public class UserProfileGetResponse : ResponseObject
    {
        [DataMember]
        public User[] Results { get; set; }

        //TODO: Need to add more fields later
    }


}