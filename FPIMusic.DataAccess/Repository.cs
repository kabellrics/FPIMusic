using FPIMusic.Models.Compilation;
using FPIMusic.Models.Deezer;
using FPIMusic.Models.Mediatheque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.DataAccess
{
    internal class Repository
    {
    }
    public class CompilationAlbumRepository : GenericRepository<CompilationAlbum>, ICompilationAlbumRepository
    {
        public CompilationAlbumRepository(FPIMusicRepository context) : base(context)
        {
        }
    }
    public class CompilationArtisteRepository : GenericRepository<CompilationArtiste>, ICompilationArtisteRepository
    {
        public CompilationArtisteRepository(FPIMusicRepository context) : base(context)
        {
        }
    }
    public class CompilationSongRepository : GenericRepository<CompilationSong>, ICompilationSongRepository
    {
        public CompilationSongRepository(FPIMusicRepository context) : base(context)
        {
        }
    }
    public class MediathequeAlbumRepository : GenericRepository<MediathequeAlbum>, IMediathequeAlbumRepository
    {
        public MediathequeAlbumRepository(FPIMusicRepository context) : base(context)
        {
        }
    }
    public class MediathequeArtisteRepository : GenericRepository<MediathequeArtiste>, IMediathequeArtisteRepository
    {
        public MediathequeArtisteRepository(FPIMusicRepository context) : base(context)
        {
        }
    }
    public class MediathequeSongRepository : GenericRepository<MediathequeSong>, IMediathequeSongRepository
    {
        public MediathequeSongRepository(FPIMusicRepository context) : base(context)
        {
        }
    }
    public class DeezerAlbumRepository : GenericRepository<DeezerAlbum>, IDeezerAlbumRepository
    {
        public DeezerAlbumRepository(FPIMusicRepository context) : base(context)
        {
        }
    }
    public class DeezerArtisteRepository : GenericRepository<DeezerArtiste>, IDeezerArtisteRepository
    {
        public DeezerArtisteRepository(FPIMusicRepository context) : base(context)
        {
        }
    }
    public class DeezerSongRepository : GenericRepository<DeezerSong>, IDeezerSongRepository
    {
        public DeezerSongRepository(FPIMusicRepository context) : base(context)
        {
        }
    }
    public class DeezerPlaylistRepository : GenericRepository<DeezerPlaylist>, IDeezerPlaylistRepository
    {
        public DeezerPlaylistRepository(FPIMusicRepository context) : base(context)
        {
        }
    }
}
