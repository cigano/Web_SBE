using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Contrato;
using Dominio;
using System.Data.Entity;

namespace RepositorioEF
{
    public class VideoCursoRepositorioEF: IRepositorio<SBE_ST_VideoCurso>
    {
        private readonly Contexto contexto;

        public VideoCursoRepositorioEF()
        {
            contexto = new Contexto();
        }
        public void Salvar(SBE_ST_VideoCurso entidade)
        {
            var idsCoordenacao = entidade.Coordenacao.Select(c => c.Id).ToList();
            var coordenacao = contexto.CorpoDocente.Where(cd => idsCoordenacao.Contains(cd.Id)).ToList();
            if (entidade.Id > 0)
            {
                var videoCurso = contexto.VideoCurso.First(x => x.Id == entidade.Id);
                videoCurso.Ativo = true;
                videoCurso.Banner = entidade.Banner;
                videoCurso.Conteudo = entidade.Conteudo;
                videoCurso.MiniBanner = entidade.MiniBanner;
                videoCurso.Profissao = entidade.Profissao;
                videoCurso.SubTitulo = entidade.SubTitulo;
                videoCurso.Titulo = entidade.Titulo;
                videoCurso.Coordenacao =coordenacao;
            }
            else
            {
                entidade.Ativo = true;
                entidade.Coordenacao = coordenacao;
                contexto.VideoCurso.Add(entidade);
            }
            contexto.SaveChanges();
        }

        public void Excluir(SBE_ST_VideoCurso entidade)
        {
            var agendaAlterar = contexto.VideoCurso.First(x => x.Id == entidade.Id);
            agendaAlterar.Ativo = false;
            contexto.SaveChanges();
        }

        public IQueryable<SBE_ST_VideoCurso> ListarTodos()
        {
            return contexto.VideoCurso.Include(x => x.Coordenacao).Where(x => x.Ativo == true);
            
        }

        public SBE_ST_VideoCurso ListarPorId(int id)
        {
            return contexto.VideoCurso.Include(x => x.Coordenacao).FirstOrDefault(x => x.Id == id);
        }
    }
}
