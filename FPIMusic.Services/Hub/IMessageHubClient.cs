using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Hub
{
    public interface IMessageHubClient
    {
        Task SendSynchroToClient(String message);
    }
}
