using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Entity;

namespace Presentacion.Controllers
{
    public class TasaCambioController : Controller
    {
        // GET: TasaCambio
        public ActionResult Index()
        {
            var TblTasaCambio = from t in TasaCambioBLL.ObtenerTasaCambio() orderby t.Fecha select t;
            return View(TblTasaCambio.ToList());
        }
    }
}