using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Dominio.Contrato;

namespace Aplicacao
{
    public class ActionsLogAplicacao
    {
        private readonly IRepositorio<SBE_ST_ActionsLog> repositorio;

        public ActionsLogAplicacao(IRepositorio<SBE_ST_ActionsLog> repo)
        {
            repositorio = repo;
        }

        public void Salvar(SBE_ST_ActionsLog actionsLog)
        {
            repositorio.Salvar(actionsLog);
        }

        public void Excluir(SBE_ST_ActionsLog actionsLog)
        {
            repositorio.Excluir(actionsLog);
        }

        public IQueryable<SBE_ST_ActionsLog> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public SBE_ST_ActionsLog ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
