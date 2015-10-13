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

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateUserProfile", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse UpdateProfile(UserProfileUpdateRequest userObj);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetUserProfile", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        UserProfileGetResponse GetUserProfile(UserProfileGetRequest UserId);

        [OperationContract]
        [WebInvoke(UriTemplate = "InsertPetProfile", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse InsertPetProfile(PetProfileInsertRequest PetObj);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdatePetProfile", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse UpdatePetProfile(PetProfileUpdateRequest PetObj);

        [OperationContract]
        [WebInvoke(UriTemplate = "UploadUserPic?UserId={UserId}&FileName={FileName}&IsCoverPic={IsCoverPic}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse UploadUserProfileCoverPic(Stream PicObj, string UserId, string FileName, string IsCoverPic);


        [OperationContract]
        [WebInvoke(UriTemplate = "UploadPetPic?PetId={PetId}&FileName={FileName}&IsCoverPic={IsCoverPic}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse UploadPetProfileCoverPic(Stream PicObj, string PetId, string FileName, string IsCoverPic);

       



    }

}
