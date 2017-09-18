using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BLL;
namespace Presentacion.Controllers
{
    public class TypeUserController : Controller
    {
        // GET: TypeUser
        public ActionResult Index()
        {
            return View(Type_User_BLL.Listar());
        }

        public ActionResult Crud(Guid IdType)
        {
            return View(IdType == Guid.Empty ? new Type_User_Entity() : Type_User_BLL.Listar(IdType));
        }

        public ActionResult Create(Type_User_Entity objEntity)
        {
            var result = Type_User_BLL.Create(objEntity);

            if (!result)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            return Redirect("~/TypeUser/Index");
        }
    }
}