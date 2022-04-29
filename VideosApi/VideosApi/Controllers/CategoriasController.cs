using Microsoft.AspNetCore.Mvc;
using VideosApi.Data.Dtos.CategoriaDtos;
using VideosApi.Services;

namespace VideosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : Controller
    {
        private readonly CategoriasService _categoriasService;

        public CategoriasController(CategoriasService categoriasService)
        {
            _categoriasService = categoriasService;
        }

        [HttpPost]
        public IActionResult AddCategoria([FromBody] CreateCategoriaDto createCategoriaDto)
        {
            ReadCategoriaDto readCategoriaDto = _categoriasService.AddCategoria(createCategoriaDto);
            return CreatedAtAction(nameof(ReadCategoriaById), new { Id = readCategoriaDto.Id }, readCategoriaDto);
        }

        [HttpGet]
        public IActionResult ReadCategorias()
        {
            List<ReadCategoriaDto> readCategoriaDtos = _categoriasService.ReadCategorias();
            if (readCategoriaDtos == null) return NotFound();
            return Ok(readCategoriaDtos);
        }

        [HttpGet("{id}")]
        public IActionResult ReadCategoriaById(int id)
        {
            ReadCategoriaDto readCategoriaDto = _categoriasService.ReadCategoriaById(id);
            if(readCategoriaDto == null) return NotFound();
            return Ok(readCategoriaDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategoria(int id, [FromBody]PutCategoriaDto putCategoriaDto)
        {
            ReadCategoriaDto readCategoriaDto = _categoriasService.UpdateCategoria(id, putCategoriaDto);
            if (readCategoriaDto == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoria(int id)
        {
            int result = _categoriasService.Deletecategoria(id);
            if(result == 0) return NotFound();
            return NoContent();
        }
    }
}
