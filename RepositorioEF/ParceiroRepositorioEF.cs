using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Contrato;
using Dominio;

namespace RepositorioEF
{
    public class ParceiroRepositorioEF: IRepositorio<SBE_ST_Parceiro>
    {
        private readonly Contexto contexto;

        public ParceiroRepositorioEF()
        {
            contexto = new Contexto();
        }
        public void Salvar(SBE_ST_Parceiro entidade)
        {
            if (entidade.Id > 0)
            {
                var parceiroAlterar = contexto.Parceiro.First(x => x.Id == entidade.Id);
                parceiroAlterar.Logo = entidade.Logo;
                parceiroAlterar.Nome = entidade.Nome;
                parceiroAlterar.Link = entidade.Link;
            }
            else
            {
                contexto.Parceiro.Add(entidade);
            }
            contexto.SaveChanges();
        }

        public void Excluir(SBE_ST_Parceiro entidade)
        {
            var parceiroAlterar = contexto.Parceiro.First(x => x.Id == entidade.Id);
            contexto.Set<SBE_ST_Parceiro>().Remove(parceiroAlterar);
            contexto.SaveChanges();
        }

        public IQueryable<SBE_ST_Parceiro> ListarTodos()
        {
            return contexto.Parceiro;
        }

        public SBE_ST_Parceiro ListarPorId(int id)
        {
            return contexto.Parceiro.FirstOrDefault(x => x.Id == id);
        }
    }
}
