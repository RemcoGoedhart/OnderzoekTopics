using SC.BL.Domain;
using SC.UI.Web.MVC.Models;
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

        ServiceReference1.Service1Client ServiceRef = new ServiceReference1.Service1Client();
        public String Get(int ticketNumber)
        {

             List<TicketResponse> lijst = ServiceRef.GetTicketResponse(ticketNumber).ToList<TicketResponse>();
              
            /*voor de datum aan te passen for (int i = 0; i < lijst.Count; i++)
            {
                lijst[i].Date = lijst[i].Date;
            }
            */
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(lijst.GetType());
            MemoryStream memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, lijst);
            string json = Encoding.Default.GetString(memoryStream.ToArray());

            /* return Json(ServiceRef.GetTicketResponse(ticketNumber).ToList<TicketResponse>()); */
            return json;
        }                public JsonResult Post(ServiceReference1.NewTicketResponseDTO response)
        {
            return Json(ServiceRef.AddResponse(response));
        }        
    }
}