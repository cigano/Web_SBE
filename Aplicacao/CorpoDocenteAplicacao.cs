using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using RepositorioEF;
using Dominio.Contrato;

namespace Aplicacao
{
    public class CorpoDocenteAplicacao
    {
        private readonly IRepositorio<SBE_ST_CorpoDocente> repositorio;

        public CorpoDocenteAplicacao(IRepositorio<SBE_ST_CorpoDocente> repo)
        {
            repositorio = repo;
        }

        public void Salvar(SBE_ST_CorpoDocente corpoDocente)
        {
            repositorio.Salvar(corpoDocente);
        }

        public void Excluir(SBE_ST_CorpoDocente corpoDocente)
        {
            repositorio.Excluir(corpoDocente);
        }

        public IQueryable<SBE_ST_CorpoDocente> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public SBE_ST_CorpoDocente ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
