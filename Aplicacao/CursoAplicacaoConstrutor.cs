using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepositorioEF;

namespace Aplicacao
{
    public class CursoAplicacaoConstrutor
    {
        public static CursoAplicacao CursoAplicacaoEF()
        {
            return new CursoAplicacao(new CursoRepositorioEF());
        }
    }
}
