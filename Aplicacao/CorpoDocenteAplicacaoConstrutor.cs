using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepositorioEF;    

namespace Aplicacao
{
    public class CorpoDocenteAplicacaoConstrutor
    {
        public static CorpoDocenteAplicacao CorpoDocenteAplicacaoEF()
        {
            return new CorpoDocenteAplicacao(new CorpoDocenteRepositorioEF());
        }
    }
}
