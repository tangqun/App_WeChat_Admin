using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Areas.App.Controllers
{
    public class MaterialController : AppBaseController
    {
        public ActionResult NewsList()
        {
            return View();
        }

        public ActionResult FileList()
        {
            return View();
        }
    }
}