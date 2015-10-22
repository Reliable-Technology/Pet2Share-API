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
        [WebInvoke(UriTemplate = "InsertVirtualPetProfile", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse InsertVirtualPetProfile(VirtualPetInsertRequest UserId);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdatePetProfile", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse UpdatePetProfile(PetProfileUpdateRequest PetObj);

        [OperationContract]
        [WebInvoke(UriTemplate = "UploadUserPic?UserId={UserId}&FileName={FileName}&IsCoverPic={IsCoverPic}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse UploadUserProfileCoverPic(Stream PicObj, string UserId, string FileName, string IsCoverPic);


        [OperationContract]
        [WebInvoke(UriTemplate = "UploadPetPic?PetId={PetId}&FileName={FileName}&IsCoverPic={IsCoverPic}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse UploadPetProfileCoverPic(Stream PicObj, string PetId, string FileName, string IsCoverPic);

        [OperationContract]
        [WebInvoke(UriTemplate = "AddPost", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse AddPost(AddPostRequest PostReq);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdatePost", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse UpdatePost(UpdatePostRequest PostReq);

        [OperationContract]
        [WebInvoke(UriTemplate = "DeletePost", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse DeletePost(DeletePostRequest PostReq);

        [OperationContract]
        [WebInvoke(UriTemplate = "AddPhotoPost?FileName={FileName}&Description={Description}&PostedBy={PostedBy}&IsPostByPet={IsPostByPet}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse AddPhotoPost(Stream PicObj, string FileName, string Description, string PostedBy, string IsPostByPet);

        [OperationContract]
        [WebInvoke(UriTemplate = "AddComment", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse AddComment(AddCommentRequest PostReq);

        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateComment", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse UpdateComment(UpdateCommentRequest PostReq);

        [OperationContract]
        [WebInvoke(UriTemplate = "DeleteComment", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GeneralUpdateResponse DeleteComment(DeleteCommentRequest PostReq);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetComments", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GetCommentResponse GetComments(GetCommentRequest PostReq);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetPostsByUser", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GetPostsResponse GetPostsByUser(GetPostsRequest PostReq);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetPostsByPet", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GetPostsResponse GetPostsByPet(GetPostsRequest PostReq);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetMyFeed", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        GetPostsResponse GetMyFeed(GetFeedsRequest PostReq);
    }

}
