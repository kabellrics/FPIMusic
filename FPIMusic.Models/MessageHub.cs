using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Models
{
    public class MessageHub : Microsoft.AspNetCore.SignalR.Hub //Hub<IMessageHubClient>
    {
        //public async Task SendSynchroToClient(String message)
        //{
        //    await Clients.All.SendSynchroToClient(message);
        //}
        public async Task SendMessage(string message)
        => await Clients.All.SendAsync("Synchro", message);
    }
}
