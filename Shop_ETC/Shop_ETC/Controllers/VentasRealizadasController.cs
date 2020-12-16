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
        Variables j = new Variables();
        // GET: VentasRealizadas
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
                var ventasRealizadas = db.VentasRealizadas.Include(v => v.Usuario);
                return View(ventasRealizadas.ToList());
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        // GET: VentasRealizadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentasRealizadas ventasRealizadas = db.VentasRealizadas.Find(id);
            if (ventasRealizadas == null)
            {
                return HttpNotFound();
            }
            return View(ventasRealizadas);
        }

        // GET: VentasRealizadas/Create
        public ActionResult Create()
        {
            ViewBag.idcomprador = new SelectList(db.Usuario, "Idusuario", "NombresUsuario");
            return View();
        }

        // POST: VentasRealizadas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVenta,Descripcion,Fecha,Estado,MontoTotal,idcomprador")] VentasRealizadas ventasRealizadas)
        {
            if (ModelState.IsValid)
            {
                db.VentasRealizadas.Add(ventasRealizadas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcomprador = new SelectList(db.Usuario, "Idusuario", "NombresUsuario", ventasRealizadas.idcomprador);
            return View(ventasRealizadas);
        }

        // GET: VentasRealizadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentasRealizadas ventasRealizadas = db.VentasRealizadas.Find(id);
            if (ventasRealizadas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcomprador = new SelectList(db.Usuario, "Idusuario", "NombresUsuario", ventasRealizadas.idcomprador);
            return View(ventasRealizadas);
        }

        // POST: VentasRealizadas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVenta,Descripcion,Fecha,Estado,MontoTotal,idcomprador")] VentasRealizadas ventasRealizadas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventasRealizadas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcomprador = new SelectList(db.Usuario, "Idusuario", "NombresUsuario", ventasRealizadas.idcomprador);
            return View(ventasRealizadas);
        }

        // GET: VentasRealizadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentasRealizadas ventasRealizadas = db.VentasRealizadas.Find(id);
            if (ventasRealizadas == null)
            {
                return HttpNotFound();
            }
            return View(ventasRealizadas);
        }

        // POST: VentasRealizadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VentasRealizadas ventasRealizadas = db.VentasRealizadas.Find(id);
            db.VentasRealizadas.Remove(ventasRealizadas);
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
