using FPIMusic.Models.Mediatheque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Mediatheque.Interface
{
    public interface IMediaSongService
    {
        MediathequeSong GetById(int id);
        IEnumerable<MediathequeSong> GetByAlbumId(int id);
    }
}
