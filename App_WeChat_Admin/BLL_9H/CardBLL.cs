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
using Newtonsoft.Json;

namespace BLL_9H
{
    public class CardBLL : ICardBLL
    {
        private IAccessTokenDAL accessTokenDAL = new AccessTokenDAL();
        private ICodeMsgDAL codeMsgDAL = new CodeMsgDAL();
        private ICardInfoDAL cardInfoDAL = new CardInfoDAL();

        public string Create(string authorizerAppID, MemberCardModel model)
        {
            try
            {
                Card card = new Card()
                {
                    CardType = "MEMBER_CARD",
                    MemberCard = new MemberCard()
                    {
                        BackgroundPicUrl = model.BackGroundPicUrl,
                        BaseInfo = new MemberCardBaseInfo()
                        {
                            LogoUrl = model.LogoUrl,
                            BrandName = model.BrandName,
                            CodeType = "CODE_TYPE_QRCODE",
                            Title = model.Title,
                            Color = "Color010",
                            Notice = model.Notice,
                            ServicePhone = model.ServicePhone,
                            Description = model.Description,

                            DateInfo = new DataInfo() { Type = "DATE_TYPE_PERMANENT" },
                            Sku = new Sku() { Quantity = 100000000 },

                            GetLimit = 1,
                            CanGiveFriend = false,
                            CanShare = false,

                            UseCustomCode = true,
                            UseAllLocations = true,

                            CenterTitle = "会员买单",
                            CenterSubTitle = "买单立享" + model.Discount + "折，更有积分相送",
                            CenterUrl = string.Format(ConfigHelper.DomainWeChat, authorizerAppID) + "gopay"

                            // custom_url_name
                            // custom_url
                            // custom_url_sub_title
                            // promotion_url_name
                            // promotion_url
                            // promotion_url_sub_title

                            // need_push_on_view
                        },
                        AdvancedInfo = new MemberCardAdvancedInfo()
                        {
                            BusinessService = new List<string>()
                        {
                            "BIZ_SERVICE_FREE_WIFI",
                            "BIZ_SERVICE_WITH_PET",
                            "BIZ_SERVICE_FREE_PARK",
                            "BIZ_SERVICE_DELIVER"
                        }
                        },
                        // 会员卡特权说明
                        Prerogative = model.Prerogative,

                        // 激活相关
                        AutoActivate = false,
                        WXActivate = false,
                        ActivateUrl = "",

                        // 是否支持储值
                        SupplyBalance = false,

                        CustomField1 = new CustomField()
                        {
                            // 不行就用 Name , 积分变动触发 is_notify_bonus
                            // 其他两个触发 is_notify_custom_field2 is_notify_custom_field3
                            NameType = "FIELD_NAME_TYPE_STAMP",
                            Url = string.Format(ConfigHelper.DomainWeChat, authorizerAppID) + "bonus"
                        },
                        CustomField2 = new CustomField()
                        {
                            NameType = "FIELD_NAME_TYPE_LEVEL",
                            Url = string.Format(ConfigHelper.DomainWeChat, authorizerAppID) + "level"
                        },
                        CustomField3 = new CustomField()
                        {
                            NameType = "FIELD_NAME_TYPE_COUPON",
                            Url = string.Format(ConfigHelper.DomainWeChat, authorizerAppID) + "coupon"
                        },

                        // 积分相关
                        SupplyBonus = true,
                        BonusRule = new BonusRule()
                        {
                            // 满
                            CostMoneyUnit = model.CostMoneyUnit,
                            // 送
                            IncreaseBonus = model.IncreaseBonus,
                            MaxIncreaseBonus = model.MaxIncreaseBonus,
                            InitIncreaseBonus = model.InitIncreaseBonus,
                            // 用
                            CostBonusUnit = model.CostBonusUnit,
                            // 抵
                            ReduceMoney = model.ReduceMoney,
                            // 抵扣条件，满
                            LeastMoneyToUseBonus = model.LeastMoneyToUseBonus,
                            // 抵扣条件，抵
                            MaxReduceBonus = model.MaxReduceBonus
                        },
                        Discount = model.Discount
                    }
                };

                string url = "https://api.weixin.qq.com/card/create?access_token=" + accessTokenDAL.Get(authorizerAppID);

                LogHelper.Info("创建会员卡url: " + url);
                
                string requestBody = JsonConvert.SerializeObject(card);

                LogHelper.Info("创建会员卡requestBody: " + requestBody);

                string responseBody = HttpHelper.Post(url, requestBody);

                LogHelper.Info("创建会员卡responseBody: " + responseBody);

                CardCreateResp resp = JsonConvert.DeserializeObject<CardCreateResp>(responseBody);
                if (resp.ErrCode == 0)
                {
                    // 存储 authorizerAppID 和 cardID 之间的对应关系
                    cardInfoDAL.Insert(authorizerAppID, resp.CardID, DateTime.Now);
                    return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.成功, Msg = string.Format(codeMsgDAL.GetByCode((int)CodeEnum.成功), "创建成功") });
                }
                else
                {
                    string msg = "errcode: " + resp.ErrCode + ", errmsg: " + resp.ErrMsg;
                    return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.失败, Msg = string.Format(codeMsgDAL.GetByCode((int)CodeEnum.失败), msg) });
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("唐群", ex);
                return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.系统异常, Msg = codeMsgDAL.GetByCode((int)CodeEnum.系统异常) });
            }
        }


    }
}
