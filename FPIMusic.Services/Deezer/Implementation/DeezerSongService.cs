using FPIMusic.DataAccess;
using FPIMusic.Services.Deezer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Deezer.Implementation
{
    public class DeezerSongService : IDeezerSongService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public DeezerSongService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
    }
}
