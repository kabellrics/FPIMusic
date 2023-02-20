using FPIMusic.DataAccess;
using FPIMusic.Models;
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
        private readonly IRepoUnit _contextService;
        public PlayerController(IPlayerService playerService, IRepoUnit contextService)
        {
            _playerService = playerService;
            _contextService = contextService;
        }
        private Song GetSong(int id, int songType)
        {
            if ((SongType)songType == SongType.Mediatheque)
            {
                return _contextService.MediathequeSongs.GetById(id);
            }
            else if ((SongType)songType == SongType.Compilation)
            {
                return _contextService.CompilationSongs.GetById(id);
            }
            else if ((SongType)songType == SongType.Deezer)
            {
                return _contextService.DeezerSongs.GetById(id);
            }
            else return null;
        }
        [HttpGet("PlaySong/{id}/{songType}")]
        public async Task<ActionResult> PlaySong(int id, int songType)
        {            
            _playerService.PlaySong(GetSong(id, songType));
            return Ok();
        }
        [HttpGet("AddSong/{id}/{songType}")]
        public async Task<ActionResult> AddSong(int id, int songType)
        {
            _playerService.AddSong(GetSong(id, songType));
            return Ok();
        }
        [HttpGet("AddPrioritizeSong/{id}/{songType}")]
        public async Task<ActionResult> AddPrioritizeSong(int id, int songType)
        {
            _playerService.AddPrioritizeSong(GetSong(id, songType));
            return Ok();
        }
        [HttpGet("Next")]
        public async Task<ActionResult> Next()
        {
            _playerService.NextSong();
            return Ok();
        }
        [HttpGet("Previous")]
        public async Task<ActionResult> Previous()
        {
            _playerService.PreviousSong();
            return Ok();
        }
        [HttpGet("Play")]
        public async Task<ActionResult> Play()
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
        [HttpGet("Volume/{volume}")]
        public async Task<ActionResult> Volume(int volume)
        {
            _playerService.SetVolume(volume);
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
