using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Areas.App.Controllers
{
    public class CardController : Controller
    {
        public ActionResult MemberIndex()
        {
            return View();
        }

        public ActionResult MemberAdd()
        {
            return View();
        }
    }
}