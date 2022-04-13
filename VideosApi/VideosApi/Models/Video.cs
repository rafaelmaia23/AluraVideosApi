using System.ComponentModel.DataAnnotations;

namespace VideosApi.Models
{
    public class Video
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Title { get; set; }
        [Required]
        [StringLength (150)]
        public string Description { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
