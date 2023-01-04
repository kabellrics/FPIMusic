using FPIMusic.Models.Deezer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Deezer.ExtendeObject
{
    public class DeezerExtendedArtiste:DeezerArtiste
    {
        public int NbSong { get; set; }
        public int NbAlbum { get; set; }
        public int NbPlaylist { get; set; }
    }
}
