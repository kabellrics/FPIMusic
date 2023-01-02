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
    internal interface IRepository
    {
    }
    public interface ICompilationAlbumRepository : IGenericRepository<CompilationAlbum>
    {
    }
    public interface ICompilationArtisteRepository : IGenericRepository<CompilationArtiste>
    {
    }
    public interface ICompilationSongRepository : IGenericRepository<CompilationSong>
    {
    }
    public interface IMediathequeAlbumRepository : IGenericRepository<MediathequeAlbum>
    {
    }
    public interface IMediathequeArtisteRepository : IGenericRepository<MediathequeArtiste>
    {
    }
    public interface IMediathequeSongRepository : IGenericRepository<MediathequeSong>
    {
    }
    public interface IDeezerAlbumRepository : IGenericRepository<DeezerAlbum>
    {
    }
    public interface IDeezerArtisteRepository : IGenericRepository<DeezerArtiste>
    {
    }
    public interface IDeezerSongRepository : IGenericRepository<DeezerSong>
    {
    }
    public interface IDeezerPlaylistRepository : IGenericRepository<DeezerPlaylist>
    {
    }
}
