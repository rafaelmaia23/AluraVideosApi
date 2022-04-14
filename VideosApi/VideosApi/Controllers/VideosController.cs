using Microsoft.AspNetCore.Mvc;
using VideosApi.Models;
using VideosApi.Services;

namespace VideosApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class VideosController : ControllerBase
    {
        private readonly VideosService _videosService;

        public VideosController(VideosService videosService)
        {
            _videosService = videosService;
        }

        [HttpGet]
        public IActionResult ReadVideo()
        {
            List<Video> videoList = _videosService.ReadVideo();
            if (videoList == null) return NotFound();
            return Ok(videoList);
        }
    }
}
