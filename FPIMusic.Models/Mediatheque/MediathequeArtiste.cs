using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Models.Mediatheque
{
    public class MediathequeArtiste : AutoPlaylistElement
    {
        public string Cover { get; set; }
        public MediathequeArtiste() { AutoPlaylistElementType = AutoPlaylistElementType.MediathequeArtiste; }
    }
}
