using FPIMusic.DataAccess;
using FPIMusic.Models.Mediatheque;
using FPIMusic.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Implémentation
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
                if (File.Exists(Path.Combine(settings.MediathequePath,artfolder, "fanart.jpg")))
                {
                    if (context.MediathequeArtistes.Find(x=>x.Name == artfolder).Count() ==0)
                    {
                        MediathequeArtiste artiste = new MediathequeArtiste();
                        artiste.Name = artfolder;
                        artiste.Cover = Path.Combine(settings.MediathequePath, artfolder, "fanart.jpg");
                        artiste = context.MediathequeArtistes.Add(artiste);
                        await SearchForMediathequeAlbum(artiste);
                    }
                }
            }
        }

        private async Task SearchForMediathequeAlbum(MediathequeArtiste artiste)
        {
            var artfolders = Directory.EnumerateDirectories(Path.GetDirectoryName(artiste.Cover));
        }
    }
}
