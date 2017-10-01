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
        [HttpPost]
        public ActionResult CreateFactu(List<TEM_PED> objTem, Pago_Entity objpago)
        {
            return null;
        }

        public ActionResult ViewToCar(string use_login)
        {
            use_login = (Session["Use_Login"] == null? "N" : Session["Use_Login"].ToString());
            ViewBag.Pago = PagoBll.Listar();
            return View(Product_BLL.Listar(use_login));
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

        [Route("CreateTem")]
        [HttpPost]
        public ActionResult CreateTem(TEM_PED objTem)
        {
           
            var result = Product_BLL.CreateTem(objTem);

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

        public ActionResult Add_Product(Guid prod_id, string name, string use_login, decimal p, Guid idcat)
        {
            var objTemPro = new  Entity.TEM_PED();

            objTemPro.Prod_Int_Id = prod_id;
            objTemPro.Name_Prod = name;
            objTemPro.Precio_Prod = p;
            objTemPro.Cat_int_id = idcat;

            if (use_login == null)
            {
                return Redirect("~/Cuenta/Login");
            }
            return View(objTemPro);
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