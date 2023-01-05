using FPIMusic.Models;
using FPIMusic.Services.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPIMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingService _settingService;
        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        [HttpGet("CompilationPath")]
        public ActionResult<DBParameter> GetCompilationPath()
        {
            return Ok(_settingService.CompilationPath);
        }
        [HttpGet("MediathequePath")]
        public ActionResult<DBParameter> GetMediathequePath()
        {
            return Ok(_settingService.MediathequePath);
        }
        [HttpGet("DeezerPath")]
        public ActionResult<DBParameter> GetDeezerPath()
        {
            return Ok(_settingService.DeezerPath);
        }
        [HttpGet("CompilationPath{path}")]
        public ActionResult SetCompilationPath(string path)
        {
            _settingService.SetCompilationPath(path);
            return Ok();
        }
        [HttpGet("MediathequePath{path}")]
        public ActionResult SetMediathequePath(string path)
        {
            _settingService.SetMediathequePath(path);
            return Ok();
        }
        [HttpGet("DeezerPath{path}")]
        public ActionResult SetDeezerPath(string path)
        {
            _settingService.SetDeezerPath(path);
            return Ok();
        }
    }
}
