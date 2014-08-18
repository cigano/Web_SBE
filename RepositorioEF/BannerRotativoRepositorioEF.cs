using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Contrato;
using Dominio;

namespace RepositorioEF
{
    public class BannerRotativoRepositorioEF: IRepositorio<SBE_ST_BannerRotativo>
    {
        private readonly Contexto contexto;

        public BannerRotativoRepositorioEF()
        {
            contexto = new Contexto();
        }
        public void Salvar(SBE_ST_BannerRotativo entidade)
        {
            if (entidade.Id > 0)
            {
                var bannerAlterar = contexto.BannerRotativo.First(x => x.Id == entidade.Id);
                bannerAlterar.Link = entidade.Link;
                bannerAlterar.SubTitulo = entidade.SubTitulo;
                bannerAlterar.Titulo = entidade.Titulo;
                bannerAlterar.Imagem = entidade.Imagem;
            }
            else
            {
                contexto.BannerRotativo.Add(entidade);
            }
            contexto.SaveChanges();
        }

        public void Excluir(SBE_ST_BannerRotativo entidade)
        {
            var bannerAlterar = contexto.BannerRotativo.First(x => x.Id == entidade.Id);
            contexto.Set<SBE_ST_BannerRotativo>().Remove(bannerAlterar);
            contexto.SaveChanges();
        }

        public IQueryable<SBE_ST_BannerRotativo> ListarTodos()
        {
            return contexto.BannerRotativo;
        }

        public SBE_ST_BannerRotativo ListarPorId(int id)
        {
            return contexto.BannerRotativo.FirstOrDefault(x => x.Id == id);
        }
    }
}
