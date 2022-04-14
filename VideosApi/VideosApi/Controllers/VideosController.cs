using Microsoft.AspNetCore.Mvc;
using VideosApi.Models;
using VideosApi.Services;

namespace VideosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly VideosService _videosService;

        public VideosController(VideosService videosService)
        {
            _videosService = videosService;
        }

        [HttpPost]
        public IActionResult AddVideos([FromBody] Video video)
        {
            Video videoCreated = _videosService.AddVideo(video);
            return CreatedAtAction(nameof(ReadVideosById), new { Id = videoCreated.Id }, videoCreated);
            
        }

        [HttpGet]
        public IActionResult ReadVideos()
        {
            List<Video> videoList = _videosService.ReadVideos();
            if (videoList == null) return NotFound();
            return Ok(videoList);
        }

        [HttpGet("{id}")]
        public IActionResult ReadVideosById(int id)
        {
            Video video = _videosService.ReadVideosById(id);
            if(video == null) return NotFound();
            return Ok(video);
        }

    }
}
