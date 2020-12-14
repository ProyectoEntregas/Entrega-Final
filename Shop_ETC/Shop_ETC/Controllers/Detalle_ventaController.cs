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
    public class Detalle_ventaController : Controller
    {
        private SITIOWEBEntities db = new SITIOWEBEntities();
        Variables j = new Variables();

        // GET: Detalle_venta
        public ActionResult Index()
        {
            j.Nom = Session["user"].ToString();
            if (j.Nom == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            j.va = Convert.ToInt32((from tip in db.Usuario
                                    where tip.Nickusuario == j.Nom
                                    select tip.idTipo).FirstOrDefault());
            if (j.va == 2)
            {

                return View(db.Detalle_venta.ToList());
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        // GET: Detalle_venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_venta detalle_venta = db.Detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta);
        }

        // GET: Detalle_venta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Detalle_venta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVenta,nombreProducto,cantidad,precio,descripcion,idUser")] Detalle_venta detalle_venta)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_venta.Add(detalle_venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detalle_venta);
        }

        // GET: Detalle_venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_venta detalle_venta = db.Detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta);
        }

        // POST: Detalle_venta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVenta,nombreProducto,cantidad,precio,descripcion,idUser")] Detalle_venta detalle_venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detalle_venta);
        }

        // GET: Detalle_venta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_venta detalle_venta = db.Detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta);
        }

        // POST: Detalle_venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_venta detalle_venta = db.Detalle_venta.Find(id);
            db.Detalle_venta.Remove(detalle_venta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
