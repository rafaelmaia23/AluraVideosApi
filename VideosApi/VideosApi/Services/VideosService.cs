using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideosApi.Data;
using VideosApi.Data.Dtos;
using VideosApi.Models;

namespace VideosApi.Services
{
    public class VideosService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public VideosService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public ReadVideoDto AddVideo(CreateVideoDto createVideoDto)
        {
            Video video = _mapper.Map<Video>(createVideoDto);
            _db.Videos.Add(video);
            _db.SaveChanges();
            return _mapper.Map<ReadVideoDto>(video);
        }

        public List<ReadVideoDto> ReadVideos()
        {
            List<Video> videoList = _db.Videos.ToList();
            if(videoList == null) return null;
            return _mapper.Map<List<ReadVideoDto>>(videoList);
        }

        public ReadVideoDto ReadVideoById(int id)
        {
            Video video = _db.Videos.FirstOrDefault(v => v.Id == id);
            if(video == null) return null;
            return _mapper.Map<ReadVideoDto>(video);
        }

        public ReadVideoDto UpdateVideo(int id, PutVideoDto putVideoDto)
        {
            Video video = _db.Videos.FirstOrDefault(v => v.Id == id);
            if (video == null) return null;
            _mapper.Map(putVideoDto, video);
            _db.SaveChanges();
            ReadVideoDto readVideoDto = _mapper.Map<ReadVideoDto>(_db.Videos.FirstOrDefault(v => v.Id == id));
            return readVideoDto;
        }

        public int DeleteVideo(int id)
        {
            Video video = _db.Videos.FirstOrDefault(v => v.Id == id);
            if (video == null) return 0;
            _db.Videos.Remove(video);
            _db.SaveChanges();
            return 1;             
        }
    }
}
