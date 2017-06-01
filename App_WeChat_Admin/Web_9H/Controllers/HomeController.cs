using BLL_9H;
using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Controllers
{
    public class HomeController : Controller
    {
        private IUserInfoBLL userInfoBLL = new UserInfoBLL();

        public ActionResult Index()
        {
            return View();
        }
    }
}