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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService_Main
    {

        #region Commented
        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        //[OperationContract]
        //string LoginUser(string Username, string Password); 
        #endregion

        [OperationContract]
        [WebInvoke(UriTemplate = "LoginUser", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Message LoginUser(CLLogin LoginDetails);


        // TODO: Add your service operations here
    }

    [DataContract]
    public class ResponseCL
    {
        [DataMember]
        public int total { get; set; }
        [DataMember]
        public object[] results { get; set; }
        [DataMember]
        public ErrorMessageCL errorMessage { get; set; }

        public ResponseCL(int Total, object[] Results, ErrorMessageCL ErrMsg)
        {
            total = Total;
            results = Results;
            errorMessage = ErrMsg;

        }

    }

    [DataContract]
    public class ErrorMessageCL
    {
        [DataMember]
        public int reasonCode { get; set; }

        [DataMember]
        public string message { get; set; }

        public ErrorMessageCL(int RsnCode, string Msg)
        {
            reasonCode = RsnCode;
            message = Msg;
        }


    }


    public class CLLogin
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


    [DataContract]
    public class stringMessage
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public ResponseType Resp { get; set; }

        public stringMessage(string _Message, ResponseType _Resp)
        {
            Message = _Message;
            Resp = _Resp;
        }
    }


    #region Commented
    //// Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //} 
    #endregion

}
