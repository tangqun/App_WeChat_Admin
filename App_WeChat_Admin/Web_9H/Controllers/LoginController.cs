using BLL_9H;
using IBLL_9H;
using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Controllers
{
    public class LoginController : Controller
    {
        private IAdminInfoBLL adminInfoBLL = new AdminInfoBLL();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            RESTfulModel restfulModel = adminInfoBLL.Login(model);
            if (restfulModel.Code == 0)
            {
                Session["admin"] = restfulModel.Data as AdminInfoModel;
            }

            return Content(restfulModel.ToString(), "application/json");
        }
    }
}