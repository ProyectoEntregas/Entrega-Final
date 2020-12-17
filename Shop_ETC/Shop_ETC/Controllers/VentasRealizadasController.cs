using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop_ETC.Models;

namespace Shop_ETC.Controllers
{
    public class VentasRealizadasController : Controller
    {
        private SITIOWEBEntities db = new SITIOWEBEntities();

        // GET: VentasRealizadas

        public ActionResult Ventas()
        {
            var mostrarVenta = (from mv in db.VentasRealizadas
                                select mv).ToList();
            return View(mostrarVenta.ToList());
        }
        public ActionResult Editar(int? id)
        {
            var consuk= (from mv in db.VentasRealizadas
                         where mv.idVenta==id
                         select mv).ToList();
            return View(consuk.ToList());
        }
        public ActionResult Edit()
        {
            var id= Convert.ToInt32(Request.Form["id"].ToString());
            var idc=Convert.ToInt32( Request.Form["idc"].ToString());
            var desc = Request.Form["txtDesc"].ToString();
            var est = Request.Form["txtEstado"].ToString();
            var mt = Convert.ToDecimal(Request.Form["txtMontoTotal"].ToString());
            var fech =Convert.ToDateTime( Request.Form["txtfech"].ToString());
            db.UpdateVentaTotal(desc, est, mt, fech, idc, id);
            return RedirectToAction("Ventas");
        }
        public ActionResult Borrar(int? id)
        {
            db.BorrarVenta(id);
            return RedirectToAction("Ventas");
        }

    }
}
