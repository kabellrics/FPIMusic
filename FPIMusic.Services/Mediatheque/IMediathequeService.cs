using FPIMusic.Services.Compilation.Interface;
using FPIMusic.Services.Mediatheque.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Mediatheque
{
    public interface IMediathequeService
    {
        IMediaAlbumService Albums { get; }
        IMediaArtisteService Artistes { get; }
        IMediaSongService Song { get; }
    }
}
