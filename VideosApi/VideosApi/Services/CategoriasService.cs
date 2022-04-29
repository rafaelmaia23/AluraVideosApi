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

        public List<ReadCategoriaDto> ReadCategorias()
        {
            List<Categoria>? categorias = _db.Categorias.ToList();
            if (categorias == null) return null;
            return _mapper.Map<List<ReadCategoriaDto>>(categorias);
        }

        public ReadCategoriaDto ReadCategoriaById(int id)
        {
            Categoria? categoria = _db.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null) return null;
            return _mapper.Map<ReadCategoriaDto>(categoria);
        }

        public ReadCategoriaDto UpdateCategoria(int id, PutCategoriaDto putCategoriaDto)
        {
            Categoria? categoria = _db.Categorias.FirstOrDefault(c => c.Id == id);
            if(categoria == null) return null;
            _mapper.Map(putCategoriaDto, categoria);
            _db.SaveChanges();
            ReadCategoriaDto readCategoriaDto = _mapper.Map<ReadCategoriaDto>(_db.Categorias.FirstOrDefault(c =>c.Id == id));
            return readCategoriaDto; 
        }

        internal int Deletecategoria(int id)
        {
            Categoria? categoria = _db.Categorias.FirstOrDefault(c =>c.Id == id);
            if(categoria == null) return 0;
            _db.Categorias.Remove(categoria);
            _db.SaveChanges();
            return 1;
        }
    }
}
