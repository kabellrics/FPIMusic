using FPIMusic.Services.Compilation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Compilation
{
    public class ICompilationService
    {
        ICompilAlbumService Albums { get; }
        ICompilArtisteService Artistes { get; }
        ICompilSongService Song { get; }
    }
}
