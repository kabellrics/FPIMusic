using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Models.Deezer
{
    public class DeezerPlaylist : AutoPlaylistElement
    {
        public string Cover { get; set; }
        public DeezerPlaylist() { AutoPlaylistElementType = AutoPlaylistElementType.DeezerPlaylist; }
    }
}
