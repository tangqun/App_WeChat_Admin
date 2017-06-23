using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_9H;
using IDAL_9H;
using DAL_9H;
using Helper_9H;

namespace BLL_9H
{
    public class AdminInfoBLL : IAdminInfoBLL
    {
        private ICodeMsgDAL codeMsgDAL = new CodeMsgDAL();
        private IAdminInfoDAL adminInfoDAL = new AdminInfoDAL();

        public RESTfulModel Login(LoginModel model)
        {
            try
            {
                // 字段验证

                AdminInfoModel adminInfoModel = adminInfoDAL.GetModel(model.Mobile);
                if (adminInfoModel != null)
                {
                    string pwd = EncryptHelper.MD5Encrypt(ConfigHelper.Salt + EncryptHelper.MD5Encrypt(model.Password));

                    if (adminInfoModel.Password == pwd)
                    {
                        return new RESTfulModel() { Code = (int)CodeEnum.成功, Msg = string.Format(codeMsgDAL.GetByCode((int)CodeEnum.成功), "登陆成功"), Data = adminInfoModel };
                    }
                    else
                    {
                        return new RESTfulModel() { Code = (int)CodeEnum.密码错误, Msg = codeMsgDAL.GetByCode((int)CodeEnum.密码错误) };
                    }
                }
                else
                {
                    return new RESTfulModel() { Code = (int)CodeEnum.账号不存在, Msg = codeMsgDAL.GetByCode((int)CodeEnum.账号不存在) };
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return new RESTfulModel() { Code = (int)CodeEnum.系统异常, Msg = codeMsgDAL.GetByCode((int)CodeEnum.系统异常) };
            }
        }
    }
}
