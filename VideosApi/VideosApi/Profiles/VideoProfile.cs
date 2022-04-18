using AutoMapper;
using VideosApi.Data.Dtos;
using VideosApi.Models;

namespace VideosApi.Profiles
{
    public class VideoProfile : Profile
    {
        public VideoProfile()
        {
            CreateMap<CreateVideoDto, Video>();
            CreateMap<PutVideoDto, Video>();
            CreateMap<Video, ReadVideoDto>();
        }
    }
}
