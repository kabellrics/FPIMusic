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
    public class DeezerAlbumService : IDeezerAlbumService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public DeezerAlbumService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
        private DeezerExtendedAlbum CreateExtended(DeezerAlbum alb)
        {
            DeezerExtendedAlbum extalb = new DeezerExtendedAlbum();// (DeezerExtendedAlbum)alb;
            extalb.AutoPlaylistElementType = alb.AutoPlaylistElementType;
            extalb.Cover = alb.Cover;
            extalb.Id = alb.Id;
            extalb.Name= alb.Name;
            var songs = context.DeezerSongs.Find(x => x.AlbumId == extalb.Id);
            extalb.NbSong = songs.Count();
            extalb.NbArtiste = songs.GroupBy(x => x.ArtisteId).Count();
            extalb.NbPlaylist = songs.GroupBy(x => x.PlaylistId).Count();
            return extalb;
        }
        public DeezerExtendedAlbum Update(DeezerAlbum item)
        {
            return CreateExtended(context.DeezerAlbums.Save(item));
        }
        public DeezerExtendedAlbum GetById(int id)
        {
            return CreateExtended(context.DeezerAlbums.GetById(id));
        }
        public IEnumerable<DeezerExtendedAlbum> GetByName(string name)
        {
            return context.DeezerAlbums.Find(x => x.Name.Contains(name)).Select(x => CreateExtended(x));
        }
        public IEnumerable<DeezerExtendedAlbum> GetAll()
        {
            return context.DeezerAlbums.GetAll().Select(x => CreateExtended(x));
        }
        public IEnumerable<GroupedDeezerExtendedAlbum> GetGrouped()
        {
            var albs = context.DeezerAlbums.GetAll();
            return albs.Select(x => CreateExtended(x)).GroupBy(x => char.IsLetterOrDigit(x.Name[0]) ? char.IsNumber(x.Name[0]) ? "0..9" : x.Name[0].ToString().ToUpper() : "@..#")
                .Select(x => new GroupedDeezerExtendedAlbum { Key = x.Key.ToString().ToUpper(), Items = x.ToList().OrderBy(x => x.Name) }).OrderBy(x => x.Key);
        }
    }
}
