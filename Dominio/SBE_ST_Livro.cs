using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class SBE_ST_Livro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Imagem deve ser preenchido!")]
        [DisplayName("Imagem")]
        [StringLength(50, ErrorMessage = "Imagem não deve ter mais que 50 caracteres")]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "Título deve ser preenchido!")]
        [DisplayName("Título")]
        [StringLength(150, ErrorMessage = "Título não deve ter mais que 150 caracteres")]
        public string Titulo { get; set; }

        [DisplayName("Subtítulo")]
        [StringLength(300, ErrorMessage = "Subtítulo não deve ter mais que 300 caracteres")]
        public string SubTitulo { get; set; }

        [Required(ErrorMessage = "Conteúdo deve ser preenchido")]
        [DisplayName("Conteúdo")]
        public string Conteudo { get; set; }
        public bool Ativo { get; set; }
    }
}
