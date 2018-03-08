using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SC.UI.Web.MVC.Controllers
{
    public class TicketResponseController : Controller
    {
        // GET: TicketResponse
        public ActionResult Get(int ticketNumber)
        {
            ServiceReference1.Service1Client ServiceRef = new ServiceReference1.Service1Client();
            return View(ServiceRef.GetTicketResponse(ticketNumber));
        }
    }
}