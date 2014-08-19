using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class SBE_ST_Curso
    {
        public int Id { get; set; }

        // [Required(ErrorMessage = "Mini Banner deve ser preenchido!")]
        [DisplayName("Mini Banner")]
        [StringLength(50, ErrorMessage = "Mini Banner não deve ter mais que 50 caracteres")]
        public string MiniBanner { get; set; }

        [Required(ErrorMessage = "Categoria deve ser preenchido!")]
        [DisplayName("Categoria")]
        [StringLength(25, ErrorMessage = "Categoria não deve ter mais que 25 caracteres")]
        public string Categoria { get; set; }

        // [Required(ErrorMessage = "Banner deve ser preenchido!")]
        [DisplayName("Banner")]
        [StringLength(50, ErrorMessage = "Mini Banner não deve ter mais que 50 caracteres")]
        public string Banner { get; set; }


        [Required(ErrorMessage = "Título deve ser preenchido!")]
        [DisplayName("Título")]
        [StringLength(150, ErrorMessage = "Título não deve ter mais que 150 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Subtítulo deve ser preenchido!")]
        [DisplayName("Subtítulo")]
        [StringLength(300, ErrorMessage = "Subtítulo não deve ter mais que 300 caracteres")]
        public string SubTitulo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Data deve ser preenchido")]
        [DisplayName("Data")]
        public DateTime Data { get; set; }

        
        [Required(ErrorMessage = "Data Exibição deve ser preenchido")]
        [DisplayName("Data Exibição")]
        [StringLength(90, ErrorMessage = "Data Exibição não deve ter mais que 90 caracteres")]
        public string Inicio { get; set; }

        
        [DisplayName("Local")]
        [StringLength(90, ErrorMessage = "Local não deve ter mais que 90 caracteres")]
        public string Local { get; set; }

        
        [DisplayName("Conteúdo")]
        public string Conteudo { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<SBE_ST_CorpoDocente> Coordenacao { get; set; }
    }
}
