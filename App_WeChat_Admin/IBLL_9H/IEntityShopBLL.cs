using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace IBLL_9H
{
    public interface IEntityShopBLL
    {
        PagedList<EntityShopInfoModel> GetPageList(string authorizerAppID, int pageIndex, int pageSize);

        EntityShopInfoModel GetModel(string authorizerAppID, string poiID);
    }
}
