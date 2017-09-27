using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
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

        public ActionResult Crud(Guid idprod)
        {
            return View(new Product_Entity());
        }
        [Route("Create")]
        [HttpPost]
        public ActionResult Create(Product_Entity objProduct)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            objProduct.Prod_Img =  ConvertToBytes(file);
            var result = Product_BLL.Create(objProduct);

            if (!result)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            return Redirect("~/Productos/Index");
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}