using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Entity;
using BLL;

namespace Presentacion.Controllers
{
    public class CuentaController : Controller
    {

        public CuentaController()
        {

        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                if (this.Request.IsAuthenticated)
                {

                    return this.RedirectToLocal(returnUrl);
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex);
            }

            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User_Entity model, string returnUrl)
        {
            try
            {
                var loginInfo = User_BLL.Listar(model.Use_Login, model.Use_Pass);

                if (loginInfo)
                {
                    this.SignInUser(model.Use_Login, false);
                    Session["Use_Login"] = model.Use_Login;
                    return this.RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña invalido");
                }
                return this.View(model);
            }
            catch (Exception)
            {

            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Salir()
        {
            try
            {
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                authenticationManager.SignOut();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return this.RedirectToAction("Index", "Home");
        }
        private void SignInUser(string username, bool isPersistent)
        {
            var claims = new List<Claim>();

            try
            {
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;


                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return this.RedirectToAction("Index", "Home");
        }
        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult RegistroCreate(User_Entity objUser)
        {
            var result = User_BLL.Create(objUser);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Ha ocurrido un problema");
            }
            else
            {
                var objLogin = new User_Entity();
                objLogin.Use_Login = objUser.Use_Login;
                objLogin.Use_Pass = objUser.Use_Pass;
                Session["Use_Login"] = objUser.Use_Login;
                return Login(objLogin, "~/Cuenta/Informacion");
            }

            return Redirect("~/Cuenta/Informacion");
        }

        //[HttpGet]
        public ActionResult Informacion(string use_login)
        {
            if (use_login == null)
            {
                return Redirect("~/Home/Index");
            }
            var resul = User_BLL.Listar(use_login);
            Session["Use_Login"] = use_login;
            if (resul.Count > 0)
            {
                Guid Use_Int_Id = new Guid(resul[0].Use_Inf_Int_Id.ToString());
                if (Use_Int_Id != Guid.Empty)
                {
                    return View(Use_Inf_Bll.Listar(Use_Int_Id));
                }
            }

            return View(new User_Info_Entity());
        }

        [HttpPost]
        public ActionResult Informacion(User_Info_Entity objUseInf)
        {
            var Use_Login = Session["Use_Login"];
            var result = Use_Inf_Bll.Create(objUseInf, Use_Login.ToString());
            

            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Ha ocurrido un problema");
            }
            else
            {
                return View();
            }
            return View();
        }

    }
}