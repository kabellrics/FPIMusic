using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.DataAccess
{
    public interface IRepoUnit: IDisposable
    {
        ICompilationAlbumRepository CompilationAlbums { get; }
        ICompilationArtisteRepository CompilationArtistes { get; }
        ICompilationSongRepository CompilationSongs { get; }
        IMediathequeAlbumRepository MediathequeAlbums { get; }
        IMediathequeArtisteRepository MediathequeArtistes { get; }
        IMediathequeSongRepository MediathequeSongs { get; }
        IDeezerAlbumRepository DeezerAlbums { get; }
        IDeezerArtisteRepository DeezerArtistes { get; }
        IDeezerSongRepository DeezerSongs { get; }
        IDeezerPlaylistRepository DeezerPlaylists { get; }
        int Complete();
    }
}
