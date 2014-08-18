using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplicacao;
using System.Web.Mvc;
using Dominio;
using System.Web.Routing;

namespace Web_CMS.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private Enums.Permissao[] _permissoes;
        private UsuarioAplicacao bdusuarios;

        public CustomAuthorizeAttribute(params Enums.Permissao[] permissoes)
        {
            _permissoes = permissoes;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            if (!_permissoes.Any()) return true;

            bdusuarios = UsuarioAplicacaoConstrutor.UsuarioAplicacaoEF();

            var id = System.Web.HttpContext.Current.User.Identity.Name;
            int tid;
            int.TryParse(id, out tid);

            var usuario = bdusuarios.ListarPorId(tid);


            foreach (Enums.Permissao permissao in _permissoes)
            {
                switch (permissao)
                {
                    case Enums.Permissao.BannerRotativo:
                        return usuario.BannerRotativo;
                    case Enums.Permissao.CorpoDocente:
                        return usuario.CorpoDocente;
                    case Enums.Permissao.Curso:
                        return usuario.Curso;
                    case Enums.Permissao.Livro:
                        return usuario.Livro;
                    case Enums.Permissao.Parceiro:
                        return usuario.Parceiro;
                    case Enums.Permissao.Usuario:
                        return usuario.Usuario;
                    case Enums.Permissao.VideoCurso:
                        return usuario.VideoCurso;
                }
            }

            return false;

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name))
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new
                    {
                        controller = "Home",
                        action = "Login"
                    })
                );
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new
                    {
                        controller = "Home",
                        action = "NaoAutorizado"
                        
                    })
                );
            }

        }
    }
}