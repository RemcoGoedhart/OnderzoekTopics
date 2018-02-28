using Microsoft.AspNet.SignalR;
namespace SupportCenter.Hubs
{
        public class ChatHub : Hub
        {
            public void Send(string name, string message)
            {
                Clients.All.addNewMessageToPage(name, message);
            }

        }

}