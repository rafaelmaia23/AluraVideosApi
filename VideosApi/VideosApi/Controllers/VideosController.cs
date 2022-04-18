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
        public IActionResult AddVideo([FromBody] Video video)
        {
            Video videoCreated = _videosService.AddVideo(video);
            return CreatedAtAction(nameof(ReadVideoById), new { Id = videoCreated.Id }, videoCreated);
            
        }

        [HttpGet]
        public IActionResult ReadVideos()
        {
            List<Video> videoList = _videosService.ReadVideos();
            if (videoList == null) return NotFound();
            return Ok(videoList);
        }

        [HttpGet("{id}")]
        public IActionResult ReadVideoById(int id)
        {
            Video video = _videosService.ReadVideoById(id);
            if(video == null) return NotFound();
            return Ok(video);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVideo(int id, [FromBody] Video video)
        {
            Video updatedVideo = _videosService.UpdateVideo(id, video);
            if(updatedVideo == null) return NotFound(); 
            return Ok(ReadVideoById(id));
        }


    }
}
