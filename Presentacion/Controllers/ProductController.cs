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
            ViewBag.Categorias = CategoriasBLL.Listar();
            return View(idprod == Guid.Empty ? new Product_Entity() : Product_BLL.Listar(idprod));
        }

        public ActionResult SearchProd(Guid idcat)
        {
            return View(Product_BLL.ListarByCat(idcat));
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult Create(Product_Entity objProduct)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            objProduct.Prod_Img = ConvertToBytes(file);
            var result = Product_BLL.Create(objProduct);

            if (!result)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            return Redirect("~/Product/Index");
        }
        public ActionResult RetrieveImage(Guid Prod_Int_Id)
        {
            byte[] cover = GetImageFromDataBase(Prod_Int_Id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }
        public byte[] GetImageFromDataBase(Guid Prod_Int_Id)
        {
            var dt = Product_BLL.Listar();
            var q = from temp in dt.AsEnumerable() where temp.Prod_Int_Id == Prod_Int_Id select temp.Prod_Img;
            byte[] img = q.First();

            return img;
        }

        public ActionResult MostrarImage(Guid prod)
        {
            //if (Img != null)
            //{
            //    return File(Img, "image/jpg");
            //}
            //else
            //{
            return null;
            //}
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