using System.ComponentModel.DataAnnotations;

namespace VideosApi.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Title é obrigatório")]
        [MinLength(5, ErrorMessage = "O campo Title precisa ter no minimo 5 digitos")]
        [MaxLength(60, ErrorMessage = "O campo Title não pode exeder o máximo de 60 digitos")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "O campo Color é obrigatório")]
        [MaxLength(10, ErrorMessage = "O campo Title não pode exeder o máximo de 10 digitos")]
        public string? Color { get; set; }
        public virtual List<Video> Videos { get; set; }
    }
}
