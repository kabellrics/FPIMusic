using FPIMusic.DataAccess;
using FPIMusic.Models.Compilation;
using FPIMusic.Services.Compilation.ExtendedObject;
using FPIMusic.Services.Compilation.Interface;
using FPIMusic.Services.Deezer.ExtendeObject;
using FPIMusic.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Compilation.Implementation
{
    public class CompilArtisteService : ICompilArtisteService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public CompilArtisteService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
        private CompilExtendedArtiste CreateExtended(CompilationArtiste alb)
        {
            CompilExtendedArtiste extalb = new CompilExtendedArtiste();// (CompilExtendedArtiste)alb;
            extalb.Name = alb.Name;
            extalb.Id = alb.Id;
            extalb.AutoPlaylistElementType = alb.AutoPlaylistElementType;
            extalb.Cover = alb.Cover;
            var songs = context.CompilationSongs.Find(x => x.ArtisteId == extalb.Id);
            extalb.NbSong = songs.Count();
            extalb.NbAlbum = songs.GroupBy(x => x.AlbumId).Count();
            return extalb;
        }
        public CompilExtendedArtiste Update(CompilationArtiste item)
        {
            return CreateExtended(context.CompilationArtistes.Save(item));
        }
        public CompilExtendedArtiste GetById(int id)
        {
            return CreateExtended(context.CompilationArtistes.GetById(id));
        }
        public IEnumerable<CompilExtendedArtiste> GetByName(string name)
        {
            return context.CompilationArtistes.Find(x => x.Name.Contains(name)).Select(x => CreateExtended(x));
        }
        public IEnumerable<CompilExtendedArtiste> GetAll()
        {
            return context.CompilationArtistes.GetAll().Select(x => CreateExtended(x));
        }
        public IEnumerable<GroupedCompilExtendedArtiste> GetGrouped()
        {
            var arts = context.CompilationArtistes.GetAll();
            return arts.Select(x => CreateExtended(x)).GroupBy(x => x.Name[0])
                .Select(x => new GroupedCompilExtendedArtiste { Key = x.Key.ToString().ToUpper(), Items = x.ToList() });
        }
    }
}
