using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BLL;

namespace Presentacion.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View(Product_BLL.Listar());
        }

  
        public ActionResult Create(Product_Entity objProduct)
        {
            var result = Product_BLL.Create(objProduct);

            if (!result)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            return Redirect("~/Productos/Index");
        }
    }
}