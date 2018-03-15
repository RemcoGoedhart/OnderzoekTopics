using SC.BL.Domain;
using SC.UI.Web.MVC.Models;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCF
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetTicketResponse?ticketNumber={ticketNumber}")]
        List<TicketResponse> GetTicketResponse(int ticketNumber);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat =WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "AddResponse")]
        TicketResponse AddResponse(NewTicketResponseDTO response);

        [OperationContract]
        [WebInvoke(Method = "GET",  UriTemplate = "TicketClosed?id={id}")]
        void TicketClosed(int id);
    }

}
