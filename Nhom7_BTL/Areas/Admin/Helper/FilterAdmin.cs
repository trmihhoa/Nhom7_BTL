using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nhom7_BTL.Helper
{
    public class FilterAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["idAdmin"])))
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                     { "controller", "Home" },
                     { "action", "Login" }
                });
                filterContext.HttpContext.Session["url-redirect"] =
                filterContext.HttpContext.Request.Url.AbsoluteUri;
            } 
            
        }

    }
}