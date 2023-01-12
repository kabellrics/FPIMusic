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
            DeezerExtendedArtiste extart = new DeezerExtendedArtiste();// (DeezerExtendedArtiste)art;
            extart.AutoPlaylistElementType = art.AutoPlaylistElementType;
            extart.Cover = art.Cover;
            extart.Name = art.Name;
            extart.Id = art.Id;
            var songs = context.DeezerSongs.Find(x => x.AlbumId == extart.Id);
            extart.NbSong = songs.Count();
            extart.NbAlbum = songs.GroupBy(x => x.AlbumId).Count();
            extart.NbPlaylist = songs.GroupBy(x => x.PlaylistId).Count();
            return extart;
        }
        public DeezerExtendedArtiste Update(DeezerArtiste item)
        {
            return CreateExtended(context.DeezerArtistes.Save(item));
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
        public IEnumerable<DeezerExtendedArtiste> GetMostSongArtiste()
        {
            return GetAll().OrderByDescending(x=>x.NbSong).ThenByDescending(x => x.NbPlaylist).ThenByDescending(x => x.NbAlbum).Take(3);
        }
        public IEnumerable<DeezerExtendedArtiste> GetMostPlaylistArtiste()
        {
            return GetAll().OrderByDescending(x=>x.NbPlaylist).ThenByDescending(x => x.NbSong).ThenByDescending(x => x.NbPlaylist).Take(3);
        }
        public IEnumerable<DeezerExtendedArtiste> GetMostAlbumArtiste()
        {
            return GetAll().OrderByDescending(x=>x.NbAlbum).ThenByDescending(x => x.NbPlaylist).ThenByDescending(x => x.NbSong).Take(3);
        }
        public IEnumerable<GroupedDeezerExtendedArtiste> GetGrouped()
        {
            var albs = context.DeezerArtistes.GetAll();
            return albs.Select(x => CreateExtended(x)).GroupBy(x => x.Name[0])
                .Select(x => new GroupedDeezerExtendedArtiste { Key = x.Key.ToString().ToUpper(), Items = x.ToList().OrderBy(x => x.Name) }).OrderBy(x => x.Key);
        }
    }
}
