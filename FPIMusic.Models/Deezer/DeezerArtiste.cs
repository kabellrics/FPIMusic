using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Models.Deezer
{
    public class DeezerArtiste : AutoPlaylistElement
    {
        public string Cover { get; set; }
        public DeezerArtiste() { AutoPlaylistElementType = AutoPlaylistElementType.DeezerArtiste; }
    }
}
