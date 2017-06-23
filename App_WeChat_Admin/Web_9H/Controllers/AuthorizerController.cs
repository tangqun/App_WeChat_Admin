using BLL_9H;
using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Controllers
{
    public class AuthorizerController : BaseController
    {
        private IAuthorizerInfoBLL authorizerInfoBLL = new AuthorizerInfoBLL();

        public ActionResult List(string id)
        {
            return View(authorizerInfoBLL.GetList(id));
        }
    }
}