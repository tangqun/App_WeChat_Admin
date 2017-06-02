using Model_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL_9H
{
    public interface IAuthorizerInfoDAL
    {
        List<AuthorizerInfoModel> GetList(int userID);
        AuthorizerInfoModel GetModel(int id);
    }
}
