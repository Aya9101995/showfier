using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MWCoreAPI.Controllers
{
    public class WelcomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            
            return View();
        }
    }
}
