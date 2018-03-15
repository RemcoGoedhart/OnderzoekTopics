using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SC.UI.Web.MVC.Controllers
{
    public class TicketResponseController : Controller
    {
        ServiceReference1.Service1Client ServiceRef = new ServiceReference1.Service1Client();
        public string Get(int ticketNumber)
        {
            WebRequest request = WebRequest.Create("http://localhost:50176/Service1.svc/GetTicketResponse?ticketNumber=" + ticketNumber);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            return responseFromServer;
        }

        public string Post(ServiceReference1.NewTicketResponseDTO response)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            string json = new JavaScriptSerializer().Serialize(response);
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
        }
    }
}