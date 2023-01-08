using FPIMusic.Models.Mediatheque;
using FPIMusic.Services;
using FPIMusic.Services.Mediatheque.ExtendedObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPIMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IService _Service;
        public MediaController(IService Service)
        {
            _Service = Service;
        }
        #region Artiste
        [HttpPut("Artiste/{id}")]
        public ActionResult Put(int id, [FromBody] MediathequeArtiste todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(_Service.Mediatheque.Artistes.Update(todoItem));
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }
        [HttpGet("Artiste")]
        public async Task<ActionResult<IEnumerable<MediaExtendedArtiste>>> GetArtiste()
        {
            return Ok(
            _Service.Mediatheque.Artistes.GetAll());
        }
        [HttpGet("GroupedArtiste")]
        public async Task<ActionResult<IEnumerable<GroupedMediaExtendedArtiste>>> GetGroupedArtiste()
        {
            return Ok(
            _Service.Mediatheque.Artistes.GetGrouped());
        }
        [HttpGet("Artiste/{id}")]
        public async Task<ActionResult<MediaExtendedArtiste>> GetArtiste(int id)
        {
            return Ok(
            _Service.Mediatheque.Artistes.GetById(id));
        }
        [HttpGet("Artiste/{name}")]
        public async Task<ActionResult<IEnumerable<MediaExtendedArtiste>>> GetArtiste(string name)
        {
            return Ok(
            _Service.Mediatheque.Artistes.GetByName(name));
        }
        #endregion

        #region Albums
        [HttpPut("Album/{id}")]
        public ActionResult Put(int id, [FromBody] MediathequeAlbum todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(_Service.Mediatheque.Albums.Update(todoItem));
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }
        [HttpGet("Album")]
        public async Task<ActionResult<IEnumerable<MediaExtendedAlbum>>> GetAlbum()
        {
            return Ok(
            _Service.Mediatheque.Albums.GetAll());
        }
        [HttpGet("GroupedAlbum")]
        public async Task<ActionResult<IEnumerable<GroupedMediaExtendedAlbum>>> GetGroupedAlbum()
        {
            return Ok(
            _Service.Mediatheque.Albums.GetGrouped());
        }
        [HttpGet("Album/{id}")]
        public async Task<ActionResult<MediaExtendedAlbum>> GetAlbum(int id)
        {
            return Ok(
            _Service.Mediatheque.Albums.GetById(id));
        }
        [HttpGet("AlbumByArtiste{id}")]
        public async Task<ActionResult<IEnumerable<GroupedMediaExtendedAlbum>>> GetAlbumByArtiste(int id)
        {
            return Ok(
            _Service.Mediatheque.Albums.GetByArtiste(id));
        }
        [HttpGet("Album/{name}")]
        public async Task<ActionResult<IEnumerable<MediaExtendedAlbum>>> GetAlbum(string name)
        {
            return Ok(
            _Service.Mediatheque.Albums.GetByName(name));
        }
        #endregion

        #region Song
        [HttpGet("Song/{id}")]
        public async Task<ActionResult<MediathequeSong>> GetSong(int id)
        {
            return Ok(
            _Service.Mediatheque.Song.GetById(id));
        }
        [HttpGet("SongByAlbum/{id}")]
        public async Task<ActionResult<IEnumerable<MediathequeSong>>> GetSongByAlbum(int id)
        {
            return Ok(
            _Service.Mediatheque.Song.GetByAlbumId(id));
        }
        #endregion
    }
}
