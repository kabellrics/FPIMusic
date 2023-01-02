using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Models.Deezer
{
    public class DeezerAlbum : AutoPlaylistElement
    {
        public string Cover { get; set; }
        public DeezerAlbum() { AutoPlaylistElementType = AutoPlaylistElementType.DeezerAlbum; }
    }
}
