using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Hub
{
    public class MessageHub : Hub<IMessageHubClient>
    {
        public async Task SendSynchroToClient(String message)
        {
            await Clients.All.SendSynchroToClient(message);
        }
    }
}
