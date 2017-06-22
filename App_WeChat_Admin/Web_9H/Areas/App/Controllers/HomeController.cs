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

        public ActionResult Index(string id)
        {
            AuthorizerInfoModel model = authorizerInfoBLL.GetModel(id);
            if (model != null)
            {
                Session["authorizer"] = model;
                return View(model);
            }
            return new HttpStatusCodeResult(404);
        }
    }
}