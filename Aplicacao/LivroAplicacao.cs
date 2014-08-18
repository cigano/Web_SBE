using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using RepositorioEF;
using Dominio.Contrato;

namespace Aplicacao
{
    public class LivroAplicacao
    {
        private readonly IRepositorio<SBE_ST_Livro> repositorio;

        public LivroAplicacao(IRepositorio<SBE_ST_Livro> repo)
        {
            repositorio = repo;
        }

        public void Salvar(SBE_ST_Livro livro)
        {
            repositorio.Salvar(livro);
        }

        public void Excluir(SBE_ST_Livro livro)
        {
            repositorio.Excluir(livro);
        }

        public IQueryable<SBE_ST_Livro> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public SBE_ST_Livro ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
