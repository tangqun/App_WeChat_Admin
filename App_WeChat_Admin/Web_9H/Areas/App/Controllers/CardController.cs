using BLL_9H;
using IBLL_9H;
using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Areas.App.Controllers
{
    public class CardController : AppBaseController
    {
        private ICardBLL cardBLL = new CardBLL();

        public ActionResult MemberCardList()
        {
            return View(cardBLL.GetList(CurrentAuthorizer.AuthorizerAppID));
        }

        public ActionResult MemberCardCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberCardCreate(MemberCardModel model)
        {
            return Content(cardBLL.Create(CurrentAuthorizer.AuthorizerAppID, model), "application/json");
        }
    }
}