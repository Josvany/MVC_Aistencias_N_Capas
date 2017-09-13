using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BLL;

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
            return View( idCat == Guid.Empty ? new Categorias_Entity() : CategoriasBLL.Listar(idCat));
        }

        // GET: Categorias/Create
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
