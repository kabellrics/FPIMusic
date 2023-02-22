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
        public override async Task OnConnectedAsync()
        {
            await this.SendMessage("Sync");
            await base.OnConnectedAsync();
        }
        public async Task SendMessage(string message)
        => await Clients.All.SendAsync("Synchro", message);
    }
}
