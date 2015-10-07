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
               
                var Result = AccountManagement.RegisterNewUser(userObj.UserName, userObj.Password, userObj.FirstName, userObj.LastName, userObj.UserName);
                 
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

        public UserProfileResponse UpdateProfile(UserProfileRequest userObj)
        {
            UserProfileResponse UserProfileResultResp;

            try
            {
                var Result = UserProfileManager.UpdateProfile(userObj.UserDetails);
                if (Result.IsSuccessful)
                {
                    UserProfileResultResp = new UserProfileResponse { Total = 1, Results = (new Pet2Share_API.Domain.User[] { userObj.UserDetails }), ErrorMsg = null };
                }
                else
                {
                    UserProfileResultResp = new UserProfileResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error updating profile. Please try again!!") };
                }
            }
            catch (Exception ex)
            {
                UserProfileResultResp = new UserProfileResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return UserProfileResultResp;
        }

        public UserProfileResponse GetUserProfile(int UserId)
        {
            UserProfileResponse UserProfileResultResp;

            try
            {
                UserProfileManager userObj = new UserProfileManager(UserId);
                if (userObj.user.Id == UserId)
                {
                    UserProfileResultResp = new UserProfileResponse { Total = 1, Results = (new Pet2Share_API.Domain.User[] { userObj.user }), ErrorMsg = null };
                }
                else
                {
                    UserProfileResultResp = new UserProfileResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(1, "There was some error while fetching your profile. Please try again!!") };
                }
            }
            catch (Exception ex)
            {
                UserProfileResultResp = new UserProfileResponse { Total = 0, Results = null, ErrorMsg = new CLErrorMessage(3, ex.InnerException + "--" + ex.StackTrace) };
            }
            return UserProfileResultResp;
        }

    }
}
