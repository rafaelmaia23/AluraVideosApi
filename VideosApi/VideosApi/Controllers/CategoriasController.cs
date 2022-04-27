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

        public IActionResult ReadCategoriaById(int id)
        {
            return null;
        }


    }
}
