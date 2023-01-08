using FPIMusic.Models.Compilation;
using FPIMusic.Services.Mediatheque.ExtendedObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Compilation.ExtendedObject
{
    public class CompilExtendedAlbum:CompilationAlbum
    {
        public int NbSong { get; set; }
        public int NbArtiste { get; set; }
    }
    public class GroupedCompilExtendedAlbum
    {
        public string Key { get; set; }
        public IEnumerable<CompilExtendedAlbum> Items { get; set; }
    }
}
