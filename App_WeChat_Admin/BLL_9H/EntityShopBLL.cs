using IBLL_9H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_9H;
using Helper_9H;
using Webdiyer.WebControls.Mvc;
using IDAL_9H;
using DAL_9H;
using Newtonsoft.Json;

namespace BLL_9H
{
    public class EntityShopBLL : IEntityShopBLL
    {
        private IAccessTokenDAL accessTokenDAL = new AccessTokenDAL();

        public PagedList<EntityShopInfoModel> GetPageList(string authorizerAppID, int pageIndex, int pageSize)
        {
            try
            {
                string accessToken = accessTokenDAL.Get(authorizerAppID);
                string url = "https://api.weixin.qq.com/cgi-bin/poi/getpoilist?access_token=" + accessToken;

                LogHelper.Info("3.5查询门店列表 url", url);

                EntityShopListGetReq req = new EntityShopListGetReq()
                {
                    Begin = pageIndex,
                    Limit = pageSize,
                };
                string requestBody = JsonConvert.SerializeObject(req);

                LogHelper.Info("3.5查询门店列表 requestBody", requestBody);

                //string responseBody = HttpHelper.Post(url, requestBody);

                //LogHelper.Info("3.5查询门店列表 responseBody", responseBody);

                string responseBody = "{\"errcode\":0,\"errmsg\":\"ok\",\"business_list\":[{\"base_info\":{\"sid\":\"\",\"business_name\":\"朝外MEN写字楼\",\"branch_name\":\"\",\"address\":\"朝外大街26号\",\"telephone\":\"15210470906\",\"categories\":[\"公司企业,企业/工厂\"],\"city\":\"北京市\",\"province\":\"\",\"offset_type\":1,\"longitude\":116.442108154,\"latitude\":39.9230194092,\"photo_list\":[{\"photo_url\":\"http://mmbiz.qpic.cn/mmbiz_png/jTItpJe45JLNBQjKKiapJicznbYVMicDXGzs4EaNVgiao57JSlLgYxrh1OplMF8tr8DJ7RmlAeJmv1h22EePgSl1OQ/0?wx_fmt=png\"}],\"introduction\":\"\",\"recommend\":\"\",\"special\":\"\",\"open_time\":\"10:00-21:00\",\"avg_price\":100,\"poi_id\":\"468757507\",\"available_state\":3,\"district\":\"朝阳区\",\"update_status\":0,\"qualification_list\":[]}}],\"total_count\":1}";

                EntityShopListGetResp resp = JsonConvert.DeserializeObject<EntityShopListGetResp>(responseBody);

                // 直接处理，api 需要返回错误码
                List<EntityShop> entityShopList = resp.BusinessList;
                
                List<EntityShopInfoModel> modelList = new List<EntityShopInfoModel>();
                if (entityShopList != null && entityShopList.Any())
                {
                    List<EntityShopInfo> entityShopInfoList = entityShopList.Select(o => o.BaseInfo).ToList();
                    foreach (var entityShopInfo in entityShopInfoList)
                    {
                        modelList.Add(new EntityShopInfoModel() {
                            SID = entityShopInfo.SID,
                            BusinessName = entityShopInfo.BusinessName,
                            BranchName = entityShopInfo.BranchName,
                            Address = entityShopInfo.Address,
                            Telephone = entityShopInfo.Telephone,
                            Categories = entityShopInfo.Categories,
                            City = entityShopInfo.City,
                            Province = entityShopInfo.Province,
                            OffsetType = entityShopInfo.OffsetType,
                            Longitude = entityShopInfo.Longitude,
                            Latitude = entityShopInfo.Latitude,
                            PhotoList = entityShopInfo.PhotoList.Select(o=> o.PhotoUrl).ToList(),
                            Introduction = entityShopInfo.Introduction,
                            Recomend = entityShopInfo.Recomend,
                            Special = entityShopInfo.Special,
                            OpenTime = entityShopInfo.OpenTime,
                            AvgPrice = entityShopInfo.AvgPrice,
                            PoiID = entityShopInfo.PoiID,
                            AvailableState = entityShopInfo.AvailableState,
                            District = entityShopInfo.District,
                            UpdateStatus = entityShopInfo.UpdateStatus
                        });
                    }
                }

                return new PagedList<EntityShopInfoModel>(modelList, pageIndex, pageSize, resp.TotalCount);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return null;
            }
        }

        public EntityShopInfoModel GetModel(string authorizerAppID, string poiID)
        {
            try
            {
                string accessToken = accessTokenDAL.Get(authorizerAppID);
                string url = "http://api.weixin.qq.com/cgi-bin/poi/getpoi?access_token=" + accessToken;

                LogHelper.Info("3.4查询门店信息 url", url);

                EntityShopGetReq req = new EntityShopGetReq() {
                    PoiID = poiID
                };
                string requestBody = JsonConvert.SerializeObject(req);

                LogHelper.Info("3.4查询门店信息 requestBody", requestBody);

                //string responseBody = HttpHelper.Post(url, requestBody);

                //LogHelper.Info("3.4查询门店信息 responseBody", responseBody);

                string responseBody = "{\"errcode\":0,\"errmsg\":\"ok\",\"business\":{\"base_info\":{\"sid\":\"\",\"business_name\":\"朝外MEN写字楼\",\"branch_name\":\"\",\"address\":\"朝外大街26号\",\"telephone\":\"15210470906\",\"categories\":[\"公司企业,企业/工厂\"],\"city\":\"北京市\",\"province\":\"\",\"offset_type\":1,\"longitude\":116.442108154,\"latitude\":39.9230194092,\"photo_list\":[{\"photo_url\":\"http://mmbiz.qpic.cn/mmbiz_png/jTItpJe45JLNBQjKKiapJicznbYVMicDXGzs4EaNVgiao57JSlLgYxrh1OplMF8tr8DJ7RmlAeJmv1h22EePgSl1OQ/0?wx_fmt=png\"}],\"introduction\":\"\",\"recommend\":\"\",\"special\":\"\",\"open_time\":\"10:00-21:00\",\"avg_price\":100,\"poi_id\":\"468757507\",\"available_state\":3,\"district\":\"朝阳区\",\"update_status\":0,\"qualification_list\":[]}}}";

                EntityShopGetResp resp = JsonConvert.DeserializeObject<EntityShopGetResp>(responseBody);

                var entityShopInfo = resp.Business.BaseInfo;

                return new EntityShopInfoModel() {
                    SID = entityShopInfo.SID,
                    BusinessName = entityShopInfo.BusinessName,
                    BranchName = entityShopInfo.BranchName,
                    Address = entityShopInfo.Address,
                    Telephone = entityShopInfo.Telephone,
                    Categories = entityShopInfo.Categories,
                    City = entityShopInfo.City,
                    Province = entityShopInfo.Province,
                    OffsetType = entityShopInfo.OffsetType,
                    Longitude = entityShopInfo.Longitude,
                    Latitude = entityShopInfo.Latitude,
                    PhotoList = entityShopInfo.PhotoList.Select(o => o.PhotoUrl).ToList(),
                    Introduction = entityShopInfo.Introduction,
                    Recomend = entityShopInfo.Recomend,
                    Special = entityShopInfo.Special,
                    OpenTime = entityShopInfo.OpenTime,
                    AvgPrice = entityShopInfo.AvgPrice,
                    PoiID = entityShopInfo.PoiID,
                    AvailableState = entityShopInfo.AvailableState,
                    District = entityShopInfo.District,
                    UpdateStatus = entityShopInfo.UpdateStatus
                };
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return null;
            }
        }
    }
}
