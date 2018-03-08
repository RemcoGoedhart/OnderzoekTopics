using SC.BL.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SC.UI.Web.MVC.Controllers
{
    public class TicketResponseController : Controller
    {
        // GET: TicketResponse
        public String Get(int ticketNumber)
        {
            
            ServiceReference1.Service1Client ServiceRef = new ServiceReference1.Service1Client();

            List<TicketResponse> lijst = ServiceRef.GetTicketResponse(ticketNumber).ToList<TicketResponse>();

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(lijst.GetType());
            MemoryStream memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, lijst);
            string json = Encoding.Default.GetString(memoryStream.ToArray());

            return json ;
        }
    }
}