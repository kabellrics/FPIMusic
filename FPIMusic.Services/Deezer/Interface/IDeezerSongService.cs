using FPIMusic.Models.Deezer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Deezer.Interface
{
    public interface IDeezerSongService
    {
        DeezerSong Update(DeezerSong item);
        DeezerSong GetById(int id);
        IEnumerable<DeezerSong> GetByArtisteId(int id);
        IEnumerable<DeezerSong> GetByAlbumId(int id);
    }
}
