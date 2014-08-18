using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class SBE_ST_BannerRotativo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Título deve ser preenchido!")]
        [DisplayName("Título")]
        [StringLength(90, ErrorMessage = "Título não deve ter mais que 90 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Subtítulo deve ser preenchido!")]
        [DisplayName("Subtítulo")]
        [StringLength(320, ErrorMessage = "Subtítulo não deve ter mais que 320 caracteres")]
        public string SubTitulo { get; set; }

        [Required(ErrorMessage = "Link deve ser preenchido!")]
        [DisplayName("Link")]
        [StringLength(150, ErrorMessage = "Link não deve ter mais que 150 caracteres")]
        public string Link { get; set; }

        [Required(ErrorMessage = "Imagem deve ser preenchido!")]
        [DisplayName("Imagem")]
        [StringLength(50, ErrorMessage = "Imagem não deve ter mais que 50 caracteres")]
        public string Imagem { get; set; }
    }
}
