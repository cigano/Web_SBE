﻿using System;
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
    [CustomAuthorize(Permissao.Livro)]
    public class LivroController : Controller
    {

        LivroAplicacao bdLivro;
        string caminhoArquivo;

        public LivroController()
        {
            bdLivro = LivroAplicacaoConstrutor.LivroAplicacaoEF();
            caminhoArquivo = Caminho.Livro();
        }

        public PartialViewResult Index()
        {
            var livros = bdLivro.ListarTodos();
            return PartialView(livros);
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
        public PartialViewResult Create(SBE_ST_Livro livro, FormCollection collection)
        {
            bdLivro.Salvar(livro);
            return null;
        }


        public PartialViewResult Edit(int id)
        {
            var livro = bdLivro.ListarPorId(id);
            return PartialView(livro);
        }


        [CustomActionFilter]
        [AcceptVerbs(HttpVerbs.Post)]
        public PartialViewResult Edit(SBE_ST_Livro livro, FormCollection collection)
        {
            bdLivro.Salvar(livro);
            return null;
        }

        [CustomActionFilter]
        public PartialViewResult Delete(int id)
        {
            var livro = bdLivro.ListarPorId(id);
            bdLivro.Excluir(livro);
            return null;
        }


    }
}
