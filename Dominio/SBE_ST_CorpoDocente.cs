using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class SBE_ST_CorpoDocente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Imagem deve ser preenchido!")]
        [DisplayName("Imagem")]
        [StringLength(50, ErrorMessage = "Imagem não deve ter mais que 50 caracteres")]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "Nome deve ser preenchido!")]
        [DisplayName("Nome")]
        [StringLength(65, ErrorMessage = "Nome não deve ter mais que 65 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição deve ser preenchido!")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public virtual ICollection<SBE_ST_Curso> Cursos { get; set; }

        public virtual ICollection<SBE_ST_VideoCurso> VideoCursos { get; set; }
    }
}
