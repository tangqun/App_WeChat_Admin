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
                        BackgroundPicUrl = model.BackgroundPicUrl,
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
                            //CenterSubTitle = "买单立享" + model.Discount + "折，更有积分相送",
                            CenterUrl = string.Format(ConfigHelper.DomainWeChat, authorizerAppID) + "membercard/gopay"

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
                        // 激活页面
                        ActivateUrl = string.Format(ConfigHelper.DomainWeChat, authorizerAppID) + "membercard/activate",

                        // 是否支持储值
                        SupplyBalance = false,

                        //CustomField1 = new CustomField()
                        //{
                        //    // 不行就用 Name , 积分变动触发 is_notify_bonus
                        //    // 其他两个触发 is_notify_custom_field2 is_notify_custom_field3
                        //    NameType = "FIELD_NAME_TYPE_STAMP",
                        //    Url = string.Format(ConfigHelper.DomainWeChat, authorizerAppID) + "bonus"
                        //},
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

                AuthorizationInfoModel authorizationInfoModel = accessTokenDAL.Get(authorizerAppID);
                string url = "https://api.weixin.qq.com/card/create?access_token=" + authorizationInfoModel.AuthorizerAccessToken;

                LogHelper.Info("创建会员卡 url", url);

                string requestBody = JsonConvert.SerializeObject(card);

                LogHelper.Info("创建会员卡 requestBody", requestBody);

                string responseBody = HttpHelper.Post(url, requestBody);

                LogHelper.Info("创建会员卡 responseBody", responseBody);

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
                LogHelper.Error(ex);
                return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.系统异常, Msg = codeMsgDAL.GetByCode((int)CodeEnum.系统异常) });
            }
        }

        public MemberCardModel GetModel(string authorizerAppID, string cardID)
        {
            try
            {
                AuthorizationInfoModel authorizationInfoModel = accessTokenDAL.Get(authorizerAppID);
                string url = "https://api.weixin.qq.com/card/get?access_token=" + authorizationInfoModel.AuthorizerAccessToken;

                LogHelper.Info("查询卡券详情 url", url);

                CardGetReq req = new CardGetReq()
                {
                    CardID = cardID
                };
                string requestBody = JsonConvert.SerializeObject(req);

                LogHelper.Info("查询卡券详情 requestBody", requestBody);

                string responseBody = HttpHelper.Post(url, requestBody);

                LogHelper.Info("查询卡券详情 responseBody", responseBody);

                CardGetResp resp = JsonConvert.DeserializeObject<CardGetResp>(responseBody);
                if (resp.ErrCode == 0)
                {
                    switch (resp.Card.CardType)
                    {
                        case "MEMBER_CARD":
                            MemberCard card = resp.Card.MemberCard;
                            return new MemberCardModel()
                            {
                                BackgroundPicUrl = card.BackgroundPicUrl,
                                CardID = card.BaseInfo.ID,
                                LogoUrl = card.BaseInfo.LogoUrl,
                                BrandName = card.BaseInfo.BrandName,

                                Title = card.BaseInfo.Title,

                                Notice = card.BaseInfo.Notice,
                                ServicePhone = card.BaseInfo.ServicePhone,
                                Description = card.BaseInfo.Description,
                                
                                // 会员卡特权说明
                                Prerogative = card.Prerogative,

                                ServiceFreeWIFI = card.AdvancedInfo.BusinessService.Contains("BIZ_SERVICE_FREE_WIFI"),
                                ServiceWithPet = card.AdvancedInfo.BusinessService.Contains("BIZ_SERVICE_WITH_PET"),
                                ServiceFreePark = card.AdvancedInfo.BusinessService.Contains("BIZ_SERVICE_FREE_PARK"),
                                ServiceDeliver = card.AdvancedInfo.BusinessService.Contains("BIZ_SERVICE_DELIVER"),

                                // 满
                                CostMoneyUnit = card.BonusRule.CostMoneyUnit,
                                // 送
                                IncreaseBonus = card.BonusRule.IncreaseBonus,
                                MaxIncreaseBonus = card.BonusRule.MaxIncreaseBonus,
                                InitIncreaseBonus = card.BonusRule.InitIncreaseBonus,
                                // 用
                                CostBonusUnit = card.BonusRule.CostBonusUnit,
                                // 抵
                                ReduceMoney = card.BonusRule.ReduceMoney,
                                // 抵扣条件，满
                                LeastMoneyToUseBonus = card.BonusRule.LeastMoneyToUseBonus,
                                // 抵扣条件，抵
                                MaxReduceBonus = card.BonusRule.MaxReduceBonus,

                                Discount = card.Discount
                            };
                        default:
                            return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return null;
            }
        }

        public string Update(string authorizerAppID, MemberCardModel model)
        {
            try
            {
                Card card = new Card()
                {
                    CardID = model.CardID,
                    MemberCard = new MemberCard()
                    {
                        BackgroundPicUrl = model.BackgroundPicUrl,
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
                            //CenterSubTitle = "买单立享" + model.Discount + "折，更有积分相送",
                            CenterUrl = string.Format(ConfigHelper.DomainWeChat, authorizerAppID) + "membercard/gopay"

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
                        // 激活页面
                        ActivateUrl = string.Format(ConfigHelper.DomainWeChat, authorizerAppID) + "membercard/activate",

                        // 是否支持储值
                        SupplyBalance = false,

                        //CustomField1 = new CustomField()
                        //{
                        //    // 不行就用 Name , 积分变动触发 is_notify_bonus
                        //    // 其他两个触发 is_notify_custom_field2 is_notify_custom_field3
                        //    NameType = "FIELD_NAME_TYPE_STAMP",
                        //    Url = string.Format(ConfigHelper.DomainWeChat, authorizerAppID) + "bonus"
                        //},
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

                AuthorizationInfoModel authorizationInfoModel = accessTokenDAL.Get(authorizerAppID);
                string url = "https://api.weixin.qq.com/card/update?access_token=" + authorizationInfoModel.AuthorizerAccessToken;

                LogHelper.Info("更新会员卡 url", url);

                string requestBody = JsonConvert.SerializeObject(card);

                LogHelper.Info("更新会员卡 requestBody", requestBody);

                string responseBody = HttpHelper.Post(url, requestBody);

                LogHelper.Info("更新会员卡 responseBody", responseBody);

                CardCreateResp resp = JsonConvert.DeserializeObject<CardCreateResp>(responseBody);
                if (resp.ErrCode == 0)
                {
                    // 存储 authorizerAppID 和 cardID 之间的对应关系
                    cardInfoDAL.Insert(authorizerAppID, resp.CardID, DateTime.Now);
                    return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.成功, Msg = string.Format(codeMsgDAL.GetByCode((int)CodeEnum.成功), "更新成功") });
                }
                else
                {
                    string msg = "errcode: " + resp.ErrCode + ", errmsg: " + resp.ErrMsg;
                    return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.失败, Msg = string.Format(codeMsgDAL.GetByCode((int)CodeEnum.失败), msg) });
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return JsonConvert.SerializeObject(new RESTfulModel() { Code = (int)CodeEnum.系统异常, Msg = codeMsgDAL.GetByCode((int)CodeEnum.系统异常) });
            }
        }

        public List<MemberCardModel> GetList(string authorizerAppID)
        {
            try
            {
                AuthorizationInfoModel authorizationInfoModel = accessTokenDAL.Get(authorizerAppID);
                string url = "https://api.weixin.qq.com/card/batchget?access_token=" + authorizationInfoModel.AuthorizerAccessToken;

                LogHelper.Info("批量查询卡券列表 url", url);

                CardListGetReq req = new CardListGetReq()
                {
                    Offset = 0,
                    Count = 10
                };
                string requestBody = JsonConvert.SerializeObject(req);

                LogHelper.Info("批量查询卡券列表 requestBody", requestBody);

                string responseBody = HttpHelper.Post(url, requestBody);

                LogHelper.Info("批量查询卡券列表 responseBody", responseBody);

                CardListGetResp resp = JsonConvert.DeserializeObject<CardListGetResp>(responseBody);

                List<MemberCardModel> memberCardModelList = new List<MemberCardModel>();

                if (resp.ErrCode == 0)
                {
                    List<string> cardIDList = resp.CardIDList;
                    if (cardIDList.Any())
                    {
                        foreach (var cardID in cardIDList)
                        {
                            MemberCardModel memberCardModel = GetModel(authorizerAppID, cardID);
                            if (memberCardModel != null)
                            {
                                memberCardModelList.Add(memberCardModel);
                            }
                        }
                    }
                }

                return memberCardModelList;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return null;
            }
        }

        // 不支持删除
    }
}
