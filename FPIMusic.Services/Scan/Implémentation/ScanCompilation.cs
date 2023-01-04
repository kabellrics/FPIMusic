using FPIMusic.DataAccess;
using FPIMusic.Models.Compilation;
using FPIMusic.Services.Scan.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Scan.Implémentation
{
    public class ScanCompilation : IScanCompilation
    {
        private IRepoUnit context;
        private ISettingService settings;

        public ScanCompilation(IRepoUnit context, ISettingService settings)
        {
            this.settings = settings;
            this.context = context;
        }
        public async void Scan()
        {
            if (!Directory.Exists(Path.Combine(settings.CompilationPath, "ArtistCover")))
            {
                Directory.CreateDirectory(Path.Combine(settings.CompilationPath, "ArtistCover"));
            }
            if (!Directory.Exists(Path.Combine(settings.CompilationPath, "AlbumCover")))
            {
                Directory.CreateDirectory(Path.Combine(settings.CompilationPath, "AlbumCover"));
            }
            await SearchForCompilation(settings.CompilationPath);
        }

        private async Task SearchForCompilation(string compilationPath)
        {
            var compilfolders = Directory.EnumerateDirectories(compilationPath);
            foreach (var compilfolder in compilfolders)
            {
                await GetDataInCompilFolder(compilfolder);
            }
        }

        private async Task GetDataInCompilFolder(string compilfolder)
        {
            var mp3files = Directory.EnumerateFiles(compilfolder, "*.mp3", SearchOption.TopDirectoryOnly);
            foreach (var mp3file in mp3files)
            {
                try
                {
                    var tfile = TagLib.File.Create(mp3file);
                    string title = tfile.Tag.Title;
                    uint Piste = tfile.Tag.Track;
                    string albumname = tfile.Tag.Album;
                    string artistename = string.Join(", ", tfile.Tag.AlbumArtists);
                    CompilationArtiste artiste = await GetArtiste(artistename);
                    CompilationAlbum album = await GetAlbum(albumname, compilfolder);
                    CompilationSong song = new CompilationSong();
                    song.Album = album.Name;
                    song.AlbumId = album.Id;
                    song.ArtisteId = artiste.Id;
                    song.Artiste = artiste.Name;
                    song.Piste = (int)Piste;
                    song.Path = mp3file;
                    song.Title = title;
                    song.Cover = album.Cover;
                    context.CompilationSongs.Add(song);
                }
                catch (Exception ex) { }
            }
        }

        private async Task<CompilationAlbum> GetAlbum(string albumname, string compilfolder)
        {
            var alb = context.CompilationAlbums.Find(x => x.Name == albumname);
            if (alb != null)
                return alb.FirstOrDefault();
            else
            {
                CompilationAlbum album = new CompilationAlbum();
                album.Name = albumname;
                album.Cover = Path.Combine(Path.Combine(settings.CompilationPath, "AlbumCover"), "cover.jpg");
                album = context.CompilationAlbums.Add(album);
                return album;
            }
        }

        private async Task<CompilationArtiste> GetArtiste(string artistename)
        {
            var art = context.CompilationArtistes.Find(x => x.Name == artistename);
            if (art != null)
                return art.FirstOrDefault();
            else
            {
                CompilationArtiste artiste = new CompilationArtiste();
                artiste.Name = artistename;
                artiste = context.CompilationArtistes.Add(artiste);
                return artiste;
            }
        }
    }
}
