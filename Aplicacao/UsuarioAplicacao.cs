using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Dominio.Contrato;

namespace Aplicacao
{
    public class UsuarioAplicacao
    {
        private readonly IRepositorio<SBE_ST_Usuario> repositorio;

        public UsuarioAplicacao(IRepositorio<SBE_ST_Usuario> repo)
        {
            repositorio = repo;
        }

        public void Salvar(SBE_ST_Usuario usuario)
        {
            repositorio.Salvar(usuario);
        }

        public void Excluir(SBE_ST_Usuario usuario)
        {
            repositorio.Excluir(usuario);
        }

        public IQueryable<SBE_ST_Usuario> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public SBE_ST_Usuario ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
