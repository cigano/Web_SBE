using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class SBE_ST_Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome deve ser preenchido!")]
        [DisplayName("Nome")]
        [StringLength(150, ErrorMessage = "Nome não deve ter mais que 150 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Login deve ser preenchido!")]
        [DisplayName("Login")]
        [StringLength(30, ErrorMessage = "Login não deve ter mais que 30 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha deve ser preenchido!")]
        [DisplayName("Senha")]
        [StringLength(15, ErrorMessage = "Senha não deve ter mais que 15 caracteres")]
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        [DisplayName("Banner Rotativo")]
        public bool BannerRotativo { get; set; }

        [DisplayName("Corpo Docente")]
        public bool CorpoDocente { get; set; }

        public bool Curso { get; set; }
        public bool Livro { get; set; }
        public bool Parceiro { get; set; }

        [DisplayName("Vídeo Curso")]
        public bool VideoCurso { get; set; }
        public bool Usuario { get; set; }

    }
}
