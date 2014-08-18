using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class SBE_ST_Parceiro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome deve ser preenchido!")]
        [DisplayName("Nome")]
        [StringLength(150, ErrorMessage = "Nome não deve ter mais que 150 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Logo deve ser preenchido!")]
        [DisplayName("Logo")]
        [StringLength(50, ErrorMessage = "Logo não deve ter mais que 50 caracteres")]
        public string Logo { get; set; }

        [Required(ErrorMessage = "Link deve ser preenchido!")]
        [DisplayName("Link")]
        [StringLength(150, ErrorMessage = "Link não deve ter mais que 150 caracteres")]
        public string Link { get; set; }
    }
}
