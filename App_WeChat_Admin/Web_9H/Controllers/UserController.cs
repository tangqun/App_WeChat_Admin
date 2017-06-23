using BLL_9H;
using IBLL_9H;
using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace Web_9H.Controllers
{
    public class UserController : BaseController
    {
        private IUserInfoBLL userInfoBLL = new UserInfoBLL();

        public ActionResult List(int pageIndex = 1, int pageSize = 15)
        {
            PagedList<UserInfoModel> pagedList = userInfoBLL.GetPageList(pageIndex, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_AjaxSearchPost", pagedList);
            }
            return View(pagedList);
        }
    }
}