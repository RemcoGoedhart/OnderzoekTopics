using Microsoft.AspNet.SignalR;
namespace SupportCenter.Hubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(string message)
        {
            Clients.All.AddMessageOnPage(message);
        }
    }
}