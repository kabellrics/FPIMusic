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
    }
}
