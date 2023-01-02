using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Models.Mediatheque
{
    public class MediathequeAlbum : AutoPlaylistElement
    {
        public string Cover { get; set; }
        public int MediathequeArtisteID { get; set; }
        public MediathequeAlbum() { AutoPlaylistElementType = AutoPlaylistElementType.MediathequeAlbum; }
    }
}
