using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using BLL;

namespace Presentacion.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            return View(EmpleadosBLL.Listar());
        }

        public ActionResult Create(Empleados objEmple)
        {
            var result = objEmple.IdEmpleado > 0 ? EmpleadosBLL.Edit(objEmple) : EmpleadosBLL.Create(objEmple);

            if (!result)
            {
                ViewBag.Mensaje = "Erorr a procesar";
                return View("~/Views/Shared/Error.cshtml");
            }


            return Redirect("~/");
        }

        public ActionResult Editar(int IdEmpleados = 0)
        {
            return View(IdEmpleados == 0 ?
            new Empleados() :
            EmpleadosBLL.Listar(IdEmpleados));

        }

    }
}