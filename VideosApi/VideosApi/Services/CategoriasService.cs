using AutoMapper;
using VideosApi.Data;
using VideosApi.Data.Dtos.CategoriaDtos;
using VideosApi.Models;

namespace VideosApi.Services
{
    public class CategoriasService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public CategoriasService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public ReadCategoriaDto AddCategoria(CreateCategoriaDto createCategoriaDto)
        {
            Categoria categoria = _mapper.Map<Categoria>(createCategoriaDto);
            _db.Categorias.Add(categoria);
            _db.SaveChanges();
            return _mapper.Map<ReadCategoriaDto>(categoria);
        }


    }
}
