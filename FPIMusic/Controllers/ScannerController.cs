using FPIMusic.Services;
using FPIMusic.Services.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPIMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScannerController : ControllerBase
    {
        private readonly IScanner _scanService;
        public ScannerController(IScanner scanService)
        {
            _scanService = scanService;
        }
        [HttpGet("ScanCompilation")]
        public async Task<ActionResult> ScanCompilation()
        {
            await Task.Run(() => _scanService.Compilation.Scan());
            await Task.Run(() => _scanService.Compilation.Clean());
            return Ok();
        }
        [HttpGet("ScanMediatheque")]
        public async Task<ActionResult> ScanMediatheque()
        {
            await Task.Run(() => _scanService.Mediatheque.Scan());
            await Task.Run(() => _scanService.Mediatheque.Clean());
            return Ok();
        }
        [HttpGet("ScanDeezer")]
        public async Task<ActionResult> ScanDeezer()
        {
            await Task.Run(() => _scanService.Deezer.Scan());
            await Task.Run(() => _scanService.Deezer.Clean());
            return Ok();
        }
        [HttpGet("CleanCompilation")]
        public async Task<ActionResult> CleanCompilation()
        {
            await Task.Run(() => _scanService.Compilation.Clean());
            return Ok();
        }
        [HttpGet("CleanMediatheque")]
        public async Task<ActionResult> CleanMediatheque()
        {
            await Task.Run(() => _scanService.Mediatheque.Clean());
            return Ok();
        }
        [HttpGet("CleanDeezer")]
        public async Task<ActionResult> CleanDeezer()
        {
            await Task.Run(() => _scanService.Deezer.Clean());
            return Ok();
        }
    }
}
