using Microsoft.AspNetCore.Mvc;
using VideosApi.Data.Dtos;
using VideosApi.Models;
using VideosApi.Services;

namespace VideosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideosController : Controller
    {
        private readonly VideosService _videosService;

        public VideosController(VideosService videosService)
        {
            _videosService = videosService;
        }

        [HttpPost]
        public IActionResult AddVideo([FromBody] CreateVideoDto createVideoDto)
        {
            ReadVideoDto readVideoDto = _videosService.AddVideo(createVideoDto);
            return CreatedAtAction(nameof(ReadVideoById), new { Id = readVideoDto.Id }, readVideoDto);
            
        }

        [HttpGet]
        public IActionResult ReadVideos()
        {
            List<ReadVideoDto> readVideoDtos = _videosService.ReadVideos();
            if (readVideoDtos == null) return NotFound();
            return Ok(readVideoDtos);
        }

        [HttpGet("{id}")]
        public IActionResult ReadVideoById(int id)
        {
            ReadVideoDto readVideoDto = _videosService.ReadVideoById(id);
            if(readVideoDto == null) return NotFound();
            return Ok(readVideoDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVideo(int id, [FromBody] PutVideoDto putVideoDto)
        {
            ReadVideoDto readVideoDto = _videosService.UpdateVideo(id, putVideoDto);
            if(readVideoDto == null) return NotFound(); 
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVideo(int id)
        {
            int result = _videosService.DeleteVideo(id);
            if(result == 0) return NotFound();
            return NoContent();
        }
    }
}
