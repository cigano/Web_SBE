using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Contrato;
using Dominio;

namespace RepositorioEF
{
    public class UsuarioRepositorioEF : IRepositorio<SBE_ST_Usuario>
    {
        private readonly Contexto contexto;

        public UsuarioRepositorioEF()
        {
            contexto = new Contexto();
        }
        public void Salvar(SBE_ST_Usuario entidade)
        {
            if (entidade.Id > 0)
            {
                var usuarioAlterar = contexto.Usuario.First(x => x.Id == entidade.Id);
                usuarioAlterar.Nome = entidade.Nome;
                usuarioAlterar.Login = entidade.Login;
                usuarioAlterar.BannerRotativo = entidade.BannerRotativo;
                usuarioAlterar.CorpoDocente = entidade.CorpoDocente;
                usuarioAlterar.Curso = entidade.Curso;
                usuarioAlterar.Livro = entidade.Livro;
                usuarioAlterar.Parceiro = entidade.Parceiro;
                usuarioAlterar.Senha = entidade.Senha;
                usuarioAlterar.VideoCurso = entidade.VideoCurso;
            }
            else
            {
                entidade.Ativo = true;
                contexto.Usuario.Add(entidade);
            }
            contexto.SaveChanges();
        }

        public void Excluir(SBE_ST_Usuario entidade)
        {
            var usuarioAlterar = contexto.Usuario.First(x => x.Id == entidade.Id);
            usuarioAlterar.Ativo = false;
            contexto.SaveChanges();
        }

        public IQueryable<SBE_ST_Usuario> ListarTodos()
        {
            return contexto.Usuario;
        }

        public SBE_ST_Usuario ListarPorId(int id)
        {
            return contexto.Usuario.FirstOrDefault(x => x.Id == id);
        }
    }
}
