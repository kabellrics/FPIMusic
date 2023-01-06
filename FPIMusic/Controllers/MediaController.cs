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
        [HttpPut("{id}")]
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
        public async Task<ActionResult<IEnumerable<IGrouping<char, MediaExtendedArtiste>>>> GetGroupedArtiste()
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
    }
}
