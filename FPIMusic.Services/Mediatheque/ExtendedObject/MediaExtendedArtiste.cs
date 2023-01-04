using FPIMusic.Models.Mediatheque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Mediatheque.ExtendedObject
{
    public class MediaExtendedArtiste:MediathequeArtiste
    {
        public int NbSong { get; set; }
        public int NbAlbum { get; set; }
    }
}
