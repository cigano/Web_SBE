using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepositorioEF;

namespace Aplicacao
{

    public class BannerRotativoAplicacaoConstrutor
    {
        public static BannerRotativoAplicacao BannerRotativoAplicacaoEF()
        {
            return new BannerRotativoAplicacao(new BannerRotativoRepositorioEF());
        }
    }
}
