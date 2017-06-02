using BLL_9H;
using Helper_9H;
using IBLL_9H;
using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Areas.App.Controllers
{
    public class HomeController : Controller
    {
        private IAuthorizerInfoBLL authorizerInfoBLL = new AuthorizerInfoBLL();

        public ActionResult Index(int id)
        {
            AuthorizerInfoModel model = authorizerInfoBLL.GetModel(id);
            if (model != null)
            {
                CookieHelper.SetCookie("authorizer", model.ID.ToString());
                return View(model);
            }
            return new HttpStatusCodeResult(500);
        }
    }
}