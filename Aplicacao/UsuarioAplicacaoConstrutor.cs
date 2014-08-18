using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepositorioEF;

namespace Aplicacao
{
    public class UsuarioAplicacaoConstrutor
    {
        public static UsuarioAplicacao UsuarioAplicacaoEF()
        {
            return new UsuarioAplicacao(new UsuarioRepositorioEF());
        }
    }
}
