using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lcq.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Bet()
        {
            string sql = "INSERT INTO BET(Account, before, after, input, salary) values()";

            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}