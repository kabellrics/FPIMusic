using FPIMusic.Services.Deezer.Interface;
using FPIMusic.Services.Mediatheque.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Deezer
{
    public interface IDeezerService
    {
        IDeezerAlbumService Albums { get; }
        IDeezerArtisteService Artistes { get; }
        IDeezerPlaylistService Playlists { get; }
        IDeezerSongService Songs { get; }
    }
}
