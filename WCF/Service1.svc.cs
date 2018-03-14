using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SC.BL;
using SC.BL.Domain;
using SC.UI.Web.MVC.Models;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private ITicketManager mgr = new TicketManager();

        public List<TicketResponse> GetTicketResponse(int ticketNumber)
        {

            var responses = mgr.GetTicketResponses(ticketNumber);
            return (responses.ToList());
        }

        public TicketResponse AddResponse(NewTicketResponseDTO response)
        {
            TicketResponse createdResponse = mgr.AddTicketResponse(response.TicketNumber
            , response.ResponseText, response.IsClientResponse);

            TicketResponse responseData = new TicketResponse()
            {
                Id = createdResponse.Id,
                Text = createdResponse.Text,
                Date = createdResponse.Date,
                IsClientResponse = createdResponse.IsClientResponse
            };
            WebOperationContext ctx = WebOperationContext.Current;

            return responseData;
        }

        public void TicketClosed(int id)
        {
            mgr.ChangeTicketStateToClosed(id);
        }
    }
}
