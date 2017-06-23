using BLL_9H;
using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_9H.Areas.App.Controllers
{
    public class MediaController : AppBaseController
    {
        private IMediaBLL mediaBLL = new MediaBLL();

        public ActionResult UploadIMG()
        {
            return Content(mediaBLL.UploadIMG(CurrentAuthorizer.AuthorizerAppID, Request.Files));
        }
    }
}