using FPIMusic.DataAccess;
using FPIMusic.Models.Compilation;
using FPIMusic.Models.Deezer;
using FPIMusic.Services.Scan.Interface;
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
            await SearchForDeezer(settings.DeezerPath);
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
            var mp3files = Directory.EnumerateFiles(compilfolder, "*.mp3", SearchOption.TopDirectoryOnly);
            foreach (var mp3file in mp3files)
            {
                try
                {
                    var tfile = TagLib.File.Create(mp3file);
                    string title = tfile.Tag.Title;
                    uint Piste = tfile.Tag.Track;
                    string albumname = tfile.Tag.Album;
                    string artistename = tfile.Tag.AlbumArtists.First() == "Various Artists" || string.IsNullOrEmpty(tfile.Tag.AlbumArtists.First()) ? tfile.Tag.FirstPerformer : tfile.Tag.AlbumArtists.First();
                    DeezerArtiste artiste = await GetArtiste(artistename, compilfolder);
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
                    context.DeezerSongs.Add(song);
                }
                catch (Exception ex) { }
            }
        }

        private async Task<DeezerArtiste> GetArtiste(string artistename,string compilfolder)
        {
            var art = context.DeezerArtistes.Find(x => x.Name == artistename);
            if (art != null)
                return art.FirstOrDefault();
            else
            {
                DeezerArtiste artiste = new DeezerArtiste();
                artiste.Name = artistename;
                if(File.Exists(Path.Combine(compilfolder, artistename, "folder.jpg")))
                {
                    var SourceCover = Path.Combine(compilfolder, artistename, "folder.jpg");
                    var DestCover = Path.Combine(compilfolder,$"{artistename}.jpg");
                    File.Copy(SourceCover, DestCover, true);
                    artiste.Cover= DestCover;
                    Directory.Delete(Path.Combine(compilfolder, artistename), true);
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
                        var albcoverDestination = Path.Combine(compilfolder, $"{albumname}.jpg");
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
