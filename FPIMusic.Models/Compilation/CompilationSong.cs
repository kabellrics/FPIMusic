using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Models.Compilation
{
    public class CompilationSong:Song
    {
        public CompilationSong() { SongType = SongType.Compilation; }
        public int ArtisteId { get; set; }
        public int AlbumId { get; set; }
    }
}
