using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepositorioEF;

namespace Aplicacao
{
    public class VideoCursoAplicacaoConstrutor
    {
        public static VideoCursoAplicacao VideoCursoAplicacaoEF()
        {
            return new VideoCursoAplicacao(new VideoCursoRepositorioEF());
        }
    }
}
