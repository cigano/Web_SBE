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
    [CustomAuthorize(Permissao.Curso)]
    public class CursoController : Controller
    {
        CursoAplicacao bdCurso;
        CorpoDocenteAplicacao bdCorpo;
        string caminhoArquivo;

        public CursoController()
        {
            bdCurso = CursoAplicacaoConstrutor.CursoAplicacaoEF();
            bdCorpo = CorpoDocenteAplicacaoConstrutor.CorpoDocenteAplicacaoEF();
            caminhoArquivo = Caminho.Curso();
        }

        public PartialViewResult Index(string categoria)
        {

            var cursos = bdCurso.ListarTodos().Where(x=>x.Categoria==categoria).ToList();
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
        public PartialViewResult Create(SBE_ST_Curso curso, FormCollection collection)
        {
            curso.Coordenacao = splitCorpoDocente(collection["chk"].Split(','));
            bdCurso.Salvar(curso);
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
            var curso = bdCurso.ListarPorId(id);
            ViewData["CorpoDocente"] = bdCorpo.ListarTodos().OrderBy(x => x.Nome);
            return PartialView(curso);
        }


        [CustomActionFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public PartialViewResult Edit(SBE_ST_Curso curso, FormCollection collection)
        {
            curso.Coordenacao = splitCorpoDocente(collection["chk"].Split(','));
            bdCurso.Salvar(curso);
            return null;
        }

        [CustomActionFilter]
        public PartialViewResult Delete(int id)
        {
            var curso = bdCurso.ListarPorId(id);
            bdCurso.Excluir(curso);
            return null;
        }

    }
}
