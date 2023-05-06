using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WsApiexamen;
using WsApiexamen.Models;

namespace WebExamen.Controllers
{
    public class ExamenController : Controller
    {
        WsApiexamen.Models.Context db = new WsApiexamen.Models.Context();

        // GET: Examen
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult save(tblExamen examen)
        {
            Response res = new Response();

            try
            {

                clsExamen service = new clsExamen();
                // tblExamen ex = new tblExamen();

               res = service.AgregarExamen("sp",examen);

            }
            catch (Exception e)
            {

            }

            return Json(new { mensaje = res }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult _TablaExamen()
        {
           clsExamen service = new clsExamen();
           // tblExamen ex = new tblExamen();

            var examen = service.ConsultarExamen("ws", "Luis", "Ninguna").ToList();

            return PartialView(examen);
        }
    }
}