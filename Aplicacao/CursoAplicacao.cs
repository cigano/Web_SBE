using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using RepositorioEF;
using Dominio.Contrato;

namespace Aplicacao
{
    public class CursoAplicacao
    {
        private readonly IRepositorio<SBE_ST_Curso> repositorio;

        public CursoAplicacao(IRepositorio<SBE_ST_Curso> repo)
        {
            repositorio = repo;
        }

        public void Salvar(SBE_ST_Curso curso)
        {
            repositorio.Salvar(curso);
        }

        public void Excluir(SBE_ST_Curso curso)
        {
            repositorio.Excluir(curso);
        }

        public IQueryable<SBE_ST_Curso> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public SBE_ST_Curso ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
