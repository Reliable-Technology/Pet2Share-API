using Newtonsoft.Json;
using Pet2Share_API.DAL;
using Pet2Share_API.Service;
using Pet2Share_API.Utility;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
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

        public LoginResponse LoginUser(LoginRequest loginDetails)
        {

            LoginResponse LoginResultResp;
            try
            {
                var LoginResult = AccountManagement.Login(loginDetails.UserName, loginDetails.Password);
                if (LoginResult != null && LoginResult.IsAuthenticated == true && LoginResult.Id > 0)
                {
                    LoginResultResp = new LoginResponse { Total = 1, Results = (new Pet2Share_API.Domain.User[] { LoginResult }), ErrorMsg = null };
                }
                else
                {
                    LoginResultResp = new LoginResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "Invalid Username or Password") };
                }
            }
            catch (Exception ex)
            {
                LoginResultResp = new LoginResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }

            return LoginResultResp;

        }

        public RegisterResponse RegisterUser(RegisterRequest userObj)
        {
            RegisterResponse RegisterResultResp;

            try
            {

                var Result = AccountManagement.RegisterNewUser(userObj.UserName, userObj.Password, userObj.FirstName, userObj.LastName, userObj.UserName, null);

                if (Result != null && Result.Id > 0)
                {
                    Result.Password = null;
                    RegisterResultResp = new RegisterResponse { Total = 1, Results = (new Pet2Share_API.Domain.User[] { Result }), ErrorMsg = null };
                }
                else
                {
                    RegisterResultResp = new RegisterResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error while signing you up. Please try again!!") };
                }
            }
            catch (Exception ex)
            {
                RegisterResultResp = new RegisterResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return RegisterResultResp;
        }

        public GeneralUpdateResponse UpdateProfile(UserProfileUpdateRequest userObj)
        {
            GeneralUpdateResponse UserProfileResultResp;

            try
            {

                var Result = UserProfileManager.UpdateProfile(userObj.UserId, userObj.FirstName, userObj.LastName, userObj.Email, userObj.AlternateEmail, userObj.DateOfBirth, userObj.PhoneNumber, userObj.SecondaryPhone, "",
                    userObj.AboutMe, userObj.AddressLine1, userObj.AddressLine2, userObj.City, userObj.State, userObj.Country, userObj.ZipCode);
                if (Result.IsSuccessful)
                {
                    UserProfileResultResp = new GeneralUpdateResponse { Total = 1, Results = (new Pet2Share_API.Utility.BoolExt[] { Result }), ErrorMsg = null };
                }
                else
                {
                    UserProfileResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error updating profile. Please try again!!") };
                }
            }
            catch (Exception ex)
            {
                UserProfileResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return UserProfileResultResp;
        }

        public UserProfileGetResponse GetUserProfile(UserProfileGetRequest UserObj)
        {
            UserProfileGetResponse UserProfileResultResp;

            try
            {
                UserProfileManager userObj = new UserProfileManager(UserObj.UserId);
                if (userObj.user.Id == UserObj.UserId)
                {
                    UserProfileResultResp = new UserProfileGetResponse { Total = 1, Results = (new Pet2Share_API.Domain.User[] { userObj.user }), ErrorMsg = null };
                }
                else
                {
                    UserProfileResultResp = new UserProfileGetResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "Profile not found.") };
                }
            }
            catch (Exception ex)
            {
                UserProfileResultResp = new UserProfileGetResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return UserProfileResultResp;
        }


        public GeneralUpdateResponse UpdatePetProfile(PetProfileUpdateRequest PetObj)
        {
            GeneralUpdateResponse PetProfileResultResp;

            try
            {

                var Result = PetProfileManager.UpdateProfile(PetObj.PetId, PetObj.Name, PetObj.FamilyName, PetObj.UserId, PetObj.PetTypeId, PetObj.DOB, "", "", PetObj.About, PetObj.FavFood);
                if (Result.IsSuccessful)
                {
                    PetProfileResultResp = new GeneralUpdateResponse { Total = 1, Results = (new Pet2Share_API.Utility.BoolExt[] { Result }), ErrorMsg = null };
                }
                else
                {
                    PetProfileResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error updating pet profile. Please try again!!") };
                }
            }
            catch (Exception ex)
            {
                PetProfileResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return PetProfileResultResp;
        }

        public GeneralUpdateResponse InsertPetProfile(PetProfileInsertRequest PetObj)
        {
            GeneralUpdateResponse PetProfileResultResp;

            try
            {

                var Result = PetProfileManager.AddProfile(PetObj.Name, PetObj.FamilyName, PetObj.UserId, PetObj.PetTypeId, PetObj.DOB, "", "", PetObj.About, PetObj.FavFood);
                if (Result.IsSuccessful)
                {
                    PetProfileResultResp = new GeneralUpdateResponse { Total = 1, Results = (new Pet2Share_API.Utility.BoolExt[] { Result }), ErrorMsg = null };
                }
                else
                {
                    PetProfileResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error adding pet to your profile. Please try again!!") };
                }
            }
            catch (Exception ex)
            {
                PetProfileResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return PetProfileResultResp;
        }

        //public GeneralUpdateResponse UploadUserPic(Stream PicObj, string UserId, string PetId, string UploadType, string FileName)
        //{

        //    GeneralUpdateResponse UpdateResp;
        //    try
        //    {
        //        //typeof(GetTfromString(UploadType))



        //        if (string.IsNullOrEmpty(ImageProcessor.Upload(ReadFully(PicObj), FileName, "", 0, typeof(User))))
        //        {
        //            UpdateResp = new GeneralUpdateResponse { Total = 0, Results = (new Pet2Share_API.Utility.BoolExt[] { new BoolExt(true) }), ErrorMsg = null };
        //        }
        //        else
        //        {
        //            UpdateResp = new GeneralUpdateResponse { Total = 0, Results = (new Pet2Share_API.Utility.BoolExt[] { new BoolExt(false) }), ErrorMsg = null };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        UpdateResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
        //    }

        //    return UpdateResp;
        //}

        //public static byte[] ReadFully(Stream input)
        //{
        //    byte[] buffer = new byte[16 * 1024];
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        int read;
        //        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        //        {
        //            ms.Write(buffer, 0, read);
        //        }
        //        return ms.ToArray();
        //    }
        //}

        public GeneralUpdateResponse UploadUserProfileCoverPic(Stream PicObj, string UserId, string FileName, string IsCoverPic)
        {
            try
            {
                //if (PicObj.1)
                //{
                //    return new GeneralUpdateResponse { Total = 0, Results = new Pet2Share_API.Utility.BoolExt[] { new BoolExt(false, "Please upload a file") }, ErrorMsg = null };
                //}

                if (string.IsNullOrEmpty(FileName))
                {
                    return new GeneralUpdateResponse { Total = 0, Results = new Pet2Share_API.Utility.BoolExt[] { new BoolExt(false, "File name cannot be empty") }, ErrorMsg = null };
                }

                string FileExtension = Path.GetExtension(FileName);

                Pet2Share_API.Utility.ImageType FileType;
                if (!Enum.TryParse(FileExtension.TrimStart('.'), out FileType))
                {
                    return new GeneralUpdateResponse { Total = 0, Results = new Pet2Share_API.Utility.BoolExt[] { new BoolExt(false, "Only Jpg and Png file can be uploaded") }, ErrorMsg = null };
                }

                int IntUserId = 0;
                if (!int.TryParse(UserId, out IntUserId))
                {
                    return new GeneralUpdateResponse { Total = 0, Results = new Pet2Share_API.Utility.BoolExt[] { new BoolExt(false, "UserId must be an integer") }, ErrorMsg = null };
                }

                BoolExt Result;

                bool BoolIsCover = false;

                if (!bool.TryParse(IsCoverPic, out BoolIsCover))
                {
                    return new GeneralUpdateResponse { Total = 0, Results = new Pet2Share_API.Utility.BoolExt[] { new BoolExt(false, "IsCoverPic field should contain only true or false") }, ErrorMsg = null };
                }

                if (BoolIsCover)
                {
                    Result = UserProfileManager.UpdateCoverPicture(ReadFully(PicObj), FileName, FileType, IntUserId);
                }
                else
                {
                    Result = UserProfileManager.UpdateProfilePicture(ReadFully(PicObj), FileName, FileType, IntUserId);
                }

                return new GeneralUpdateResponse { Total = 0, Results = new Pet2Share_API.Utility.BoolExt[] { Result }, ErrorMsg = null };


            }
            catch (Exception ex)
            {
                return new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
        }

        public GeneralUpdateResponse UploadPetProfileCoverPic(Stream PicObj, string PetId, string FileName, string IsCoverPic)
        {
            try
            {
                //if (PicObj.Length <= 0)
                //{
                //    return new GeneralUpdateResponse { Total = 0, Results = new Pet2Share_API.Utility.BoolExt[] { new BoolExt(false, "Please upload a file") }, ErrorMsg = null };
                //}

                if (string.IsNullOrEmpty(FileName))
                {
                    return new GeneralUpdateResponse { Total = 0, Results = new Pet2Share_API.Utility.BoolExt[] { new BoolExt(false, "File name cannot be empty") }, ErrorMsg = null };
                }

                string FileExtension = Path.GetExtension(FileName);

                Pet2Share_API.Utility.ImageType FileType;

                if (!Enum.TryParse(FileExtension.TrimStart('.'), out FileType))
                {
                    return new GeneralUpdateResponse { Total = 0, Results = new Pet2Share_API.Utility.BoolExt[] { new BoolExt(false, "Only Jpg and Png file can be uploaded") }, ErrorMsg = null };
                }

                bool BoolIsCover = false;

                if (!bool.TryParse(IsCoverPic, out BoolIsCover))
                {
                    return new GeneralUpdateResponse { Total = 0, Results = new Pet2Share_API.Utility.BoolExt[] { new BoolExt(false, "IsCoverPic field should contain only true or false") }, ErrorMsg = null };
                }

                int IntPetId = 0;
                if (!int.TryParse(PetId, out IntPetId))
                {
                    return new GeneralUpdateResponse { Total = 0, Results = new Pet2Share_API.Utility.BoolExt[] { new BoolExt(false, "UserId must be an integer") }, ErrorMsg = null };
                }

                BoolExt Result;

                if (BoolIsCover)
                {
                    Result = PetProfileManager.UpdateCoverPicture(ReadFully(PicObj), FileName, FileType, IntPetId);
                }
                else
                {
                    Result = PetProfileManager.UpdateProfilePicture(ReadFully(PicObj), FileName, FileType, IntPetId);
                }

                return new GeneralUpdateResponse { Total = 0, Results = new Pet2Share_API.Utility.BoolExt[] { Result }, ErrorMsg = null };



            }
            catch (Exception ex)
            {
                return new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
        }

        public GeneralUpdateResponse AddPost(AddPostRequest PostReq)
        {
            GeneralUpdateResponse PostResultResp;

            try
            {

                var Result = PostManager.AddPost(PostReq.PostTypeId, PostReq.Description, PostReq.PostedBy, PostReq.IsPostByPet);
                if (Result.Id > 0)
                {
                    PostResultResp = new GeneralUpdateResponse { Total = 1, Results = (new Pet2Share_API.Utility.BoolExt[] { new BoolExt(true, "", Result.Id) }), ErrorMsg = null };
                }
                else
                {
                    PostResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error while posting. Please try again!!") };
                }
            }
            catch (Exception ex)
            {
                PostResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return PostResultResp;
        }

        public GeneralUpdateResponse UpdatePost(UpdatePostRequest PostReq)
        {
            GeneralUpdateResponse PostResultResp;

            try
            {

                var Result = PostManager.UpdatePost(PostReq.PostId, PostReq.PostDescription);
                if (Result.Id > 0)
                {
                    PostResultResp = new GeneralUpdateResponse { Total = 1, Results = (new Pet2Share_API.Utility.BoolExt[] { new BoolExt(true, "", Result.Id) }), ErrorMsg = null };
                }
                else
                {
                    PostResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error while updating your post. Please try again!!") };
                }
            }
            catch (Exception ex)
            {
                PostResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return PostResultResp;
        }

        public GeneralUpdateResponse DeletePost(DeletePostRequest PostReq)
        {
            GeneralUpdateResponse PostResultResp;

            try
            {

                var Result = PostManager.DeletePost(PostReq.PostId);
                if (Result.IsSuccessful)
                {
                    PostResultResp = new GeneralUpdateResponse { Total = 1, Results = (new Pet2Share_API.Utility.BoolExt[] { Result }), ErrorMsg = null };
                }
                else
                {
                    PostResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error while deleting your post. Please try again!!") };
                }
            }
            catch (Exception ex)
            {
                PostResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return PostResultResp;
        }

        //public GeneralUpdateResponse LikePost(PostLikeRequest PostReq)
        //{
        //    GeneralUpdateResponse PostResultResp;

        //    try
        //    {

        //        var Result = PostManager.ToggleLike(PostReq.PostId, PostReq.UserId);
        //        if (Result.IsSuccessful)
        //        {
        //            PostResultResp = new GeneralUpdateResponse { Total = 1, Results = (new Pet2Share_API.Utility.BoolExt[] { Result }), ErrorMsg = null };
        //        }
        //        else
        //        {
        //            PostResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error while deleting your post. Please try again!!") };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        PostResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
        //    }
        //    return PostResultResp;
        //}

        public GeneralUpdateResponse AddComment(AddCommentRequest PostReq)
        {
            GeneralUpdateResponse PostResultResp;

            try
            {

                var Result = PostManager.AddComment(PostReq.PostId, PostReq.CommentedById, PostReq.IsCommentedByPet, PostReq.CommentDescription);
                if (Result.Id > 0)
                {
                    PostResultResp = new GeneralUpdateResponse { Total = 1, Results = (new Pet2Share_API.Utility.BoolExt[] { new BoolExt(true, "", Result.Id) }), ErrorMsg = null };
                }
                else
                {
                    PostResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error while adding your comment. Please try again!!") };
                }
            }
            catch (Exception ex)
            {
                PostResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return PostResultResp;
        }

        public GeneralUpdateResponse UpdateComment(UpdateCommentRequest PostReq)
        {
            GeneralUpdateResponse PostResultResp;

            try
            {

                var Result = PostManager.UpdateComment(PostReq.CommentId, PostReq.CommentDescription);
                if (Result.Id > 0)
                {
                    PostResultResp = new GeneralUpdateResponse { Total = 1, Results = (new Pet2Share_API.Utility.BoolExt[] { new BoolExt(true, "", Result.Id) }), ErrorMsg = null };
                }
                else
                {
                    PostResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error while updating your comment. Please try again!!") };
                }
            }
            catch (Exception ex)
            {
                PostResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return PostResultResp;
        }

        public GeneralUpdateResponse DeleteComment(DeleteCommentRequest PostReq)
        {
            GeneralUpdateResponse PostResultResp;

            try
            {

                var Result = PostManager.DeleteComment(PostReq.CommentId);
                if (Result.IsSuccessful)
                {
                    PostResultResp = new GeneralUpdateResponse { Total = 1, Results = (new Pet2Share_API.Utility.BoolExt[] { Result }), ErrorMsg = null };
                }
                else
                {
                    PostResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error while deleting your comment. Please try again!!") };
                }
            }
            catch (Exception ex)
            {
                PostResultResp = new GeneralUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return PostResultResp;
        }

        public GetCommentResponse GetComments(GetCommentRequest PostReq)
        {
            GetCommentResponse CommentResultResp;

            try
            {

                var Result = PostManager.GetComments(PostReq.PostId);
                //if (Result.count)
                {
                    CommentResultResp = new GetCommentResponse { Total = Result.Count(), Results = Result.ToArray(), ErrorMsg = null };
                }
                //else
                //{
                //    CommentResultResp = new GetCommentResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error while getting your comment. Please try again!!") };
                //}
            }
            catch (Exception ex)
            {
                CommentResultResp = new GetCommentResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return CommentResultResp;
        }

        public GetPostsResponse GetPostsByUser(GetPostsRequest PostReq)
        {
            GetPostsResponse PostResultResp;

            try
            {

                var Result = PostManager.GetPostsByUser(PostReq.ProfileId, PostReq.PostCount, PostReq.PageNumber);
                //if (Result.count)
                {
                    PostResultResp = new GetPostsResponse { Total = Result.Count(), Results = Result.ToArray(), ErrorMsg = null };
                }
                //else
                //{
                //    CommentResultResp = new GetCommentResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error while getting your comment. Please try again!!") };
                //}
            }
            catch (Exception ex)
            {
                PostResultResp = new GetPostsResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return PostResultResp;
        }

        public GetPostsResponse GetPostsByPet(GetPostsRequest PostReq)
        {
            GetPostsResponse PostResultResp;

            try
            {

                var Result = PostManager.GetPostsByPet(PostReq.ProfileId, PostReq.PostCount, PostReq.PageNumber);
                //if (Result.count)
                {
                    PostResultResp = new GetPostsResponse { Total = Result.Count(), Results = Result.ToArray(), ErrorMsg = null };
                }
                //else
                //{
                //    CommentResultResp = new GetCommentResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error while getting your comment. Please try again!!") };
                //}
            }
            catch (Exception ex)
            {
                PostResultResp = new GetPostsResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return PostResultResp;
        }




        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

    }




}
