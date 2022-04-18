using System.ComponentModel.DataAnnotations;

namespace VideosApi.Data.Dtos
{
    public class PutVideoDto
    {
        [Required(ErrorMessage = "O campo Title é obrigatório")]
        [MinLength(5, ErrorMessage = "O campo Title precisa ter no minimo 5 digitos")]
        [MaxLength(60, ErrorMessage = "O campo Title não pode exeder o máximo de 60 digitos")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "O campo Description é obrigatório")]
        [MinLength(10, ErrorMessage = "O campo Description precisa ter no minimo 10 digitos")]
        [MaxLength(150, ErrorMessage = "O campo Description não pode exeder o máximo de 150 digitos")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "O campo Url é obrigatório")]
        [MinLength(5, ErrorMessage = "O campo Url precisa ter no minimo 5 digitos")]
        public string? Url { get; set; }
    }
}
