using FPIMusic.DataAccess;
using FPIMusic.Services.Mediatheque.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Mediatheque.Implementation
{
    public class MediaAlbumService : IMediaAlbumService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public MediaAlbumService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
    }
}
