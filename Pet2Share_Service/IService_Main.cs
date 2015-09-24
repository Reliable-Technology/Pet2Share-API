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
        Stream LoginUser(LoginCL loginDetails);

        [OperationContract]
        [WebInvoke(UriTemplate = "Register", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        Stream RegisterUser(Pet2Share_API.Domain.User userDetails);

    }

    [DataContract]
    public class ResponseCL
    {
        [DataMember]
        public int Total { get; set; }
        [DataMember]
        public object[] Results { get; set; }
        [DataMember]
        public ErrorMessageCL ErrorMessage { get; set; }

        public ResponseCL(int total, object[] results, ErrorMessageCL errMsg)
        {
            Total = total;
            Results = results;
            ErrorMessage = errMsg;

        }

    }

    [DataContract]
    public class ErrorMessageCL
    {
        [DataMember]
        public int ReasonCode { get; set; }

        [DataMember]
        public string Msg { get; set; }

        public ErrorMessageCL(int rsnCode, string msg)
        {
            ReasonCode = rsnCode;
            Msg = msg;
        }


    }


    public class LoginCL
    {

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Message { get; set; }

        public ResponseType Resp { get; set; }

    }

    public enum ResponseType
    {
        Success,
        Failed,
        Exception
    }
    //public sealed class BLGender
    //{
    //    private static readonly BLGender _instance;
    //    private static CareWriteEntities _context;

    //    // Explicit static constructor to tell C# compiler
    //    // not to mark type as beforefieldinit
    //    static BLGender()
    //    {
    //        _instance = new BLGender();
    //    }

    //    private BLGender()
    //    {
    //    }

    //    public static BLGender Instance(CareWriteEntities context)
    //    {
    //        _context = context;
    //        return _instance;
    //    }

    //    public List<Gender> GetGender()
    //    {
    //        return _context.Genders.ToList();
    //    }


    //}

}
