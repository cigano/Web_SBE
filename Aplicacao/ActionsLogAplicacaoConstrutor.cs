using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepositorioEF;

namespace Aplicacao
{
    public class ActionsLogAplicacaoConstrutor
    {

        public static ActionsLogAplicacao ActionsLogAplicacaoEF()
        {
            return new ActionsLogAplicacao(new ActionsLogRepositorioEF());
        }
    }
}
