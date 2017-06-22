using BLL_9H;
using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Areas.App.Controllers
{
    public class EntityShopController : AppBaseController
    {
        private IEntityShopBLL entityShopBLL = new EntityShopBLL();

        public ActionResult List(int pageIndex = 1, int pageSize = 16)
        {
            return View(entityShopBLL.GetPageList(CurrentAuthorizer.AuthorizerAppID, pageIndex, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}