using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Presentacion.Models;
using Entity;
using BLL;
using System.Collections.Generic;
using System.Text;

namespace Presentacion.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            return View(CategoriasBLL.Listar());
        }

        // GET: Categorias/Details/5
        public ActionResult Crud(Guid idCat)
        {
            return View(idCat == Guid.Empty ? new Categorias_Entity() : CategoriasBLL.Listar(idCat));
        }



        // GET: Categorias/Create
        [HttpPost]
        public ActionResult Create(Categorias_Entity objCat)
        {
            var result = CategoriasBLL.Create(objCat);

            if (!result)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            return Redirect("~/Categorias/Index");
        }
    }
}
