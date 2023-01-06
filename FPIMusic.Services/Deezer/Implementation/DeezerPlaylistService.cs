using FPIMusic.DataAccess;
using FPIMusic.Models.Compilation;
using FPIMusic.Models.Deezer;
using FPIMusic.Services.Compilation.ExtendedObject;
using FPIMusic.Services.Deezer.ExtendeObject;
using FPIMusic.Services.Deezer.Interface;
using FPIMusic.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Deezer.Implementation
{
    public class DeezerPlaylistService : IDeezerPlaylistService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public DeezerPlaylistService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
        private DeezerExtendedPlaylist CreateExtended(DeezerPlaylist art)
        {
            DeezerExtendedPlaylist extart = new DeezerExtendedPlaylist();// (DeezerExtendedPlaylist)art;
            extart.Name = art.Name;
            extart.Id = art.Id;
            extart.AutoPlaylistElementType = art.AutoPlaylistElementType;
            extart.Cover = art.Cover;
            var songs = context.DeezerSongs.Find(x => x.AlbumId == extart.Id);
            extart.NbSong = songs.Count();
            extart.NbAlbum = songs.GroupBy(x => x.AlbumId).Count();
            extart.NbArtiste = songs.GroupBy(x => x.ArtisteId).Count();
            return extart;
        }
        public DeezerExtendedPlaylist Update(DeezerPlaylist item)
        {
            return CreateExtended(context.DeezerPlaylists.Save(item));
        }
        public DeezerExtendedPlaylist GetById(int id)
        {
            return CreateExtended(context.DeezerPlaylists.GetById(id));
        }
        public IEnumerable<DeezerExtendedPlaylist> GetByName(string name)
        {
            return context.DeezerPlaylists.Find(x => x.Name.Contains(name)).Select(x => CreateExtended(x));
        }
        public IEnumerable<DeezerExtendedPlaylist> GetAll()
        {
            return context.DeezerPlaylists.GetAll().Select(x => CreateExtended(x));
        }
        public IEnumerable<IGrouping<char, DeezerExtendedPlaylist>> GetGrouped()
        {
            var albs = context.DeezerPlaylists.GetAll();
            return from alb in albs
                   group CreateExtended(alb) by alb.Name[0];
        }
    }
}
