using AutoMapper;
using VideosApi.Data.Dtos.CategoriaDtos;
using VideosApi.Models;

namespace VideosApi.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<Categoria, ReadCategoriaDto>();
            CreateMap<PutCategoriaDto, Categoria>();
        }

    }
}
