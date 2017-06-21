using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Controllers
{
    public class BaseController : Controller
    {
        protected AdminInfoModel CurrentUser { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session != null && Session["admin"] != null)
            {
                CurrentUser = Session["admin"] as AdminInfoModel;
            }
            else
            {
                filterContext.Result = new HttpStatusCodeResult(500);
            }

            OnAppActionExecuting(filterContext);

            base.OnActionExecuting(filterContext);
        }

        protected virtual void OnAppActionExecuting(ActionExecutingContext filterContext)
        {

        }
    }
}