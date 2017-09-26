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
            if (idCat == Guid.Empty)
            {
                var objCat = new List<Categorias_Entity>();

                return View();
            }
            else
            {
                return View(CategoriasBLL.Listar(idCat));
            }
        }

        public ActionResult New()
        {
            return View();
        }

        // GET: Categorias/Create
        [HttpPost]
        public ActionResult Create(List<Categorias_Entity> objCatList)
        {
            var objCat = new Categorias_Entity();
            objCat.CatIntIdValue = objCatList[0].CatIntIdValue;
            objCat.CatNombreValue = objCatList[0].CatNombreValue;
            objCat.CatCodigoValue = objCatList[0].CatCodigoValue;
            objCat.CatStatusValue = objCatList[0].CatStatusValue;


            var result = CategoriasBLL.Create(objCat);

            if (!result)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            return Redirect("~/Categorias/Index");
        }
        [HttpPost]
        public ActionResult Creates(Categorias_Entity objCat)
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
