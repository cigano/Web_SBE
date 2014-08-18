using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepositorioEF;

namespace Aplicacao
{
    public class LivroAplicacaoConstrutor
    {
        public static LivroAplicacao LivroAplicacaoEF()
        {
            return new LivroAplicacao(new LivroRepositorioEF());
        }
    }
}
