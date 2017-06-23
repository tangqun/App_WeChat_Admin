using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Helper_9H;
using Model_9H;
using Newtonsoft.Json;
using IDAL_9H;
using DAL_9H;

namespace BLL_9H
{
    public class MediaBLL : IMediaBLL
    {
        private IAccessTokenDAL accessTokenDAL = new AccessTokenDAL();
        private ICodeMsgDAL codeMsgDAL = new CodeMsgDAL();

        public string UploadIMG(string authorizerAppID, HttpFileCollectionBase files)
        {
            try
            {
                if (files != null)
                {
                    HttpPostedFileBase file = files[0];
                    float mbSize = (float)file.ContentLength / 1048576;
                    if (mbSize <= 1)
                    {
                        string accessToken = accessTokenDAL.Get(authorizerAppID);
                        string url = "https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token=" + accessToken;

                        LogHelper.Info("上传图片 url", url);

                        //UploadIMGReq req = new UploadIMGReq()
                        //{
                        //    Buffer = file.InputStream
                        //};
                        //string requestBody = JsonConvert.SerializeObject(req);

                        //LogHelper.Info("上传图片 requestBody", requestBody);

                        string responseBody = HttpHelper.Post(url, file.FileName, file.InputStream);

                        LogHelper.Info("上传图片 responseBody", responseBody);

                        UploadIMGResp resp = JsonConvert.DeserializeObject<UploadIMGResp>(responseBody);

                        if (resp.ErrCode == 0)
                        {
                            return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.成功, Msg = string.Format(codeMsgDAL.GetByCode((int)CodeEnum.成功), "上传成功"), Data = resp.Url });
                        }
                        else
                        {
                            string msg = "errcode: " + resp.ErrCode + ", errmsg: " + resp.ErrMsg;
                            return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.失败, Msg = string.Format(codeMsgDAL.GetByCode((int)CodeEnum.失败), msg) });
                        }
                    }
                    return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.文件大小超限, Msg = codeMsgDAL.GetByCode((int)CodeEnum.文件大小超限) });
                }
                return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.文件集合为空, Msg = codeMsgDAL.GetByCode((int)CodeEnum.文件集合为空) });
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.系统异常, Msg = codeMsgDAL.GetByCode((int)CodeEnum.系统异常) });
            }
        }
    }
}
