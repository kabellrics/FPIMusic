﻿using FPIMusic.DataAccess;
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
    public class MediaArtisteService : IMediaArtisteService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public MediaArtisteService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
        private MediaExtendedArtiste CreateExtended(MediathequeArtiste art)
        {
            MediaExtendedArtiste extart = new MediaExtendedArtiste(); // (MediaExtendedArtiste)art;
            extart.Id = art.Id;
            extart.AutoPlaylistElementType = art.AutoPlaylistElementType;
            extart.Cover = art.Cover;
            extart.Name = art.Name;
            var albs = context.MediathequeAlbums.Find(x => x.MediathequeArtisteID == extart.Id);
            extart.NbAlbum = albs.Count();
            extart.NbSong = context.MediathequeSongs.Find(x=> albs.Select(x=>x.Id).Contains(x.AlbumId)).Count();
            return extart;
        }
        public MediaExtendedArtiste Update(MediathequeArtiste item)
        {
            return CreateExtended(context.MediathequeArtistes.Save(item));
        }
        public MediaExtendedArtiste GetById(int id)
        {
            return CreateExtended(context.MediathequeArtistes.GetById(id));
        }
        public IEnumerable<MediaExtendedArtiste> GetByName(string name)
        {
            return context.MediathequeArtistes.Find(x => x.Name.Contains(name)).Select(x => CreateExtended(x));
        }
        public IEnumerable<MediaExtendedArtiste> GetAll()
        {
            return context.MediathequeArtistes.GetAll().Select(x => CreateExtended(x));
        }
        public IEnumerable<GroupedMediaExtendedArtiste> GetGrouped()
        {
            var albs = context.MediathequeArtistes.GetAll();
            return albs.Select(x => CreateExtended(x)).GroupBy(x => x.Name[0])
                .Select(x => new GroupedMediaExtendedArtiste { Key = x.Key.ToString().ToUpper(), Items = x.ToList().OrderBy(x => x.Name) }).OrderBy(x=>x.Key);
        }
    }
}
