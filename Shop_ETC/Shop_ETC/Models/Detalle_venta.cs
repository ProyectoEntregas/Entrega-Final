//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Detalle_venta
    {
        public int idVenta { get; set; }
        public string nombreProducto { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<decimal> precio { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> idUser { get; set; }
    }
}
