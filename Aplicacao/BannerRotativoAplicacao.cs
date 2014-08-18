using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using RepositorioEF;
using Dominio.Contrato;

namespace Aplicacao
{
    public class BannerRotativoAplicacao
    {

        private readonly IRepositorio<SBE_ST_BannerRotativo> repositorio;

        public BannerRotativoAplicacao(IRepositorio<SBE_ST_BannerRotativo> repo)
        {
            repositorio = repo;
        }

        public void Salvar(SBE_ST_BannerRotativo banner)
        {
            repositorio.Salvar(banner);
        }

        public void Excluir(SBE_ST_BannerRotativo banner)
        {
            repositorio.Excluir(banner);
        }

        public IQueryable<SBE_ST_BannerRotativo> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public SBE_ST_BannerRotativo ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
