using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Aplicacao;
using System.Text;


namespace Web_CMS.Filters
{
    public class CustomActionFilter : ActionFilterAttribute, IActionFilter
    {
        [ValidateInput(false)]
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            string valor;
            StringBuilder post = new StringBuilder();
            foreach (var campo in filterContext.HttpContext.Request.Form.AllKeys)
            {
                valor = filterContext.HttpContext.Request.Form[campo];
                if (campo != "__RequestVerificationToken")
                {
                    post.Append(campo);
                    post.Append(":");
                    post.Append(valor);
                    post.Append("//END//");
                }
            }

            var bdLog = ActionsLogAplicacaoConstrutor.ActionsLogAplicacaoEF();
            int usuario;
            int.TryParse(System.Web.HttpContext.Current.User.Identity.Name, out usuario);

            var log = new SBE_ST_ActionsLog()
            {
                Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Action = filterContext.ActionDescriptor.ActionName,
                Data = filterContext.HttpContext.Timestamp,
                Post = post.ToString(),
                Usuario = usuario
            };
            bdLog.Salvar(log);

            this.OnActionExecuting(filterContext);
        }
    }
}