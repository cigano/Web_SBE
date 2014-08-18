using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Contrato;
using Dominio;

namespace RepositorioEF
{
    public class ActionsLogRepositorioEF : IRepositorio<SBE_ST_ActionsLog>
    {
        private readonly Contexto contexto;

        public ActionsLogRepositorioEF()
        {
            contexto = new Contexto();
        }
        public void Salvar(SBE_ST_ActionsLog entidade)
        {
            if (entidade.Id > 0)
            {
                var actionsLogAlterar = contexto.ActionsLog.First(x => x.Id == entidade.Id);
                actionsLogAlterar.Action = entidade.Action;
                actionsLogAlterar.Controller = entidade.Controller;
                actionsLogAlterar.Data = entidade.Data;
                actionsLogAlterar.Post = entidade.Post;
            }
            else
            {
                contexto.ActionsLog.Add(entidade);
            }
            contexto.SaveChanges();
        }

        public void Excluir(SBE_ST_ActionsLog entidade)
        {
            var actionsLogAlterar = contexto.ActionsLog.First(x => x.Id == entidade.Id);
            contexto.Set<SBE_ST_ActionsLog>().Remove(actionsLogAlterar);
            contexto.SaveChanges();
        }

        public IQueryable<SBE_ST_ActionsLog> ListarTodos()
        {
            return contexto.ActionsLog;
        }

        public SBE_ST_ActionsLog ListarPorId(int id)
        {
            return contexto.ActionsLog.FirstOrDefault(x => x.Id == id);
        }
    }
}
