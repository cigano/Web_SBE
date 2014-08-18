using System.Linq;
using System.Web.Mvc;
using Aplicacao;
using System.Web.Security;
using Web_CMS.Attributes;


namespace Web_CMS.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuthorize]
        public ActionResult Index()
        {
            var bdusuarios = UsuarioAplicacaoConstrutor.UsuarioAplicacaoEF();
            var id = System.Web.HttpContext.Current.User.Identity.Name;
            int tid;
            int.TryParse(id, out tid);

            var usuario = bdusuarios.ListarPorId(tid);
            ViewData["Nome"] =usuario.Nome;
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            
            var Login = form["Login"];
            var Senha = form["Senha"];
            var bdUsuario = UsuarioAplicacaoConstrutor.UsuarioAplicacaoEF();
            
            var usuario = bdUsuario.ListarTodos().Where(x => x.Login == Login && x.Senha == Senha && x.Ativo == true);

            if (usuario.Count() == 1)
            {
                var user = usuario.First();
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public PartialViewResult NaoAutorizado()
        {
            return PartialView();
        }
    }
}
