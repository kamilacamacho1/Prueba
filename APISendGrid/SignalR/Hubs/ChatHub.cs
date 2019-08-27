using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
    public class ChatHub: Hub
    {
        public static List<Client> connectedUser { get; set; }  = new List<Client>();

        public void Connect (string userName)
        {
            Client c = new Client()
            {
                UserName = userName,
                ID = Context.ConnectionId

            };

            connectedUser.Add(c);

            Clients.All.updateUsers(connectedUser.Count(), connectedUser.Select(u => u.UserName));
        }

        public void Send(string message)
        {
            var sender = connectedUser.First(u => u.ID.Equals(Context.ConnectionId));
            Clients.All.broadcastMessage(sender.UserName, message);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var disconnect = connectedUser.FirstOrDefault(c => c.ID.Equals(Context.ConnectionId));
            connectedUser.Remove(disconnect);
            Clients.All.updateUsers(connectedUser.Count(), connectedUser.Select(u => u.UserName));

            return base.OnDisconnected(stopCalled); 
        }

    }

    public class Client
    {
        public string UserName { get; set; }
        public string ID { get; set; }
    }
}