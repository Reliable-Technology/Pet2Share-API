using Pet2Share_API.Domain;
using Pet2Share_API.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
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
        public string SecondaryPhone { get; set; }

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
    public class GeneralUpdateResponse : ResponseObject
    {
        [DataMember]
        public BoolExt[] Results { get; set; }
         
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

    [DataContract]
    public class PetProfileUpdateRequest : RequestObject
    {
        [DataMember]
        public int PetId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string FamilyName { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int? PetTypeId { get; set; }

        [DataMember]
        public DateTime? DOB { get; set; }

        //Removed because they are uploaded from seperate service
        //[DataMember]
        //public string ProfilePicture { get; set; }

        //[DataMember]
        //public string CoverPicture { get; set; }

        [DataMember]
        public string About { get; set; }

        [DataMember]
        public string FavFood { get; set; }

        //TODO: Need to add more fields later
    }

    [DataContract]
    public class PetProfileInsertRequest : RequestObject
    {

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string FamilyName { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int? PetTypeId { get; set; }

        [DataMember]
        public DateTime? DOB { get; set; }

        //Removing because they are update from seperate service 
        //[DataMember]
        //public string ProfilePicture { get; set; }

        //[DataMember]
        //public string CoverPicture { get; set; }

        [DataMember]
        public string About { get; set; }

        [DataMember]
        public string FavFood { get; set; }

        //TODO: Need to add more fields later
    }


    [DataContract]
    public class UploadPicRequest : RequestObject
    {
        [MessageHeader]
        public int UserId { get; set; }

        [MessageHeader]
        public int PetId { get; set; }

        [MessageHeader]
        public int AlbumnId { get; set; }

        [MessageHeader]
        public bool isCoverPic { get; set; }

        [MessageBodyMember]
        public Stream FileContent { get; set; }

    }

    [DataContract]
    public class AddPostRequest : RequestObject
    {
        [DataMember]
        public int PostTypeId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int PostedBy { get; set; }

        [DataMember]
        public bool IsPostByPet { get; set; }

    }

    [DataContract]
    public class UpdatePostRequest : RequestObject
    {
        [DataMember]
        public int PostId { get; set; }

        [DataMember]
        public string PostDescription { get; set; }
    }

    [DataContract]
    public class DeletePostRequest : RequestObject
    {
        [DataMember]
        public int PostId { get; set; }
    }

    [DataContract]
    public class PostLikeRequest : RequestObject
    {
        [DataMember]
        public int PostId { get; set; }

        [DataMember]
        public int UserId { get; set; }

    }

    [DataContract]
    public class AddCommentRequest : RequestObject
    {
        [DataMember]
        public int PostId { get; set; }

        [DataMember]
        public int CommentedById { get; set; }

        [DataMember]
        public bool IsCommentedByPet { get; set; }

        [DataMember]
        public string CommentDescription { get; set; }
    }

    [DataContract]
    public class UpdateCommentRequest : RequestObject
    {
        [DataMember]
        public int CommentId { get; set; }

        [DataMember]
        public string CommentDescription { get; set; }
    }

    [DataContract]
    public class DeleteCommentRequest : RequestObject
    {
        [DataMember]
        public int CommentId { get; set; }

    }

    [DataContract]
    public class GetCommentRequest : RequestObject
    {
        [DataMember]
        public int PostId { get; set; }

    }

    [DataContract]
    public class GetCommentResponse : ResponseObject
    {
        [DataMember]
        public Comment[] Results { get; set; }
    }


}