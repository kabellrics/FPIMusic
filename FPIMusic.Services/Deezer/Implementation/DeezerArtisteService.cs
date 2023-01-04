using FPIMusic.DataAccess;
using FPIMusic.Models.Deezer;
using FPIMusic.Services.Deezer.ExtendeObject;
using FPIMusic.Services.Deezer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Deezer.Implementation
{
    public class DeezerArtisteService : IDeezerArtisteService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public DeezerArtisteService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
        private DeezerExtendedArtiste CreateExtended(DeezerArtiste art)
        {
            DeezerExtendedArtiste extart = (DeezerExtendedArtiste)art;
            var songs = context.DeezerSongs.Find(x => x.AlbumId == extart.Id);
            extart.NbSong = songs.Count();
            extart.NbAlbum = songs.GroupBy(x => x.AlbumId).Count();
            extart.NbPlaylist = songs.GroupBy(x => x.PlaylistId).Count();
            return extart;
        }
        public DeezerExtendedArtiste GetById(int id)
        {
            return CreateExtended(context.DeezerArtistes.GetById(id));
        }
        public IEnumerable<DeezerExtendedArtiste> GetByName(string name)
        {
            return context.DeezerArtistes.Find(x => x.Name.Contains(name)).Select(x => CreateExtended(x));
        }
        public IEnumerable<DeezerExtendedArtiste> GetAll()
        {
            return context.DeezerArtistes.GetAll().Select(x => CreateExtended(x));
        }
        public IEnumerable<IGrouping<char, DeezerExtendedArtiste>> GetGrouped()
        {
            var albs = context.DeezerArtistes.GetAll();
            return from alb in albs
                   group CreateExtended(alb) by alb.Name[0];
        }
    }
}
