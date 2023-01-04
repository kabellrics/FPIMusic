using FPIMusic.DataAccess;
using FPIMusic.Models.Mediatheque;
using FPIMusic.Services.Scan.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Scan.Implémentation
{
    public class ScanMediatheque : IScanMediatheque
    {
        private IRepoUnit context;
        private ISettingService settings;

        public ScanMediatheque(IRepoUnit context, ISettingService settings)
        {
            this.settings = settings;
            this.context = context;
        }

        public async void Scan()
        {
            await SearchForMediathequeArtiste(settings.MediathequePath);
        }

        private async Task SearchForMediathequeArtiste(string mediathequePath)
        {
            var artfolders =  Directory.EnumerateDirectories(mediathequePath);
            foreach (var artfolder in artfolders)
            {
                if (File.Exists(Path.Combine(artfolder, "folder.jpg")))
                {
                    var directoryname = new DirectoryInfo(artfolder).Name;
                    if (context.MediathequeArtistes.Find(x=>x.Name == directoryname).Count() ==0)
                    {
                        MediathequeArtiste artiste = new MediathequeArtiste();
                        artiste.Name = directoryname;
                        artiste.Cover = Path.Combine(artfolder, "fanart.jpg");
                        artiste = context.MediathequeArtistes.Add(artiste);
                        await SearchForMediathequeAlbum(artiste);
                    }
                }
            }
        }

        private async Task SearchForMediathequeAlbum(MediathequeArtiste artiste)
        {
            var albfolders = Directory.EnumerateDirectories(Path.GetDirectoryName(artiste.Cover));
            foreach(var albfolder in albfolders)
            {
                if (File.Exists(Path.Combine( albfolder, "cover.jpg")))
                {
                    var directoryname = new DirectoryInfo(albfolder).Name;
                    if (context.MediathequeAlbums.Find(x => x.Name == directoryname).Count() == 0)
                    {
                        MediathequeAlbum album = new MediathequeAlbum();
                        album.Name = directoryname;
                        album.MediathequeArtisteID = artiste.Id;
                        album.Cover = Path.Combine( albfolder, "cover.jpg");
                        album = context.MediathequeAlbums.Add(album);
                        await SearchForMediathequeSong(artiste, album);
                    }
                }
            }
        }

        private async Task SearchForMediathequeSong(MediathequeArtiste artiste, MediathequeAlbum album)
        {
            var mp3files = Directory.EnumerateFiles(Path.GetDirectoryName(album.Cover), "*.mp3", SearchOption.TopDirectoryOnly);
            foreach (var mp3file in mp3files)
            {
                try
                {
                    var tfile = TagLib.File.Create(mp3file);
                    string title = tfile.Tag.Title;
                    uint Piste = tfile.Tag.Track;
                    MediathequeSong song = new MediathequeSong();
                    song.Artiste = artiste.Name;
                    song.Album = album.Name;
                    song.AlbumId = album.Id;
                    song.Piste = (int)Piste;
                    song.Title = title;
                    song.Cover = album.Cover;
                    song.Path = mp3file;
                    context.MediathequeSongs.Add(song);
                }
                catch(Exception ex) { }
            }
        }
    }
}
