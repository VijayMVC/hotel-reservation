using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    { 
        // get Doctors 
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "getDoctors")]
        [return: MessageParameter(Name = "success")]
        List<Doctor> GetAllDoctors();

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "saveAppoinmentMobile"
         )]
        [return: MessageParameter(Name = "success")]
        responseCls saveAppoinmentMobile(submit expositions);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "saveCredits"
         )]
        [return: MessageParameter(Name = "success")]
        responseCls saveCredits(submit expositions);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "signUp"
         )]
        [return: MessageParameter(Name = "success")]
        responseCls signUpForm(signUps expositions);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "login"
         )]
        [return: MessageParameter(Name = "success")]
        responseCls loginForm(loginCls expositions);


        [OperationContract]
        [WebInvoke(
            Method = "OPTIONS",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "login"
         )]
        [return: MessageParameter(Name = "success")]
        responseCls loginFormOption(loginCls expositions);


        [OperationContract]
        [WebInvoke(
            Method = "OPTIONS",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "saveAppoinmentMobile"
         )]
        [return: MessageParameter(Name = "success")]
        responseCls saveAppoinmentMobileOption(submit expositions);

        [OperationContract]
        [WebInvoke(
            Method = "OPTIONS",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "saveCredits"
         )]
        [return: MessageParameter(Name = "success")]
        responseCls saveCreditsOption(submit expositions);

        [OperationContract]
        [WebInvoke(
            Method = "OPTIONS",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "signUp"
         )]
        [return: MessageParameter(Name = "success")]
        responseCls signUpFormOption(signUps expositions);

    }
}
