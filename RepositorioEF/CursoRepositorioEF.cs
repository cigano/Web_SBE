using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Contrato;
using Dominio;
using System.Data.Entity;

namespace RepositorioEF
{
    public class CursoRepositorioEF: IRepositorio<SBE_ST_Curso>
    {
        private readonly Contexto contexto;

        public CursoRepositorioEF()
        {
            contexto = new Contexto();
        }
        public void Salvar(SBE_ST_Curso entidade)
        {
            

            var idsCoordenacao = entidade.Coordenacao.Select(c => c.Id).ToList();
            var coordenacao = contexto.CorpoDocente.Where(cd => idsCoordenacao.Contains(cd.Id)).ToList();
            
            if (entidade.Id > 0)
            {
                var cursoAlterar = contexto.Curso.SingleOrDefault(x => x.Id == entidade.Id);
                cursoAlterar.Ativo = true;
                cursoAlterar.Banner = entidade.Banner ?? ""; 
                cursoAlterar.Conteudo = entidade.Conteudo;
                cursoAlterar.Data = entidade.Data;
                cursoAlterar.Inicio = entidade.Inicio;
                cursoAlterar.Local = entidade.Local;
                cursoAlterar.MiniBanner = entidade.MiniBanner ?? "";
                cursoAlterar.SubTitulo = entidade.SubTitulo;
                cursoAlterar.Titulo = entidade.Titulo;
                cursoAlterar.Categoria = entidade.Categoria;

                // Entradas Excluídas
                var coordenacoesOriginais = contexto.Curso.SingleOrDefault(c => c.Id == cursoAlterar.Id).Coordenacao;

                foreach (var coordenacaoPossivelmenteExcluida in coordenacoesOriginais)
                {
                    if (cursoAlterar.Coordenacao.All(c => c.Id != coordenacaoPossivelmenteExcluida.Id))
                    {
                        contexto.CorpoDocente.Remove(coordenacaoPossivelmenteExcluida);
                    }
                }

                // Novas Entradas
                foreach (var novaCoordenacao in coordenacao)
                {
                    if (cursoAlterar.Coordenacao.All(c => c.Id != novaCoordenacao.Id))
                    {
                        cursoAlterar.Coordenacao.Add(novaCoordenacao);
                    }
                }

                contexto.SaveChanges();
            }
            else
            {
                entidade.Ativo = true;
                entidade.MiniBanner = entidade.MiniBanner ?? "";
                entidade.Banner = entidade.Banner ?? ""; 
                entidade.Coordenacao = coordenacao;
                contexto.Curso.Add(entidade);
                contexto.SaveChanges();
            }

            
        }

        public void Excluir(SBE_ST_Curso entidade)
        {
            var cursoAlterar = contexto.Curso.First(x => x.Id == entidade.Id);
            //contexto.Set<SBE_ST_Curso>().Remove(cursoAlterar);
            cursoAlterar.Ativo = false;
            contexto.SaveChanges();
        }

        public IQueryable<SBE_ST_Curso> ListarTodos()
        {
            return contexto.Curso.Include(x => x.Coordenacao).Where(x => x.Ativo == true);
                
        }

        public SBE_ST_Curso ListarPorId(int id)
        {
            return contexto.Curso.Include(x => x.Coordenacao).FirstOrDefault(x => x.Id == id);
        }
    }
}
