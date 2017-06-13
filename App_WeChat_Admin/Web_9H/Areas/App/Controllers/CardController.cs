using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Areas.App.Controllers
{
    public class CardController : Controller
    {
        public ActionResult MemberList()
        {
            return View();
        }

        public ActionResult MemberAdd()
        {
            return View();
        }

        public ActionResult MemberAdd(MemberCardModel model)
        {
            return Content("", "");
        }
    }
}