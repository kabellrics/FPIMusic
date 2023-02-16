using FPIMusic.Models.Mediatheque;
using FPIMusic.Models.Player;
using FPIMusic.Services;
using FPIMusic.Services.Player;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPIMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpGet("PlaySong/{id}/{songType}")]
        public async Task<ActionResult> PlaySong(int id, int songType)
        {
            _playerService.PlaySong(id, songType);
            return Ok();
        }
        [HttpGet("AddSong/{id}/{songType}")]
        public async Task<ActionResult> AddSong(int id, int songType)
        {
            _playerService.AddSong(id, songType);
            return Ok();
        }
        [HttpGet("AddPrioritizeSong/{id}/{songType}")]
        public async Task<ActionResult> AddPrioritizeSong(int id, int songType)
        {
            _playerService.AddPrioritizeSong(id, songType);
            return Ok();
        }
        [HttpGet("Next")]
        public async Task<ActionResult> Next()
        {
            _playerService.GetNextSongToPlay();
            return Ok();
        }
        [HttpGet("Previous")]
        public async Task<ActionResult> Previous()
        {
            _playerService.GetPreviousSongToPlay();
            return Ok();
        }
        [HttpGet("Play")]
        public async Task<ActionResult> Play()
        {
            _playerService.Play();
            return Ok();
        }
        [HttpGet("Resume")]
        public async Task<ActionResult> Resume()
        {
            _playerService.Resume();
            return Ok();
        }
        [HttpGet("Pause")]
        public async Task<ActionResult> Pause()
        {
            _playerService.Pause();
            return Ok();
        }
        [HttpGet("Stop")]
        public async Task<ActionResult> Stop()
        {
            _playerService.Stop();
            return Ok();
        }
        [HttpGet("Status")]
        public async Task<ActionResult<PlayerListStatus>> Status()
        {
            return Ok(
            _playerService.GetPlayerListStatus());
        }
    }
}
