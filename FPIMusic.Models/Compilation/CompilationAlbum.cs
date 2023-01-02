using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Models.Compilation
{
    public class CompilationAlbum : AutoPlaylistElement
    {
        public string Cover { get; set; }
        public CompilationAlbum() { AutoPlaylistElementType = AutoPlaylistElementType.CompilationAlbum; }
    }
}
