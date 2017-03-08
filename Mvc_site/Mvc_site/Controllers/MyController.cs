using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;

namespace Mvc_site.Controllers
{
    public class MyController
    {
        public void Execute(RequestContext requestContext)
        {
                string ip = requestContext.HttpContext.Request.UserHostAddress;
                var response = requestContext.HttpContext.Response;
                response.Write("<h2> Ваш IP: " + ip + "/<h2>");
        }
        
    }
}