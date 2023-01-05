using FPIMusic.Models.Compilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Compilation.Interface
{
    public interface ICompilSongService
    {
        CompilationSong Update(CompilationSong item);
        CompilationSong GetById(int id);
        IEnumerable<CompilationSong> GetByArtisteId(int id);
        IEnumerable<CompilationSong> GetByAlbumId(int id);
    }
}
