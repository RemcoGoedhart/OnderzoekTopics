using System.Collections.Generic;
using System.Linq;
using SC.BL;
using SC.BL.Domain;
using SC.UI.Web.MVC.Models;

namespace WCF
{
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
            TicketResponse createdResponse = mgr.AddTicketResponse(response.TicketNumber, response.ResponseText, response.IsClientResponse);

            TicketResponse responseData = new TicketResponse()
            {
                Id = createdResponse.Id,
                Text = createdResponse.Text,
                Date = createdResponse.Date,
                IsClientResponse = createdResponse.IsClientResponse
            };
            return responseData;
        }

        public void TicketClosed(int id)
        {
            mgr.ChangeTicketStateToClosed(id);
        }
    }
}
