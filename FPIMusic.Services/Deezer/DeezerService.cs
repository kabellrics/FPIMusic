using FPIMusic.DataAccess;
using FPIMusic.Services.Compilation.Implementation;
using FPIMusic.Services.Deezer.Implementation;
using FPIMusic.Services.Deezer.Interface;
using FPIMusic.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Deezer
{
    public class DeezerService : IDeezerService
    {
        private readonly IRepoUnit _context;
        private readonly ISettingService _settings;
        public DeezerService(IRepoUnit context, ISettingService settings)
        {
            _context = context;
            _settings = settings;
            Albums = new DeezerAlbumService(_context, _settings);
            Artistes = new DeezerArtisteService(_context, _settings);
            Playlists = new DeezerPlaylistService(_context, _settings);
            Songs = new DeezerSongService(_context, _settings);
        }
        public IDeezerAlbumService Albums { get; private set; }

        public IDeezerArtisteService Artistes { get; private set; }

        public IDeezerPlaylistService Playlists { get; private set; }

        public IDeezerSongService Songs { get; private set; }
    }
}
