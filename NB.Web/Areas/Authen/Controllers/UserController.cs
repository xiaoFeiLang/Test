using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NB.Common;
using NB.Models.Authen.User;

namespace NB.Web.Areas.Authen.Controllers
{
    public class UserController : Controller
    {
        // GET: Authen/User
        public ActionResult Index()
        {
            var model = new UserModel();
            return View(model);
        }
    }
}