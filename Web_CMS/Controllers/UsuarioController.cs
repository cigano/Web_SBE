using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao;
using Dominio;
using Web_CMS.Attributes;
using Web_CMS.Enums;
using Web_CMS.Filters;


namespace Web_CMS.Controllers
{
    [CustomAuthorize(Permissao.Usuario)]
    public class UsuarioController : Controller
    {
        UsuarioAplicacao bdUsuario;

        public UsuarioController()
        {
            bdUsuario = UsuarioAplicacaoConstrutor.UsuarioAplicacaoEF();
        }

        public PartialViewResult Index()
        {
            var usuarios = bdUsuario.ListarTodos().Where(x=>x.Login!="administrador").ToList();
            return PartialView(usuarios);
        }


        public PartialViewResult Create()
        {
            return PartialView();
        }

        [CustomActionFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public PartialViewResult Create(SBE_ST_Usuario usuario)
        {
            bdUsuario.Salvar(usuario);
            return null;
        }



        public PartialViewResult Edit(int id)
        {
            var usuario = bdUsuario.ListarPorId(id);
            return PartialView(usuario);
        }


        [CustomActionFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public PartialViewResult Edit(SBE_ST_Usuario usuario)
        {
            bdUsuario.Salvar(usuario);
            return null;
        }

        [CustomActionFilter]
        public PartialViewResult Delete(int id)
        {
            var usuario = bdUsuario.ListarPorId(id);
            bdUsuario.Excluir(usuario);
            return null;
        }

    }
}
