using FPIMusic.Models.Compilation;
using FPIMusic.Models.Deezer;
using FPIMusic.Services;
using FPIMusic.Services.Deezer.ExtendeObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPIMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeezerController : ControllerBase
    {
        private readonly IService _Service;
        public DeezerController(IService Service)
        {
            _Service = Service;
        }
        #region Artiste
        [HttpPut("Artiste/{id}")]
        public ActionResult Put(int id, [FromBody] DeezerArtiste todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(_Service.Deezer.Artistes.Update(todoItem));
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }
        [HttpGet("Artiste")]
        public async Task<ActionResult<IEnumerable<DeezerExtendedArtiste>>> GetArtiste()
        {
            return Ok(
            _Service.Deezer.Artistes.GetAll());
        }
        [HttpGet("ArtisteMostSong")]
        public async Task<ActionResult<IEnumerable<DeezerExtendedArtiste>>> GetArtisteMostSong()
        {
            return Ok(
            _Service.Deezer.Artistes.GetMostSongArtiste());
        }
        [HttpGet("ArtisteMostPlaylist")]
        public async Task<ActionResult<IEnumerable<DeezerExtendedArtiste>>> GetMostPlaylist()
        {
            return Ok(
            _Service.Deezer.Artistes.GetMostPlaylistArtiste());
        }
        [HttpGet("ArtisteMostAlbum")]
        public async Task<ActionResult<IEnumerable<DeezerExtendedArtiste>>> GetArtisteMostAlbum()
        {
            return Ok(
            _Service.Deezer.Artistes.GetMostAlbumArtiste());
        }
        [HttpGet("GroupedArtiste")]
        public async Task<ActionResult<IEnumerable<GroupedDeezerExtendedArtiste>>> GetGroupedArtiste()
        {
            return Ok(
            _Service.Deezer.Artistes.GetGrouped());
        }
        [HttpGet("Artiste/{id}")]
        public async Task<ActionResult<DeezerExtendedArtiste>> GetArtiste(int id)
        {
            return Ok(
            _Service.Deezer.Artistes.GetById(id));
        }
        [HttpGet("Artiste/{name}")]
        public async Task<ActionResult<IEnumerable<DeezerExtendedArtiste>>> GetArtiste(string name)
        {
            return Ok(
            _Service.Deezer.Artistes.GetByName(name));
        }
        #endregion
        #region Album
        [HttpPut("Album/{id}")]
        public ActionResult Put(int id, [FromBody] DeezerAlbum todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(_Service.Deezer.Albums.Update(todoItem));
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }
        [HttpGet("Album")]
        public async Task<ActionResult<IEnumerable<DeezerExtendedAlbum>>> GetAlbum()
        {
            return Ok(
            _Service.Deezer.Albums.GetAll());
        }
        [HttpGet("GroupedAlbum")]
        public async Task<ActionResult<IEnumerable<GroupedDeezerExtendedAlbum>>> GetGroupedAlbum()
        {
            return Ok(
            _Service.Deezer.Albums.GetGrouped());
        }
        [HttpGet("Album/{id}")]
        public async Task<ActionResult<DeezerExtendedAlbum>> GetAlbum(int id)
        {
            return Ok(
            _Service.Deezer.Albums.GetById(id));
        }
        [HttpGet("Album/{name}")]
        public async Task<ActionResult<IEnumerable<DeezerExtendedAlbum>>> GetAlbum(string name)
        {
            return Ok(
            _Service.Deezer.Albums.GetByName(name));
        }
        #endregion
        #region Playlist
        [HttpPut("Playlist/{id}")]
        public ActionResult Put(int id, [FromBody] DeezerPlaylist todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(_Service.Deezer.Playlists.Update(todoItem));
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }
        [HttpGet("Playlist")]
        public async Task<ActionResult<IEnumerable<DeezerExtendedPlaylist>>> GetPlaylist()
        {
            return Ok(
            _Service.Deezer.Playlists.GetAll());
        }
        [HttpGet("GroupedPlaylist")]
        public async Task<ActionResult<IEnumerable<GroupedDeezerExtendedPlaylist>>> GetGroupedPlaylist()
        {
            return Ok(
            _Service.Deezer.Playlists.GetGrouped());
        }
        [HttpGet("Playlist/{id}")]
        public async Task<ActionResult<DeezerExtendedPlaylist>> GetPlaylist(int id)
        {
            return Ok(
            _Service.Deezer.Playlists.GetById(id));
        }
        [HttpGet("Playlist/{name}")]
        public async Task<ActionResult<IEnumerable<DeezerExtendedPlaylist>>> GetPlaylist(string name)
        {
            return Ok(
            _Service.Deezer.Playlists.GetByName(name));
        }
        #endregion
        #region Song
        [HttpGet("Song/{id}")]
        public async Task<ActionResult<DeezerSong>> GetSong(int id)
        {
            return Ok(
            _Service.Deezer.Songs.GetById(id));
        }
        [HttpGet("SongByAlbum/{id}")]
        public async Task<ActionResult<IEnumerable<DeezerSong>>> GetSongByAlbum(int id)
        {
            return Ok(
            _Service.Deezer.Songs.GetByAlbumId(id));
        }
        [HttpGet("SongByArtiste/{id}")]
        public async Task<ActionResult<IEnumerable<DeezerSong>>> GetSongByArtiste(int id)
        {
            return Ok(
            _Service.Deezer.Songs.GetByArtisteId(id));
        }
        [HttpGet("SongByPlaylist/{id}")]
        public async Task<ActionResult<IEnumerable<DeezerSong>>> GetSongByPlaylist(int id)
        {
            return Ok(
            _Service.Deezer.Songs.GetByPlaylistid(id));
        }
        #endregion
    }
}
