using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Models.Compilation
{
    public class CompilationArtiste : AutoPlaylistElement
    {
        public string Cover { get; set; }
        public CompilationArtiste() { AutoPlaylistElementType = AutoPlaylistElementType.CompilationArtiste; }
    }
}
