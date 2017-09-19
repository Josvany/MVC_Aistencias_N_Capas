using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BLL;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Presentacion.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Login()
        //{
        //    return View();
        //}

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                // Verification.    
                if (this.Request.IsAuthenticated)
                {
                    // Info.    
                    return this.RedirectToLocal(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info    
                Console.Write(ex);
            }
            // Info.    
            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User_Entity model, string returnUrl)
        {
            try
            {
                // Verification.
                
                    // Initialization.
                    var loginInfo = User_BLL.Listar(model.Use_Login, model.Use_Pass);

                    // Verification.
                    //if (loginInfo != null && loginInfo.() > 0)
                    //{
                    //    // Initialization.
                    //    //var logindetails = loginInfo.First();

                    //    //// Login In.
                    //    //this.SignInUser(logindetails.username, false);

                    //    // Info.
                    //    return this.RedirectToLocal(returnUrl);
                    //}
                    //else
                    //{
                    //    // Setting.
                    //    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    //}
                
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                // Verification.    
                if (Url.IsLocalUrl(returnUrl))
                {
                    // Info.    
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
            // Info.    
            return this.RedirectToAction("Index", "Home");
        }
    }
}