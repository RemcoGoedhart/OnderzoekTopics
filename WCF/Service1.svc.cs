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

        public String AddResponse(NewTicketResponseDTO response)
        {
            TicketResponse createdResponse = mgr.AddTicketResponse(response.TicketNumber
            , response.ResponseText, response.IsClientResponse);

            if (createdResponse == null)
            {
                WebOperationContext bad = WebOperationContext.Current;
                bad.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                bad.OutgoingResponse.StatusDescription = "Er is iets misgelopen bij het registreren van het antwoord!";
                Debug.WriteLine(bad.OutgoingResponse.StatusCode);
                Debug.WriteLine(bad.OutgoingResponse.StatusDescription);
            }

            TicketResponse responseData = new TicketResponse()
            {
                Id = createdResponse.Id,
                Text = createdResponse.Text,
                Date = createdResponse.Date,
                IsClientResponse = createdResponse.IsClientResponse
            };            WebOperationContext ctx = WebOperationContext.Current;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(responseData.GetType());
            MemoryStream memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, responseData);
            string json = Encoding.Default.GetString(memoryStream.ToArray());

            return json;
        }

        public List<TicketResponse> GetTicketResponse(int ticketNumber)
        {
            
            var responses = mgr.GetTicketResponses(ticketNumber);
            WebOperationContext ctx = WebOperationContext.Current;
            Debug.WriteLine("CODE");
            Debug.WriteLine(ctx.OutgoingResponse.StatusCode);
            return (responses.ToList());
        }
    }
}
