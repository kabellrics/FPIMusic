using FPIMusic.DataAccess;
using FPIMusic.Models.Compilation;
using FPIMusic.Models.Deezer;
using FPIMusic.Services.Scan.Interface;
using FPIMusic.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Scan.Implémentation
{
    public class ScanDeezer : IScanDeezer
    {
        private IRepoUnit context;
        private ISettingService settings;

        public ScanDeezer(IRepoUnit context, ISettingService settings)
        {
            this.settings = settings;
            this.context = context;
        }
        public async void Scan()
        {
            if (!Directory.Exists(Path.Combine(settings.DeezerPath.Value, "AlbumCover")))
            {
                Directory.CreateDirectory(Path.Combine(settings.DeezerPath.Value, "AlbumCover"));
            }
            if (!Directory.Exists(Path.Combine(settings.DeezerPath.Value, "ArtistCover")))
            {
                Directory.CreateDirectory(Path.Combine(settings.DeezerPath.Value, "ArtistCover"));
            }
            await SearchForDeezer(settings.DeezerPath.Value);
        }
        public async void Clean()
        {
            var songs = context.DeezerSongs.GetAll();
            foreach (var song in songs)
            {
                if (!File.Exists(song.Path))
                {
                    context.DeezerSongs.Remove(song);
                }
            }
            var albs = context.DeezerAlbums.GetAll();
            foreach (var alb in albs)
            {
                var sg = context.DeezerSongs.Find(x => x.AlbumId == alb.Id);
                if (sg == null || sg.Count() == 0)
                {
                    context.DeezerAlbums.Remove(alb);
                }
            }
            var arts = context.DeezerArtistes.GetAll();
            foreach (var art in arts)
            {
                var sg = context.DeezerSongs.Find(x => x.ArtisteId == art.Id);
                if (sg == null || sg.Count() == 0)
                {
                    context.DeezerArtistes.Remove(art);
                }
            }
            var plays = context.DeezerPlaylists.GetAll();
            foreach (var play in plays)
            {
                var sg = context.DeezerSongs.Find(x => x.PlaylistId == play.Id);
                if (sg == null || sg.Count() == 0)
                {
                    context.DeezerPlaylists.Remove(play);
                }
            }
        }
        private async Task SearchForDeezer(string deezerPath)
        {
            var compilfolders = Directory.EnumerateDirectories(deezerPath);
            foreach (var compilfolder in compilfolders)
            {
                await GetDataInDeezerPlaylistFolder(compilfolder);
            }
        }

        private async Task GetDataInDeezerPlaylistFolder(string compilfolder)
        {
            var mp3files = Directory.EnumerateFiles(compilfolder, "*.mp3", SearchOption.AllDirectories);
            var artfolderfiles = Directory.EnumerateFiles(compilfolder, "folder.jpg", SearchOption.AllDirectories);
            foreach (var mp3file in mp3files)
            {
                try
                {
                    var tfile = TagLib.File.Create(mp3file);
                    string title = tfile.Tag.Title;
                    uint Piste = tfile.Tag.Track;
                    string albumname = tfile.Tag.Album;
                    string artistename = tfile.Tag.AlbumArtists.First() == "Various Artists" || string.IsNullOrEmpty(tfile.Tag.AlbumArtists.First()) ? tfile.Tag.FirstPerformer : tfile.Tag.AlbumArtists.First();
                    DeezerArtiste artiste = await GetArtiste(artistename, artfolderfiles);
                    DeezerAlbum album = await GetAlbum(albumname, tfile, compilfolder);
                    DeezerPlaylist playlist = await GetPlaylist(albumname, compilfolder);
                    DeezerSong song = new DeezerSong();
                    song.Album = album.Name;
                    song.AlbumId = album.Id;
                    song.ArtisteId = artiste.Id;
                    song.Artiste = artiste.Name;
                    song.PlaylistId = playlist.Id;
                    song.Piste = (int)Piste;
                    song.Path = mp3file;
                    song.Title = title;
                    song.Cover = album.Cover;
                    context.DeezerSongs.Add(song);
                }
                catch (Exception ex) { }
            }
        }

        private async Task<DeezerArtiste> GetArtiste(string artistename,IEnumerable<string> artfolderfiles)
        {
            var art = context.DeezerArtistes.Find(x => x.Name == artistename);
            if (art != null)
                return art.FirstOrDefault();
            else
            {
                DeezerArtiste artiste = new DeezerArtiste();
                artiste.Name = artistename;
                var folderpath = artfolderfiles.FirstOrDefault(x => x.Contains(Path.Combine(artiste.Name,"folder.jpg")));
                if(!string.IsNullOrEmpty(folderpath))
                {
                    var SourceCover = folderpath;
                    var DestCover = Path.Combine(Path.Combine(settings.DeezerPath.Value, "ArtistCover"), $"{artistename}.jpg");
                    File.Copy(SourceCover, DestCover, true);
                    artiste.Cover = DestCover;
                }
                artiste = context.DeezerArtistes.Add(artiste);
                return artiste;
            }
        }

        private async Task<DeezerAlbum> GetAlbum(string albumname, TagLib.File tfile, string compilfolder)
        {
            var art = context.DeezerAlbums.Find(x => x.Name == albumname);
            if (art != null)
                return art.FirstOrDefault();
            else
            {
                DeezerAlbum album = new DeezerAlbum();
                if (tfile.Tag.Pictures.Length > 0)
                {
                    try
                    {
                        var bin = (byte[])(tfile.Tag.Pictures[0].Data.Data);
                        var albcoverDestination = Path.Combine(Path.Combine(settings.DeezerPath.Value, "AlbumCover"), $"{albumname}.jpg");
                        File.WriteAllBytes(albcoverDestination, bin);
                        album.Cover = albcoverDestination;
                    }
                    catch (Exception ex)
                    {
                        //throw;
                    }
                }
                album.Name = albumname;
                album = context.DeezerAlbums.Add(album);
                return album;
            }
        }

        private async Task<DeezerPlaylist> GetPlaylist(string playlistname, string compilfolder)
        {
            var alb = context.DeezerPlaylists.Find(x => x.Name == playlistname);
            if (alb != null)
                return alb.FirstOrDefault();
            else
            {
                DeezerPlaylist playlist = new DeezerPlaylist();
                playlist.Name = playlistname;
                playlist.Cover = Path.Combine(compilfolder, "cover.jpg");
                playlist = context.DeezerPlaylists.Add(playlist);
                return playlist;
            }
        }
    }
}
