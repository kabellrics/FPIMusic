using FPIMusic.Models.Compilation;
using FPIMusic.Models.Mediatheque;
using FPIMusic.Services;
using FPIMusic.Services.Compilation.ExtendedObject;
using FPIMusic.Services.Mediatheque.ExtendedObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPIMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompilController : ControllerBase
    {
        private readonly IService _Service;
        public CompilController(IService Service)
        {
            _Service = Service;
        }
        #region Artiste
        [HttpPut("Artiste/{id}")]
        public ActionResult Put(int id, [FromBody] CompilationArtiste todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(_Service.Compilation.Artistes.Update(todoItem));
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }
        [HttpGet("Artiste")]
        public async Task<ActionResult<IEnumerable<CompilExtendedArtiste>>> GetArtiste()
        {
            return Ok(
            _Service.Compilation.Artistes.GetAll());
        }
        [HttpGet("GroupedArtiste")]
        public async Task<ActionResult<IEnumerable<GroupedCompilExtendedArtiste>>> GetGroupedArtiste()
        {
            return Ok(
            _Service.Compilation.Artistes.GetGrouped());
        }
        [HttpGet("Artiste/{id}")]
        public async Task<ActionResult<CompilExtendedArtiste>> GetArtiste(int id)
        {
            return Ok(
            _Service.Compilation.Artistes.GetById(id));
        }
        [HttpGet("Artiste/{name}")]
        public async Task<ActionResult<IEnumerable<CompilExtendedArtiste>>> GetArtiste(string name)
        {
            return Ok(
            _Service.Compilation.Artistes.GetByName(name));
        }
        #endregion
        #region Album
        [HttpPut("Album/{id}")]
        public ActionResult Put(int id, [FromBody] CompilationAlbum todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(_Service.Compilation.Albums.Update(todoItem));
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }
        [HttpGet("Album")]
        public async Task<ActionResult<IEnumerable<CompilExtendedAlbum>>> GetAlbum()
        {
            return Ok(
            _Service.Compilation.Albums.GetAll());
        }
        [HttpGet("GroupedAlbum")]
        public async Task<ActionResult<IEnumerable<GroupedCompilExtendedAlbum>>> GetGroupedAlbum()
        {
            return Ok(
            _Service.Compilation.Albums.GetGrouped());
        }
        [HttpGet("Album/{id}")]
        public async Task<ActionResult<CompilExtendedAlbum>> GetAlbum(int id)
        {
            return Ok(
            _Service.Compilation.Albums.GetById(id));
        }
        [HttpGet("Album/{name}")]
        public async Task<ActionResult<IEnumerable<CompilExtendedAlbum>>> GetAlbum(string name)
        {
            return Ok(
            _Service.Compilation.Albums.GetByName(name));
        }
        #endregion
        #region Song
        [HttpGet("Song/{id}")]
        public async Task<ActionResult<CompilationSong>> GetSong(int id)
        {
            return Ok(
            _Service.Compilation.Song.GetById(id));
        }
        [HttpGet("SongByAlbum/{id}")]
        public async Task<ActionResult<IEnumerable<CompilationSong>>> GetSongByAlbum(int id)
        {
            return Ok(
            _Service.Compilation.Song.GetByAlbumId(id));
        }
        [HttpGet("SongByArtiste/{id}")]
        public async Task<ActionResult<IEnumerable<CompilationSong>>> GetSongByArtiste(int id)
        {
            return Ok(
            _Service.Compilation.Song.GetByArtisteId(id));
        }
        #endregion
    }
}
