using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NB.Web.Common; 

namespace NB.Web.Areas.Authen.Controllers
{
    public class ModuleController : AdminController
    {
        // GET: Authen/Module
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult GetModuleLinkUrl(string term)
        {
            var model = ConfigSettingHelper.GetAllModuleLinkUrl().Where(t => t.LinkUrl.ToLower().Contains(term.ToLower())).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}