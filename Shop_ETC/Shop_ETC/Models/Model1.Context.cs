﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shop_ETC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SITIOWEBEntities : DbContext
    {
        public SITIOWEBEntities()
            : base("name=SITIOWEBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<Detalle_venta> Detalle_venta { get; set; }
        public virtual DbSet<Envios> Envios { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
        public virtual DbSet<VentasRealizadas> VentasRealizadas { get; set; }
    
        public virtual ObjectResult<Carrito_Result> Carrito(string user)
        {
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Carrito_Result>("Carrito", userParameter);
        }
    
        public virtual ObjectResult<string> inicioSesion(string nom_user, string pass)
        {
            var nom_userParameter = nom_user != null ?
                new ObjectParameter("nom_user", nom_user) :
                new ObjectParameter("nom_user", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("inicioSesion", nom_userParameter, passParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> seleccionar(string user)
        {
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("seleccionar", userParameter);
        }
    
        public virtual int UpVenta(string nom, Nullable<int> cant, Nullable<decimal> pr, string desc, Nullable<int> idu)
        {
            var nomParameter = nom != null ?
                new ObjectParameter("nom", nom) :
                new ObjectParameter("nom", typeof(string));
    
            var cantParameter = cant.HasValue ?
                new ObjectParameter("cant", cant) :
                new ObjectParameter("cant", typeof(int));
    
            var prParameter = pr.HasValue ?
                new ObjectParameter("Pr", pr) :
                new ObjectParameter("Pr", typeof(decimal));
    
            var descParameter = desc != null ?
                new ObjectParameter("desc", desc) :
                new ObjectParameter("desc", typeof(string));
    
            var iduParameter = idu.HasValue ?
                new ObjectParameter("idu", idu) :
                new ObjectParameter("idu", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpVenta", nomParameter, cantParameter, prParameter, descParameter, iduParameter);
        }
    
        public virtual ObjectResult<Carrito1_Result> Carrito1(string user)
        {
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Carrito1_Result>("Carrito1", userParameter);
        }
    
        public virtual ObjectResult<selecciondeProduct_Result> selecciondeProduct(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<selecciondeProduct_Result>("selecciondeProduct", idParameter);
        }
    
        public virtual int actualizarcarrito(Nullable<int> cant, Nullable<int> idv)
        {
            var cantParameter = cant.HasValue ?
                new ObjectParameter("cant", cant) :
                new ObjectParameter("cant", typeof(int));
    
            var idvParameter = idv.HasValue ?
                new ObjectParameter("idv", idv) :
                new ObjectParameter("idv", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("actualizarcarrito", cantParameter, idvParameter);
        }
    
        public virtual int deletecarrito(Nullable<int> idv)
        {
            var idvParameter = idv.HasValue ?
                new ObjectParameter("idv", idv) :
                new ObjectParameter("idv", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deletecarrito", idvParameter);
        }
    
        public virtual ObjectResult<detailCarrito_Result> detailCarrito(Nullable<int> idUs)
        {
            var idUsParameter = idUs.HasValue ?
                new ObjectParameter("idUs", idUs) :
                new ObjectParameter("idUs", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<detailCarrito_Result>("detailCarrito", idUsParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> Monto(Nullable<int> idU)
        {
            var idUParameter = idU.HasValue ?
                new ObjectParameter("idU", idU) :
                new ObjectParameter("idU", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("Monto", idUParameter);
        }
    
        public virtual ObjectResult<MontoTotal_Result> MontoTotal(Nullable<int> idU)
        {
            var idUParameter = idU.HasValue ?
                new ObjectParameter("idU", idU) :
                new ObjectParameter("idU", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MontoTotal_Result>("MontoTotal", idUParameter);
        }
    
        public virtual ObjectResult<MontoTotalPagar_Result> MontoTotalPagar(Nullable<int> idUs)
        {
            var idUsParameter = idUs.HasValue ?
                new ObjectParameter("idUs", idUs) :
                new ObjectParameter("idUs", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MontoTotalPagar_Result>("MontoTotalPagar", idUsParameter);
        }
    
        public virtual ObjectResult<detalleCarrito_Result> detalleCarrito(Nullable<int> idUsi)
        {
            var idUsiParameter = idUsi.HasValue ?
                new ObjectParameter("idUsi", idUsi) :
                new ObjectParameter("idUsi", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<detalleCarrito_Result>("detalleCarrito", idUsiParameter);
        }
    
        public virtual ObjectResult<Buscador_Result> Buscador(string busPro, string busCat)
        {
            var busProParameter = busPro != null ?
                new ObjectParameter("BusPro", busPro) :
                new ObjectParameter("BusPro", typeof(string));
    
            var busCatParameter = busCat != null ?
                new ObjectParameter("BusCat", busCat) :
                new ObjectParameter("BusCat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Buscador_Result>("Buscador", busProParameter, busCatParameter);
        }
    
        public virtual ObjectResult<BuscadorMejorado_Result> BuscadorMejorado(string busPro, string busCat)
        {
            var busProParameter = busPro != null ?
                new ObjectParameter("BusPro", busPro) :
                new ObjectParameter("BusPro", typeof(string));
    
            var busCatParameter = busCat != null ?
                new ObjectParameter("BusCat", busCat) :
                new ObjectParameter("BusCat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BuscadorMejorado_Result>("BuscadorMejorado", busProParameter, busCatParameter);
        }
    
        public virtual ObjectResult<Perfil_Result> Perfil(string quin)
        {
            var quinParameter = quin != null ?
                new ObjectParameter("Quin", quin) :
                new ObjectParameter("Quin", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Perfil_Result>("Perfil", quinParameter);
        }
    
        public virtual int ActualizarStock(Nullable<int> numer)
        {
            var numerParameter = numer.HasValue ?
                new ObjectParameter("numer", numer) :
                new ObjectParameter("numer", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarStock", numerParameter);
        }
    
        public virtual int EditarActualizarStock(string u, Nullable<int> cant)
        {
            var uParameter = u != null ?
                new ObjectParameter("u", u) :
                new ObjectParameter("u", typeof(string));
    
            var cantParameter = cant.HasValue ?
                new ObjectParameter("cant", cant) :
                new ObjectParameter("cant", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditarActualizarStock", uParameter, cantParameter);
        }
    
        public virtual int Registrar(string nom, string nick, Nullable<System.DateTime> fN, string ge, string em, string dire, string tel, string c, Nullable<int> id)
        {
            var nomParameter = nom != null ?
                new ObjectParameter("nom", nom) :
                new ObjectParameter("nom", typeof(string));
    
            var nickParameter = nick != null ?
                new ObjectParameter("Nick", nick) :
                new ObjectParameter("Nick", typeof(string));
    
            var fNParameter = fN.HasValue ?
                new ObjectParameter("FN", fN) :
                new ObjectParameter("FN", typeof(System.DateTime));
    
            var geParameter = ge != null ?
                new ObjectParameter("ge", ge) :
                new ObjectParameter("ge", typeof(string));
    
            var emParameter = em != null ?
                new ObjectParameter("em", em) :
                new ObjectParameter("em", typeof(string));
    
            var direParameter = dire != null ?
                new ObjectParameter("Dire", dire) :
                new ObjectParameter("Dire", typeof(string));
    
            var telParameter = tel != null ?
                new ObjectParameter("Tel", tel) :
                new ObjectParameter("Tel", typeof(string));
    
            var cParameter = c != null ?
                new ObjectParameter("c", c) :
                new ObjectParameter("c", typeof(string));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Registrar", nomParameter, nickParameter, fNParameter, geParameter, emParameter, direParameter, telParameter, cParameter, idParameter);
        }
    
        public virtual int EditarActualizarStocksuma(string u, Nullable<int> cant)
        {
            var uParameter = u != null ?
                new ObjectParameter("u", u) :
                new ObjectParameter("u", typeof(string));
    
            var cantParameter = cant.HasValue ?
                new ObjectParameter("cant", cant) :
                new ObjectParameter("cant", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditarActualizarStocksuma", uParameter, cantParameter);
        }
    
        public virtual int RegistrarNew(string nom, string nick, Nullable<System.DateTime> fN, string ge, string em, string dire, string tel, string c, Nullable<int> id)
        {
            var nomParameter = nom != null ?
                new ObjectParameter("nom", nom) :
                new ObjectParameter("nom", typeof(string));
    
            var nickParameter = nick != null ?
                new ObjectParameter("Nick", nick) :
                new ObjectParameter("Nick", typeof(string));
    
            var fNParameter = fN.HasValue ?
                new ObjectParameter("FN", fN) :
                new ObjectParameter("FN", typeof(System.DateTime));
    
            var geParameter = ge != null ?
                new ObjectParameter("ge", ge) :
                new ObjectParameter("ge", typeof(string));
    
            var emParameter = em != null ?
                new ObjectParameter("em", em) :
                new ObjectParameter("em", typeof(string));
    
            var direParameter = dire != null ?
                new ObjectParameter("Dire", dire) :
                new ObjectParameter("Dire", typeof(string));
    
            var telParameter = tel != null ?
                new ObjectParameter("Tel", tel) :
                new ObjectParameter("Tel", typeof(string));
    
            var cParameter = c != null ?
                new ObjectParameter("c", c) :
                new ObjectParameter("c", typeof(string));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RegistrarNew", nomParameter, nickParameter, fNParameter, geParameter, emParameter, direParameter, telParameter, cParameter, idParameter);
        }
    
        public virtual int UpdateUsuario(string ren, string nu, string nk, Nullable<System.DateTime> fcn, string gnr, string emal, string drc, string telf)
        {
            var renParameter = ren != null ?
                new ObjectParameter("ren", ren) :
                new ObjectParameter("ren", typeof(string));
    
            var nuParameter = nu != null ?
                new ObjectParameter("nu", nu) :
                new ObjectParameter("nu", typeof(string));
    
            var nkParameter = nk != null ?
                new ObjectParameter("nk", nk) :
                new ObjectParameter("nk", typeof(string));
    
            var fcnParameter = fcn.HasValue ?
                new ObjectParameter("fcn", fcn) :
                new ObjectParameter("fcn", typeof(System.DateTime));
    
            var gnrParameter = gnr != null ?
                new ObjectParameter("gnr", gnr) :
                new ObjectParameter("gnr", typeof(string));
    
            var emalParameter = emal != null ?
                new ObjectParameter("emal", emal) :
                new ObjectParameter("emal", typeof(string));
    
            var drcParameter = drc != null ?
                new ObjectParameter("Drc", drc) :
                new ObjectParameter("Drc", typeof(string));
    
            var telfParameter = telf != null ?
                new ObjectParameter("Telf", telf) :
                new ObjectParameter("Telf", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateUsuario", renParameter, nuParameter, nkParameter, fcnParameter, gnrParameter, emalParameter, drcParameter, telfParameter);
        }
    
        public virtual int Final(string descr, string nameus, Nullable<decimal> mot, Nullable<int> isd)
        {
            var descrParameter = descr != null ?
                new ObjectParameter("descr", descr) :
                new ObjectParameter("descr", typeof(string));
    
            var nameusParameter = nameus != null ?
                new ObjectParameter("nameus", nameus) :
                new ObjectParameter("nameus", typeof(string));
    
            var motParameter = mot.HasValue ?
                new ObjectParameter("mot", mot) :
                new ObjectParameter("mot", typeof(decimal));
    
            var isdParameter = isd.HasValue ?
                new ObjectParameter("isd", isd) :
                new ObjectParameter("isd", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Final", descrParameter, nameusParameter, motParameter, isdParameter);
        }
    
        public virtual ObjectResult<string> agrp(Nullable<int> idva)
        {
            var idvaParameter = idva.HasValue ?
                new ObjectParameter("idva", idva) :
                new ObjectParameter("idva", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("agrp", idvaParameter);
        }
    
        public virtual int facturar(string desc, Nullable<System.DateTime> f, string ctn, Nullable<decimal> mT, Nullable<int> idcpr)
        {
            var descParameter = desc != null ?
                new ObjectParameter("desc", desc) :
                new ObjectParameter("desc", typeof(string));
    
            var fParameter = f.HasValue ?
                new ObjectParameter("f", f) :
                new ObjectParameter("f", typeof(System.DateTime));
    
            var ctnParameter = ctn != null ?
                new ObjectParameter("ctn", ctn) :
                new ObjectParameter("ctn", typeof(string));
    
            var mTParameter = mT.HasValue ?
                new ObjectParameter("MT", mT) :
                new ObjectParameter("MT", typeof(decimal));
    
            var idcprParameter = idcpr.HasValue ?
                new ObjectParameter("idcpr", idcpr) :
                new ObjectParameter("idcpr", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("facturar", descParameter, fParameter, ctnParameter, mTParameter, idcprParameter);
        }
    
        public virtual int miCarroalcomprar(Nullable<int> isd, string npt)
        {
            var isdParameter = isd.HasValue ?
                new ObjectParameter("isd", isd) :
                new ObjectParameter("isd", typeof(int));
    
            var nptParameter = npt != null ?
                new ObjectParameter("npt", npt) :
                new ObjectParameter("npt", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("miCarroalcomprar", isdParameter, nptParameter);
        }
    
        public virtual ObjectResult<facpdf_Result> facpdf(Nullable<int> di)
        {
            var diParameter = di.HasValue ?
                new ObjectParameter("di", di) :
                new ObjectParameter("di", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<facpdf_Result>("facpdf", diParameter);
        }
    
        public virtual int UpdateVenta(string esta, Nullable<int> idVent)
        {
            var estaParameter = esta != null ?
                new ObjectParameter("esta", esta) :
                new ObjectParameter("esta", typeof(string));
    
            var idVentParameter = idVent.HasValue ?
                new ObjectParameter("idVent", idVent) :
                new ObjectParameter("idVent", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateVenta", estaParameter, idVentParameter);
        }
    
        public virtual int UpdateVentaM(string est, Nullable<int> idVen)
        {
            var estParameter = est != null ?
                new ObjectParameter("est", est) :
                new ObjectParameter("est", typeof(string));
    
            var idVenParameter = idVen.HasValue ?
                new ObjectParameter("idVen", idVen) :
                new ObjectParameter("idVen", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateVentaM", estParameter, idVenParameter);
        }
    
        public virtual int UpdateVentaTotal(string descripcion, string esta, Nullable<decimal> monto, Nullable<System.DateTime> fech, Nullable<int> cpid, Nullable<int> idVent)
        {
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var estaParameter = esta != null ?
                new ObjectParameter("esta", esta) :
                new ObjectParameter("esta", typeof(string));
    
            var montoParameter = monto.HasValue ?
                new ObjectParameter("Monto", monto) :
                new ObjectParameter("Monto", typeof(decimal));
    
            var fechParameter = fech.HasValue ?
                new ObjectParameter("fech", fech) :
                new ObjectParameter("fech", typeof(System.DateTime));
    
            var cpidParameter = cpid.HasValue ?
                new ObjectParameter("cpid", cpid) :
                new ObjectParameter("cpid", typeof(int));
    
            var idVentParameter = idVent.HasValue ?
                new ObjectParameter("idVent", idVent) :
                new ObjectParameter("idVent", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateVentaTotal", descripcionParameter, estaParameter, montoParameter, fechParameter, cpidParameter, idVentParameter);
        }
    
        public virtual int BorrarVenta(Nullable<int> i)
        {
            var iParameter = i.HasValue ?
                new ObjectParameter("i", i) :
                new ObjectParameter("i", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("BorrarVenta", iParameter);
        }
    }
}
