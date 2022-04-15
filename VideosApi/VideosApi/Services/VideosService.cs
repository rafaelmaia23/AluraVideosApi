using VideosApi.Data;
using VideosApi.Models;

namespace VideosApi.Services
{
    public class VideosService
    {
        private readonly AppDbContext _db;

        public VideosService(AppDbContext db)
        {
            _db = db;
        }

        public Video AddVideo(Video video)
        {
            _db.Videos.Add(video);
            _db.SaveChanges();
            return video;
        }

        public List<Video> ReadVideos()
        {
            List<Video> videoList = _db.Videos.ToList();
            if(videoList == null) return null;
            return videoList;
        }

        public Video ReadVideoById(int id)
        {
            Video video = _db.Videos.FirstOrDefault(v => v.Id == id);
            if(video == null) return null;
            return video;
        }

        internal Video UpdateVideo(int id, Video video)
        {
            Video updatedVideo = _db.Videos.FirstOrDefault(v => v.Id == id);
            if (video == null) return null;
            updatedVideo.Title = video.Title;
            updatedVideo.Description = video.Description;
            updatedVideo.Url = video.Url;
            _db.SaveChanges();
            return updatedVideo;
        }
    }
}
