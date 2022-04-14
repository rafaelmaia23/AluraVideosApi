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

        public List<Video> ReadVideo()
        {
            List<Video> videoList = _db.Videos.ToList();
            if(videoList == null) return null;
            return videoList;
        }
    }
}
