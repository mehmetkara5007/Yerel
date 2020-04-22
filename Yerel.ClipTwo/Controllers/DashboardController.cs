using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yerel.ClipTwo.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Monitore()
        {
            return View();
        }

        public ActionResult Integrate()
        {
            return View();
        }
    }
}