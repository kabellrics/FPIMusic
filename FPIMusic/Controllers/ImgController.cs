using FPIMusic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using static System.Net.Mime.MediaTypeNames;

namespace FPIMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgController : ControllerBase
    {
        private readonly IService _Service;
        public ImgController(IService Service)
        {
            _Service = Service;
        }
        private async Task<(byte[] image, string MimeType, string FileName)> GetCoverData(string filepath)
        {
            try
            {
                string MimeType = string.Empty;
                string FileName = string.Empty;
                byte[] image;
                FileName = Path.GetFileName(filepath);
                MimeType = "image/jpg";
                image = System.IO.File.ReadAllBytes(filepath);
                return (image, MimeType, FileName);
            }
            catch (Exception ex)
            {
                //throw;
                return (null,string.Empty,string.Empty);
            }
        }
        [HttpGet("MediaArt/{id}")]
        public async Task<IActionResult> MediaArt(int id)
        {
            string MimeType = string.Empty;
            string FileName = string.Empty;
            byte[] image;
            var mediaArt = _Service.Mediatheque.Artistes.GetById(id);
            (image, MimeType, FileName) = await GetCoverData(mediaArt.Cover);
            return File(image, MimeType/*, FileName*/);
        }
        [HttpGet("MediaAlb/{id}")]
        public async Task<IActionResult> MediaAlb(int id)
        {
            string MimeType = string.Empty;
            string FileName = string.Empty;
            byte[] image;
            var mediaArt = _Service.Mediatheque.Albums.GetById(id);
            (image, MimeType, FileName) = await GetCoverData(mediaArt.Cover);
            return File(image, MimeType/*, FileName*/);
        }
        [HttpGet("CompilArt/{id}")]
        public async Task<IActionResult> CompilArt(int id)
        {
            string MimeType = string.Empty;
            string FileName = string.Empty;
            byte[] image;
            var CompilArt = _Service.Compilation.Artistes.GetById(id);
            (image, MimeType, FileName) = await GetCoverData(CompilArt.Cover);
            return File(image, MimeType/*, FileName*/);
        }
        [HttpGet("CompilAlb/{id}")]
        public async Task<IActionResult> CompilAlb(int id)
        {
            string MimeType = string.Empty;
            string FileName = string.Empty;
            byte[] image;
            var CompilArt = _Service.Compilation.Albums.GetById(id);
            (image, MimeType, FileName) = await GetCoverData(CompilArt.Cover);
            return File(image, MimeType/*, FileName*/);
        }
        [HttpGet("DeezerArt/{id}")]
        public async Task<IActionResult> DeezerArt(int id)
        {
            string MimeType = string.Empty;
            string FileName = string.Empty;
            byte[] image;
            var DeezerArt = _Service.Deezer.Artistes.GetById(id);
            (image, MimeType, FileName) = await GetCoverData(DeezerArt.Cover);
            return File(image, MimeType/*, FileName*/);
        }
        [HttpGet("DeezerAlb/{id}")]
        public async Task<IActionResult> DeezerAlb(int id)
        {
            string MimeType = string.Empty;
            string FileName = string.Empty;
            byte[] image;
            var DeezerArt = _Service.Deezer.Albums.GetById(id);
            (image, MimeType, FileName) = await GetCoverData(DeezerArt.Cover);
            return File(image, MimeType/*, FileName*/);
        }
        [HttpGet("DeezerPlaylist/{id}")]
        public async Task<IActionResult> DeezerPlaylist(int id)
        {
            string MimeType = string.Empty;
            string FileName = string.Empty;
            byte[] image;
            var DeezerArt = _Service.Deezer.Playlists.GetById(id);
            (image, MimeType, FileName) = await GetCoverData(DeezerArt.Cover);
            return File(image, MimeType/*, FileName*/);
        }
    }
}
