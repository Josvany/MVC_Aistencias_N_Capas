using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BLL;

namespace Presentacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["Categorias"] = CategoriasBLL.Listar();
            return base.View();
        }

        public ActionResult About()
        {
            //ViewBag.Categorias = CategoriasBLL.Listar();
            return View(/*CategoriasBLL.Listar()*/);
        }

        public ActionResult Contact()
        {
            //ViewBag.Categorias = CategoriasBLL.Listar();
            return View(/*CategoriasBLL.Listar()*/);
        }
    }
}