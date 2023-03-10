using FPIMusic.Models.Mediatheque;
using FPIMusic.Services.Mediatheque.ExtendedObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Mediatheque.Interface
{
    public interface IMediaAlbumService
    {
        MediaExtendedAlbum Update(MediathequeAlbum item);
        MediaExtendedAlbum GetById(int id);
        IEnumerable<MediaExtendedAlbum> GetByArtiste(int id);
        IEnumerable<MediaExtendedAlbum> GetByName(string name);
        IEnumerable<MediaExtendedAlbum> GetAll();
        IEnumerable<GroupedMediaExtendedAlbum> GetGrouped();
    }
}
