using FPIMusic.Models.Compilation;
using FPIMusic.Services.Mediatheque.ExtendedObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Compilation.ExtendedObject
{
    public class CompilExtendedArtiste:CompilationArtiste
    {
        public int NbSong { get; set; }
        public int NbAlbum { get; set; }
    }
    public class GroupedCompilExtendedArtiste
    {
        public string Key { get; set; }
        public IEnumerable<CompilExtendedArtiste> Items { get; set; }
    }
}
