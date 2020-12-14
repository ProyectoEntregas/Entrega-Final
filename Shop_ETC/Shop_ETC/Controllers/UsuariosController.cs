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
    public class UsuariosController : Controller
    {
        private SITIOWEBEntities db = new SITIOWEBEntities();
        Variables j = new Variables();
        // GET: Usuarios
        public ActionResult User()
        {
            j.Nom = Session["user"].ToString();
            if (j.Nom == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            j.va =Convert.ToInt32( (from tip in db.Usuario
                        where tip.Nickusuario == j.Nom
                        select tip.idTipo).FirstOrDefault());
            if (j.va == 2)
            {
                var usuario = db.Usuario.Include(u => u.TipoUsuario);
                return View(usuario.ToList());
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.idTipo = new SelectList(db.TipoUsuario, "idTipo", "TipoUsuario1");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idusuario,NombresUsuario,Nickusuario,Fecha_nacimiento,Genero,email,Direccion,Telefono,Contra,idTipo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("User");
            }

            ViewBag.idTipo = new SelectList(db.TipoUsuario, "idTipo", "TipoUsuario1", usuario.idTipo);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipo = new SelectList(db.TipoUsuario, "idTipo", "TipoUsuario1", usuario.idTipo);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idusuario,NombresUsuario,Nickusuario,Fecha_nacimiento,Genero,email,Direccion,Telefono,Contra,idTipo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("User");
            }
            ViewBag.idTipo = new SelectList(db.TipoUsuario, "idTipo", "TipoUsuario1", usuario.idTipo);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("User");
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
