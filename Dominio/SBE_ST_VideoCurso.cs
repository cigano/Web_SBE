using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SBE_ST_VideoCurso
    {
        public int Id { get; set; }
        public string MiniBanner { get; set; }
        public string Banner { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Profissao { get; set; }
        public string Conteudo { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<SBE_ST_CorpoDocente> Coordenacao { get; set; }
    }
}
