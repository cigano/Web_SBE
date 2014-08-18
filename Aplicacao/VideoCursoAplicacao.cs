using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Dominio.Contrato;

namespace Aplicacao
{
    public class VideoCursoAplicacao
    {
        private readonly IRepositorio<SBE_ST_VideoCurso> repositorio;

        public VideoCursoAplicacao(IRepositorio<SBE_ST_VideoCurso> repo)
        {
            repositorio = repo;
        }

        public void Salvar(SBE_ST_VideoCurso videoCurso)
        {
            repositorio.Salvar(videoCurso);
        }

        public void Excluir(SBE_ST_VideoCurso videoCurso)
        {
            repositorio.Excluir(videoCurso);
        }

        public IQueryable<SBE_ST_VideoCurso> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public SBE_ST_VideoCurso ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
