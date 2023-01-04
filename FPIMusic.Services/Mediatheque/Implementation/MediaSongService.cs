using FPIMusic.DataAccess;
using FPIMusic.Models.Compilation;
using FPIMusic.Models.Mediatheque;
using FPIMusic.Services.Mediatheque.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Mediatheque.Implementation
{
    public class MediaSongService : IMediaSongService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public MediaSongService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
        public MediathequeSong GetById(int id)
        {
            return context.MediathequeSongs.GetById(id);
        }
        public IEnumerable<MediathequeSong> GetByAlbumId(int id)
        {
            return context.MediathequeSongs.Find(x => x.AlbumId == id).OrderBy(x => x.Piste); ;
        }
    }
}
