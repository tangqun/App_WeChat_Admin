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
        public ActionResult MemberCardList()
        {
            return View();
        }

        public ActionResult MemberCardCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberCardCreate(MemberCardModel model)
        {
            return Content("", "");
        }
    }
}