using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Models.Deezer
{
    public class DeezerSong:Song
    {
        public DeezerSong() { SongType = SongType.Deezer; }
        public int ArtisteId { get; set; }
        public int AlbumId { get; set; }
        public int PlaylistId { get; set; }
    }
}
