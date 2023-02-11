using FPIMusic.DataAccess;
using FPIMusic.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Player
{
    public class PlayerService
    {
        private IRepoUnit context;
        private PlayerCurrentList PlayerCurrentList;
        public PlayerService(IRepoUnit context)
        {
            this.context = context;
            PlayerCurrentList = new PlayerCurrentList();
        }
    }
}
