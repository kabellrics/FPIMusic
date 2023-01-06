using FPIMusic.DataAccess;
using FPIMusic.Models.Deezer;
using FPIMusic.Models.Mediatheque;
using FPIMusic.Services.Deezer.ExtendeObject;
using FPIMusic.Services.Mediatheque.ExtendedObject;
using FPIMusic.Services.Mediatheque.Interface;
using FPIMusic.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Mediatheque.Implementation
{
    public class MediaAlbumService : IMediaAlbumService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public MediaAlbumService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
        private MediaExtendedAlbum CreateExtended(MediathequeAlbum art)
        {
            MediaExtendedAlbum extart = new MediaExtendedAlbum();//(MediaExtendedAlbum)art;
            extart.MediathequeArtisteID = art.MediathequeArtisteID;
            extart.Cover = art.Cover;
            extart.AutoPlaylistElementType = art.AutoPlaylistElementType;
            extart.Id = art.Id;
            extart.Name = art.Name;
            extart.NbSong = context.MediathequeSongs.Find(x => x.AlbumId == extart.Id).Count();
            return extart;
        }
        public MediaExtendedAlbum GetById(int id)
        {
            return CreateExtended(context.MediathequeAlbums.GetById(id));
        }
        public MediaExtendedAlbum Update(MediathequeAlbum item)
        {
            return CreateExtended(context.MediathequeAlbums.Save(item));
        }
        public IEnumerable<MediaExtendedAlbum> GetByArtiste(int id)
        {
            return context.MediathequeAlbums.Find(x => x.MediathequeArtisteID == id).Select(x => CreateExtended(x));
        }
        public IEnumerable<MediaExtendedAlbum> GetByName(string name)
        {
            return context.MediathequeAlbums.Find(x => x.Name.Contains(name)).Select(x => CreateExtended(x));
        }
        public IEnumerable<MediaExtendedAlbum> GetAll()
        {
            return context.MediathequeAlbums.GetAll().Select(x => CreateExtended(x));
        }
        public IEnumerable<IGrouping<char, MediaExtendedAlbum>> GetGrouped()
        {
            var albs = context.MediathequeAlbums.GetAll();
            return from alb in albs
                   group CreateExtended(alb) by alb.Name[0];
        }
    }
}
