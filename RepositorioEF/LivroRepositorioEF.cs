using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Contrato;
using Dominio;

namespace RepositorioEF
{
    public class LivroRepositorioEF: IRepositorio<SBE_ST_Livro>
    {
        private readonly Contexto contexto;

        public LivroRepositorioEF()
        {
            contexto = new Contexto();
        }
        public void Salvar(SBE_ST_Livro entidade)
        {
            if (entidade.Id > 0)
            {
                var livroAlterar = contexto.Livro.First(x => x.Id == entidade.Id);
                livroAlterar.Ativo = true;
                livroAlterar.Conteudo = entidade.Conteudo;
                livroAlterar.Imagem = entidade.Imagem;
                livroAlterar.SubTitulo = entidade.SubTitulo;
                livroAlterar.Titulo = entidade.Titulo;
            }
            else
            {
                entidade.Ativo = true;
                contexto.Livro.Add(entidade);
            }
            contexto.SaveChanges();
        }

        public void Excluir(SBE_ST_Livro entidade)
        {
            var livroAlterar = contexto.Livro.First(x => x.Id == entidade.Id);
            livroAlterar.Ativo = false;
            contexto.SaveChanges();
        }

        public IQueryable<SBE_ST_Livro> ListarTodos()
        {
            return contexto.Livro.Where(x=>x.Ativo ==true);
        }

        public SBE_ST_Livro ListarPorId(int id)
        {
            return contexto.Livro.FirstOrDefault(x => x.Id == id);
        }
    }
}
