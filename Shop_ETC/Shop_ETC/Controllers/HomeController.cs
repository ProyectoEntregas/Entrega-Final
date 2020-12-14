using Shop_ETC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_ETC.Controllers;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace Shop_ETC.Controllers
{
    public class HomeController : Controller
    {

        private SITIOWEBEntities db = new SITIOWEBEntities();
        Variables ob = new Variables();
        public ActionResult Index()
        {
            ViewBag.Nombre = Session["user"];

            var Productos = db.Productos;
            return View(Productos.ToList());
           
        }
        public ActionResult Carrito(int? id)
        {
            if (id == null)
            {
                try
                {
                    
                    ob.Nombre = Session["user"].ToString();
                    var carro = db.Carrito1(ob.Nombre);
                    ViewBag.US = ob.Nombre;
                    return View(carro.ToList());
                }
                catch (Exception ex)
                {
                    return View(ex);
                }
            }
            else
            {

                try
                {
                    db.ActualizarStock(id);
                    ob.Nom = (from f in db.Productos
                              where f.Idproducto == id
                              select f.NombreProducto).FirstOrDefault();
                    ob.Nombre = Session["user"].ToString();
                    ob.var1 = (from h in db.Usuario
                               where h.Nickusuario == ob.Nombre.Trim()
                               select h.Idusuario).FirstOrDefault();
                    ob.desc = (from f in db.Productos
                               where f.Idproducto == id
                               select f.Descripcion).FirstOrDefault();
                    ob.pre = Convert.ToDecimal((from f in db.Productos
                                                where f.Idproducto == id
                                                select f.Precio_venta).FirstOrDefault());
                    var carri = db.UpVenta(ob.Nom, 1, ob.pre, ob.desc, ob.var1);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View();
                }
            }


        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {

            }
            var Retorn = db.selecciondeProduct(id);
                
            return View(Retorn.ToList());
        }
        public ActionResult ActualizarCarro()
        {
            ob.va = Convert.ToInt32(Request.Form["txtidVenta"].ToString());
            ob.var1= Convert.ToInt32(Request.Form["txtcantidad"].ToString());
            var Actualizar = db.actualizarcarrito(ob.var1, ob.va);
            ob.var1 = ob.var1 - 1;
            ob.seleccion = Request.Form["NombreProduct"].ToString();
            db.EditarActualizarStock(ob.seleccion, ob.var1);
            return RedirectToAction("Carrito", "Home");

        }
        public ActionResult Borrar(int? id)
        {
            if (id == null)
            {

            }
            var Retorn = db.selecciondeProduct(id);

            return View(Retorn.ToList());
        }
        public ActionResult ConfirmBorrar()
        {
            ob.va = Convert.ToInt32(Request.Form["txtidVenta"].ToString());
            var dl = db.deletecarrito(ob.va);
           return RedirectToAction("Carrito", "Home");
        }

       public ActionResult Detalle()
        {
            ViewBag.Total = ob.pre;
            ob.Nombre = Session["user"].ToString();
            ob.var1 = (from h in db.Usuario
                       where h.Nickusuario == ob.Nombre.Trim()
                       select h.Idusuario).FirstOrDefault();
          
            var Precompra = db.detalleCarrito(ob.var1);
            return View(Precompra.ToList());
        }

        public ActionResult Comprar()
        {
            ob.Nombre = Session["user"].ToString();
            ob.var1 = (from h in db.Usuario
                       where h.Nickusuario == ob.Nombre.Trim()
                       select h.Idusuario).FirstOrDefault();
            
            var Monto = db.MontoTotalPagar(ob.var1);
            return View(Monto.ToList());
         }
            
        








        public ActionResult About()
        {
            ob.Nombre = "";
            Session["user"] = "";
            return RedirectToAction("Login", "Acceso");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Buscar(string Bus)
        {
            try
            {
                if (Bus=="")
                {
                    return Content("Ingrese su busqueda");
                }
                else
                {
                    ob.Nom = (from s in db.Productos
                              where s.NombreProducto == Bus.Trim()
                              select s.NombreProducto).FirstOrDefault();
                    ob.Nombre= (from j in db.Categorias
                                where j.NombreCate == Bus.Trim()
                                select j.NombreCate).FirstOrDefault();
                 
                     if ( ob.Nombre==null)
                    {
                        
                        var busqueda = db.BuscadorMejorado(ob.Nom, "");
                        return View(busqueda.ToList());
                    }
                    else if ( ob.Nom == null)
                    {
                        var busqueda = db.BuscadorMejorado("", ob.Nombre);
                        return View(busqueda.ToList());
                    }
                    else if (ob.Nom == null && ob.Nombre == null)
                    {
                        return Content("Ingrese su busqueda");
                    }
                }
            }
            catch ( Exception ex)
            {
                return Content("Se genero un Error" + ex.Message);
            }
            return View();
            
        }

        public ActionResult Perfil()
        {
            ob.seleccion = Session["user"].ToString();
           if(ob.seleccion == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var perf = db.Perfil(ob.seleccion);
            return View(perf.ToList());
        }
        //Vistas Para Cliente--------------------------------
        //----------------------------------------------------
        public ActionResult Cliente()
        {
            ViewBag.Nombre = Session["user"];
            var Productos = db.Productos;
            return View(Productos.ToList());
            
        }
        public ActionResult CarritoCliente(int? id)
        {
            ViewBag.Nombre = Session["user"];
            if (id == null)
            {
                try
                {

                    ob.Nombre = Session["user"].ToString();
                    var carro = db.Carrito1(ob.Nombre);
                    ViewBag.US = ob.Nombre;
                    return View(carro.ToList());
                }
                catch (Exception ex)
                {
                    return View(ex);
                }
            }
            else
            {

                try
                {
                    db.ActualizarStock(id);
                    ob.Nom = (from f in db.Productos
                              where f.Idproducto == id
                              select f.NombreProducto).FirstOrDefault();
                    ob.Nombre = Session["user"].ToString();
                    ob.var1 = (from h in db.Usuario
                               where h.Nickusuario == ob.Nombre.Trim()
                               select h.Idusuario).FirstOrDefault();
                    ob.desc = (from f in db.Productos
                               where f.Idproducto == id
                               select f.Descripcion).FirstOrDefault();
                    ob.pre = Convert.ToDecimal((from f in db.Productos
                                                where f.Idproducto == id
                                                select f.Precio_venta).FirstOrDefault());
                    var carri = db.UpVenta(ob.Nom, 1, ob.pre, ob.desc, ob.var1);
                    return RedirectToAction("Cliente", "Home");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View();
                }
            }



        }
        public ActionResult DetalleCliente()
        {
            ViewBag.Nombre = Session["user"];
            ob.Nombre = Session["user"].ToString();
            ob.var1 = (from h in db.Usuario
                       where h.Nickusuario == ob.Nombre.Trim()
                       select h.Idusuario).FirstOrDefault();

            var Precompra = db.detalleCarrito(ob.var1);
            return View(Precompra.ToList());
        }
        public ActionResult ComprarCliente()
        {
            ViewBag.Nombre = Session["user"];
            ob.Nombre = Session["user"].ToString();
            ob.var1 = (from h in db.Usuario
                       where h.Nickusuario == ob.Nombre.Trim()
                       select h.Idusuario).FirstOrDefault();

            var Monto = db.MontoTotalPagar(ob.var1);
            return View(Monto.ToList());
        }
        public ActionResult Borrardor(int? id)
        {

            if (id == null)
            {

            }
            ViewBag.Nombre = Session["user"];
           
            var Retorn = db.selecciondeProduct(id);

            return View(Retorn.ToList());
        }
        
             public ActionResult ConfirmBorrarClient()
        {
            ob.va = Convert.ToInt32(Request.Form["txtidVenta"].ToString());
            ob.Nom = Request.Form["txtpro"].ToString();
            ob.var= Convert.ToInt32(Request.Form["txtcant"].ToString()); 
            db.EditarActualizarStocksuma(ob.Nom, ob.var);
            var dl = db.deletecarrito(ob.va);
            return RedirectToAction("CarritoCliente", "Home");
        }
        public ActionResult PerfilCliente()
        {
            ob.seleccion = Session["user"].ToString();
            ViewBag.Nombre = Session["user"];
            if (ob.seleccion == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var perf = db.Perfil(ob.seleccion);
            return View(perf.ToList());
        }
        public ActionResult EditarCliente(int? id)
        {
            if (id == null)
            {

            }


            var Retorn = db.selecciondeProduct(id);

            return View(Retorn.ToList());
        }
        public ActionResult ActualizarCarroCliente()
        {
            ob.va = Convert.ToInt32(Request.Form["txtidVenta"].ToString());
            ob.var1 = Convert.ToInt32(Request.Form["txtcantidad"].ToString());
            var Actualizar = db.actualizarcarrito(ob.var1, ob.va);
            ob.var1 = ob.var1 - 1;
            ob.seleccion = Request.Form["NombreProduct"].ToString();
            db.EditarActualizarStock(ob.seleccion, ob.var1);
            return RedirectToAction("CarritoCliente", "Home");

        }
        public ActionResult FinalCliente()
        {
            return Content("Su Compra Se Realizo Correctamente");
        }
        public ActionResult Regist(string nombre, string nombreUser, string fecha, string sexo, string correo, string dirreccion, string telefono, string contra)
        {

            ob.Nombre = (from d in db.Usuario
                         where d.Nickusuario == nombreUser.Trim()
                         select d.Nickusuario).FirstOrDefault();
            if (nombreUser == ob.Nombre)
            {
                TempData["Respuesta"] = "No se puede Registrar con este Usuario, Ya existe Intente Con otro Nick";

                return RedirectToAction("ValidarRegistro", "Home");
            }

            var Reg = db.RegistrarNew(nombre, nombreUser,Convert.ToDateTime(fecha.ToString()), sexo, correo, dirreccion, telefono, contra,1);


            return RedirectToAction("Login", "Acceso");
        }
        public ActionResult ValidarRegistro()
        {
            ViewBag.Repues=TempData["Respuesta"];
            return View();
        }
        public ActionResult BuscardorCliente(string Bus)
        {
            try
            {
                if (Bus == "")
                {
                    ViewBag.Buscar=("Ingrese su busqueda");
                    return RedirectToAction("Cliente", "Home");

                }
                else
                {
                    ob.Nom = (from s in db.Productos
                              where s.NombreProducto == Bus.Trim()
                              select s.NombreProducto).FirstOrDefault();
                    ob.Nombre = (from j in db.Categorias
                                 where j.NombreCate == Bus.Trim()
                                 select j.NombreCate).FirstOrDefault();

                    if (ob.Nombre == null)
                    {

                        var busqueda = db.BuscadorMejorado(ob.Nom, "");
                        return View(busqueda.ToList());
                    }
                    else if (ob.Nom == null)
                    {
                        var busqueda = db.BuscadorMejorado("", ob.Nombre);
                        return View(busqueda.ToList());
                    }
                    else if (ob.Nom == null && ob.Nombre == null)
                    {
                        ViewBag.Buscar = ("Ingrese su busqueda");
                        return RedirectToAction("Cliente", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Se genero un Error" + ex.Message);
            }
            return View();

        }
        public ActionResult CarritoCliente2(string NombresProducto)
        {
            ViewBag.Nombre = Session["user"];
            if (NombresProducto == null)
            {
                try
                {
                    ViewBag.Error = "Paso un error al agregar a su carrito";
                    return RedirectToAction("Cliente", "Home");

                }
                catch (Exception ex)
                {
                    return View(ex);
                }
            }
            else
            {

                try
                {
                    ob.va = (from d in db.Productos
                             where d.NombreProducto == NombresProducto.Trim()
                             select d.Idproducto).FirstOrDefault();
                    db.ActualizarStock(ob.va);
                    ob.Nom = (from f in db.Productos
                              where f.Idproducto == ob.va
                              select f.NombreProducto).FirstOrDefault();
                    ob.Nombre = Session["user"].ToString();
                    ob.var1 = (from h in db.Usuario
                               where h.Nickusuario == ob.Nombre.Trim()
                               select h.Idusuario).FirstOrDefault();
                    ob.desc = (from f in db.Productos
                               where f.Idproducto == ob.va
                               select f.Descripcion).FirstOrDefault();
                    ob.pre = Convert.ToDecimal((from f in db.Productos
                                                where f.Idproducto == ob.va
                                                select f.Precio_venta).FirstOrDefault());
                    var carri = db.UpVenta(ob.Nom, 1, ob.pre, ob.desc, ob.var1);
                    return RedirectToAction("Cliente", "Home");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View();
                }
            }



        }
       
    }
}