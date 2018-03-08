using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SC.BL;
using SC.BL.Domain;

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
            Debug.WriteLine("HALLO");
            Debug.WriteLine(responses.ToList()[0].Text);
            Debug.WriteLine("HALLO");


            return (responses.ToList());
        }
    }
}
