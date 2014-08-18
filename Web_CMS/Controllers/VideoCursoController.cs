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
    [CustomAuthorize(Permissao.VideoCurso)]
    public class VideoCursoController : Controller
    {

        VideoCursoAplicacao bdVideoCurso;
        CorpoDocenteAplicacao bdCorpo;
        string caminhoArquivo;

        public VideoCursoController()
        {
            bdVideoCurso = VideoCursoAplicacaoConstrutor.VideoCursoAplicacaoEF();
            bdCorpo = CorpoDocenteAplicacaoConstrutor.CorpoDocenteAplicacaoEF();
            caminhoArquivo = Caminho.VideoCurso();
        }

        public PartialViewResult Index()
        {
            var cursos = bdVideoCurso.ListarTodos();
            return PartialView(cursos);
        }


        public PartialViewResult Create()
        {
            ViewData["CorpoDocente"] = bdCorpo.ListarTodos().OrderBy(x => x.Nome);
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
        public PartialViewResult Create(SBE_ST_VideoCurso videoCurso, FormCollection collection)
        {
            videoCurso.Coordenacao = splitCorpoDocente(collection["chk"].Split(','));
            bdVideoCurso.Salvar(videoCurso);
            return null;
        }


        private List<SBE_ST_CorpoDocente> splitCorpoDocente(string[] corpoDocentes)
        {
            var corpoDocenteSalvar = new List<SBE_ST_CorpoDocente>();
            int parser;
            foreach (string corpoDocente in corpoDocentes)
            {
                if (!corpoDocente.Contains("false"))
                {
                    if (int.TryParse(corpoDocente, out parser))
                        corpoDocenteSalvar.Add(bdCorpo.ListarPorId(parser));
                }
            }
            return corpoDocenteSalvar;
        }


        public PartialViewResult Edit(int id)
        {
            var videoCurso = bdVideoCurso.ListarPorId(id);
            ViewData["CorpoDocente"] = bdCorpo.ListarTodos().OrderBy(x => x.Nome);
            return PartialView(videoCurso);
        }


        [CustomActionFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public PartialViewResult Edit(SBE_ST_VideoCurso videoCurso, FormCollection collection)
        {
            videoCurso.Coordenacao = splitCorpoDocente(collection["chk"].Split(','));
            bdVideoCurso.Salvar(videoCurso);
            return null;
        }

        [CustomActionFilter]
        public PartialViewResult Delete(int id)
        {
            var videoCurso = bdVideoCurso.ListarPorId(id);
            bdVideoCurso.Excluir(videoCurso);
            return null;
        }

    }
}
