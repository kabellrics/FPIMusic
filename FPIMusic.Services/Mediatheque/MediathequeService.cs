using FPIMusic.DataAccess;
using FPIMusic.Services.Deezer.Implementation;
using FPIMusic.Services.Mediatheque.Implementation;
using FPIMusic.Services.Mediatheque.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Mediatheque
{
    public class MediathequeService : IMediathequeService
    {
        private readonly IRepoUnit _context;
        private readonly ISettingService _settings;
        public MediathequeService(IRepoUnit context, ISettingService settings)
        {
            _context = context;
            _settings = settings;
            Albums = new MediaAlbumService(_context, _settings);
            Artistes = new MediaArtisteService(_context, _settings);
            Song = new MediaSongService(_context, _settings);
        }
        public IMediaAlbumService Albums { get; private set; }

        public IMediaArtisteService Artistes { get; private set; }

        public IMediaSongService Song { get; private set; }
    }
}
