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
        bool newUser = false;
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
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
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

            return null;
        }
    }
}