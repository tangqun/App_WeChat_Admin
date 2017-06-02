using BLL_9H;
using Helper_9H;
using IBLL_9H;
using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_9H.Controllers;

namespace Web_9H.Areas.App.Controllers
{
    public class AppBaseController : BaseController
    {
        private IAuthorizerInfoBLL authorizerInfoBLL = new AuthorizerInfoBLL();
        protected AuthorizerInfoModel CurrentAuthorizer { get; set; }

        protected override void OnAppActionExecuting(ActionExecutingContext filterContext)
        {
            string authorizer = CookieHelper.GetCookie("authorizer");
            if (!string.IsNullOrEmpty(authorizer))
            {
                AuthorizerInfoModel model = authorizerInfoBLL.GetModel(authorizer.ToInt());
                if (model != null)
                {
                    CurrentAuthorizer = model;
                }
                else
                {
                    filterContext.Result = new HttpStatusCodeResult(500);
                }
            }
            else
            {
                filterContext.Result = new HttpStatusCodeResult(500);
            }

            base.OnAppActionExecuting(filterContext);
        }
    }
}