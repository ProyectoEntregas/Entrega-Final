using Shop_ETC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_ETC.Controllers
{
    public class AccesoController : Controller
    {
        private SITIOWEBEntities db = new SITIOWEBEntities();
        Variables ob = new Variables();
        // GET: Acceso
        int cont = 1;
        public ActionResult Login(string User, string Pass)
        {
            try
            {
                using (Models.SITIOWEBEntities db = new Models.SITIOWEBEntities())
                {

                    ob.Nombre = (from d in db.Usuario
                                 where (d.Nickusuario == User.Trim() && d.Contra == Pass.Trim()) || (d.email==User.Trim() && d.Contra == Pass.Trim())
                                 select d.Nickusuario).FirstOrDefault();
                    
                    if (ob.Nombre == null)
                    {
                        ViewBag.Depende = "Usuario o Conrtraseña incorrecta";
                        var Productos = db.Productos;
                        return View(Productos.ToList());
                     

                    }
                    ob.va = Convert.ToInt32((from tip in db.Usuario
                                             where tip.Nickusuario == ob.Nombre
                                             select tip.idTipo).FirstOrDefault());
                    Session["user"] = ob.Nombre;
                   
                      
                }
                if (ob.va == 2)
                {
                    return RedirectToAction("Index", "Home", ob);
                }
                else if(ob.va == 1)
                {
                    return RedirectToAction("Cliente", "Home", ob);
                }
                var Producto = db.Productos;
                return View(Producto.ToList());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        // GET: Usuarios/Create
        public ActionResult Registrar()
        {
            ViewBag.idTipo = new SelectList(db.TipoUsuario, "idTipo", "TipoUsuario1");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar([Bind(Include = "Idusuario,NombresUsuario,Nickusuario,Fecha_nacimiento,Genero,email,Direccion,Telefono,Contra,idTipo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            ViewBag.idTipo = new SelectList(db.TipoUsuario, "idTipo", "TipoUsuario1", usuario.idTipo);
            return View(usuario);
        }

    }
}