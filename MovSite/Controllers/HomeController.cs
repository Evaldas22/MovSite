using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovSite.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        //// enable Attribute routing in RouteConfig.cs by routes.MapMvcAttributeRoutes();
        //[Route("home/test/{year:regex(\\d{4})}/{month:range(1, 12)}")]
        //public ActionResult Test(int year, byte month)
        //{
        //    return Content($"Year: {year}, month: {month}");
        //}
    }
}