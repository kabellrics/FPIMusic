﻿using FPIMusic.DataAccess;
using FPIMusic.Models.Compilation;
using FPIMusic.Services.Compilation.ExtendedObject;
using FPIMusic.Services.Compilation.Interface;
using FPIMusic.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FPIMusic.Services.Compilation.Implementation
{
    public class CompilAlbumService : ICompilAlbumService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public CompilAlbumService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
        private CompilExtendedAlbum CreateExtended(CompilationAlbum alb)
        {
            CompilExtendedAlbum extalb = new CompilExtendedAlbum();// (CompilExtendedAlbum)alb;
            extalb.Id = alb.Id;
            extalb.Name = alb.Name;
            extalb.Cover = alb.Cover;
            extalb.AutoPlaylistElementType = alb.AutoPlaylistElementType;
            var songs = context.CompilationSongs.Find(x => x.AlbumId == extalb.Id);
            extalb.NbSong = songs.Count();
            extalb.NbArtiste = songs.GroupBy(x=>x.ArtisteId).Count();
            return extalb;
        }
        public CompilExtendedAlbum Update(CompilationAlbum item)
        {
            return CreateExtended(context.CompilationAlbums.Save(item));
        }
        public CompilExtendedAlbum GetById(int id)
        {
            return CreateExtended(context.CompilationAlbums.GetById(id));
        }
        public IEnumerable<CompilExtendedAlbum> GetByName(string name)
        {
            return context.CompilationAlbums.Find(x => x.Name.Contains(name)).Select(x => CreateExtended(x));
        }
        public IEnumerable<CompilExtendedAlbum> GetAll()
        {
            return context.CompilationAlbums.GetAll().Select(x => CreateExtended(x));
        }
        public IEnumerable<IGrouping<char, CompilExtendedAlbum>> GetGrouped()
        {
            var albs = context.CompilationAlbums.GetAll();
            return from alb in albs
                   group CreateExtended(alb) by alb.Name[0];
        }
    }
}
