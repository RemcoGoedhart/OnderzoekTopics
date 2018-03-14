using SC.BL.Domain;
using SC.UI.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SC.UI.Web.MVC.Controllers
{
    public class TicketResponseController : Controller
    {
        // GET: TicketResponse
        //ServiceReference1.Service1Client ServiceRef = new ServiceReference1.Service1Client();

        public string Get(int ticketNumber)
        {
            WebRequest request = WebRequest.Create("http://localhost:50176/Service1.svc/GetTicketResponse?ticketNumber=" + ticketNumber);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            return responseFromServer;

            /*voor de datum aan te passen for (int i = 0; i < lijst.Count; i++)
            {
                lijst[i].Date = lijst[i].Date;
            }
            */
        }

        public string Post(ServiceReference1.NewTicketResponseDTO response)
        {
            string json = new JavaScriptSerializer().Serialize(response);
            Debug.Write("HALLO");
            Debug.Write(json);

            ASCIIEncoding encoding = new ASCIIEncoding();
           
            byte[] jsonRequest = encoding.GetBytes(json);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:50176/Service1.svc/AddResponse");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = jsonRequest.Length;
            Stream newStream = webRequest.GetRequestStream();
            newStream.Write(jsonRequest, 0, jsonRequest.Length);
            newStream.Close();

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream dataStream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            return responseFromServer;


            /*
            WebRequest request = WebRequest.Create()
            return Json(ServiceRef.AddResponse(response));*/
        }
    }
}