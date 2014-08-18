using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao;
using Dominio;
using Web_CMS.Helpers;
using Web_CMS.Attributes;
using Web_CMS.Enums;
using Web_CMS.Filters;


namespace Web_CMS.Controllers
{
    [CustomAuthorize(Permissao.CorpoDocente)]
    public class CorpoDocenteController : Controller
    {
      
        CorpoDocenteAplicacao bdCorpoDocente;
        string caminhoArquivo;

        public CorpoDocenteController()
        {
            bdCorpoDocente = CorpoDocenteAplicacaoConstrutor.CorpoDocenteAplicacaoEF();
            caminhoArquivo = Caminho.CorpoDocente();
        }

        public PartialViewResult Index()
        {
            var docentes = bdCorpoDocente.ListarTodos().ToList();
            return PartialView(docentes);
        }


        public PartialViewResult Create()
        {
            return PartialView();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadArquivo()
        {
            HttpPostedFileBase file = Request.Files[0] as HttpPostedFileBase;
            if (file != null && file.ContentLength > 0)
            {
                var ftp = new Helpers.Ftp();
                string nome = ftp.GerarNome(file.FileName.Substring(file.FileName.LastIndexOf(".")));
                if (ftp.UploadArquivo(file, nome, caminhoArquivo))
                    return Json(new { Nome = nome }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { Nome = "" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Nome = "" }, JsonRequestBehavior.AllowGet);
        }


        [CustomActionFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public PartialViewResult Create(SBE_ST_CorpoDocente docente)
        {
            bdCorpoDocente.Salvar(docente);
            return null;
        }

        

        public PartialViewResult Edit(int id)
        {
            var docente = bdCorpoDocente.ListarPorId(id);
            return PartialView(docente);
        }


        [CustomActionFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public PartialViewResult Edit(SBE_ST_CorpoDocente docente)
        {
            bdCorpoDocente.Salvar(docente);
            return null;
        }

        public PartialViewResult Delete(int id)
        {
            var docente = bdCorpoDocente.ListarPorId(id);
            bdCorpoDocente.Excluir(docente);
            return null;
        }

    }
}
