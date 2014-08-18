using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepositorioEF;

namespace Aplicacao
{

    public class ParceiroAplicacaoConstrutor
    {
        public static ParceiroAplicacao ParceiroAplicacaoEF()
        {
            return new ParceiroAplicacao(new ParceiroRepositorioEF());
        }
    }
}
