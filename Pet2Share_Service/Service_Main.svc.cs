using Newtonsoft.Json;
using Pet2Share_API.DAL;
using Pet2Share_API.Service;
using Pet2Share_API.Utility;
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

        public UserProfileUpdateResponse UpdateProfile(UserProfileUpdateRequest userObj)
        {
            UserProfileUpdateResponse UserProfileResultResp;

            try
            {

                var Result = UserProfileManager.UpdateProfile(userObj.UserId, userObj.FirstName, userObj.LastName, userObj.Email, userObj.AlternateEmail, userObj.DateOfBirth, userObj.PrimaryPhone, userObj.SecondaryPhone, userObj.AvatarUrl,
                    userObj.AboutMe, userObj.AddressLine1, userObj.AddressLine2, userObj.City, userObj.State, userObj.Country, userObj.ZipCode);
                if (Result.IsSuccessful)
                {
                    UserProfileResultResp = new UserProfileUpdateResponse { Total = 1, Results = Result, ErrorMsg = null };
                }
                else
                {
                    UserProfileResultResp = new UserProfileUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error updating profile. Please try again!!") };
                }
            }
            catch (Exception ex)
            {
                UserProfileResultResp = new UserProfileUpdateResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
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

    }
}
