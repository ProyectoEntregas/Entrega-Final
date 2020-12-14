using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop_ETC.Controllers;
using Shop_ETC.Models;
using System.Web.Mvc;

namespace Shop_ETC.Filters
{
    public class VerificarSesion:ActionFilterAttribute
    { 
       public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var VarUser = (Usuario)HttpContext.Current.Session["user"];
            if (VarUser == null)
            {
                if(filterContext.Controller is AccesoController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acceso/Login");
                }
                else
                if(filterContext.Controller is AccesoController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);

        }
    }
}