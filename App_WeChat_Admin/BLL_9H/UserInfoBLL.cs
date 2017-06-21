using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_9H;
using DAL_9H;
using IDAL_9H;
using Helper_9H;
using Webdiyer.WebControls.Mvc;

namespace BLL_9H
{
    public class UserInfoBLL : IUserInfoBLL
    {
        private IUserInfoDAL userInfoDAL = new UserInfoDAL();

        public PagedList<UserInfoModel> GetPageList(int pageIndex, int pageSize)
        {
            try
            {
                int totalCount;
                List<UserInfoModel> modelList = userInfoDAL.GetPageList(pageIndex, pageSize, out totalCount);
                return new PagedList<UserInfoModel>(modelList, pageIndex, pageSize, totalCount);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return null;
            }
        }
    }
}
