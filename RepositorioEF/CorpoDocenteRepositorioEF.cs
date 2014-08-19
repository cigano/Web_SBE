using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Contrato;
using Dominio;

namespace RepositorioEF
{
    public class CorpoDocenteRepositorioEF: IRepositorio<SBE_ST_CorpoDocente>
    {
        private readonly Contexto contexto;

        public CorpoDocenteRepositorioEF()
        {
            contexto = new Contexto();
        }
        public void Salvar(SBE_ST_CorpoDocente entidade)
        {
            if (entidade.Id > 0)
            {
                var corpoDocenteAlterar = contexto.CorpoDocente.First(x => x.Id == entidade.Id);
                corpoDocenteAlterar.Descricao = entidade.Descricao;
                corpoDocenteAlterar.Imagem = entidade.Imagem ?? "";
                corpoDocenteAlterar.Nome = entidade.Nome;
            }
            else
            {
                entidade.Imagem = entidade.Imagem ?? "";
                contexto.CorpoDocente.Add(entidade);
            }
            contexto.SaveChanges();
        }

        public void Excluir(SBE_ST_CorpoDocente entidade)
        {
            var corpoDocenteAlterar = contexto.CorpoDocente.First(x => x.Id == entidade.Id);
            contexto.Set<SBE_ST_CorpoDocente>().Remove(corpoDocenteAlterar);
            contexto.SaveChanges();
        }

        public IQueryable<SBE_ST_CorpoDocente> ListarTodos()
        {
            return contexto.CorpoDocente;
        }

        public SBE_ST_CorpoDocente ListarPorId(int id)
        {
            return contexto.CorpoDocente.FirstOrDefault(x => x.Id == id);
        }
    }
}
