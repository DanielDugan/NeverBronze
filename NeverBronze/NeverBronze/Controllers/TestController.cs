using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeverBronze.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string Detail()
        {
            return "Hello, World!";
        }
    }
}