using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.DataAccess
{
    public class RepoUnit : IRepoUnit
    {
        private readonly FPIMusicRepository _context;
        public RepoUnit(FPIMusicRepository context)
        {
            _context = context;
            CompilationAlbums = new CompilationAlbumRepository(_context);
            CompilationArtistes = new CompilationArtisteRepository(_context);
            CompilationSongs = new CompilationSongRepository(_context);
            MediathequeAlbums = new MediathequeAlbumRepository(_context);
            MediathequeArtistes = new MediathequeArtisteRepository(_context);
            MediathequeSongs = new MediathequeSongRepository(_context);
            DeezerAlbums = new DeezerAlbumRepository(_context);
            DeezerArtistes = new DeezerArtisteRepository(_context);
            DeezerSongs = new DeezerSongRepository(_context);
            DeezerPlaylists = new DeezerPlaylistRepository(_context);
        }
        public ICompilationAlbumRepository CompilationAlbums { get; private set; }

        public ICompilationArtisteRepository CompilationArtistes { get; private set; }

        public ICompilationSongRepository CompilationSongs { get; private set; }

        public IMediathequeAlbumRepository MediathequeAlbums { get; private set; }

        public IMediathequeArtisteRepository MediathequeArtistes { get; private set; }

        public IMediathequeSongRepository MediathequeSongs { get; private set; }

        public IDeezerAlbumRepository DeezerAlbums { get; private set; }

        public IDeezerArtisteRepository DeezerArtistes { get; private set; }

        public IDeezerSongRepository DeezerSongs { get; private set; }

        public IDeezerPlaylistRepository DeezerPlaylists { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
