using Helper_9H;
using Model_9H;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberCardTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CardCreateReq req = new CardCreateReq()
            {
                Card = new Card()
                {
                    CardType = "MEMBER_CARD",
                    MemberCard = new MemberCard()
                    {
                        BackgroundPicUrl = "http://mmbiz.qpic.cn/mmbiz_png/Wj6TwkVleG6srmSo10D9l0ayKjj7Jaq6zUmVo7xEKgfxWDBpzBx1M0QzIsgaDwPqLkhHcnnYgjft3qgSmJQczw/0",
                        BaseInfo = new MemberCardBaseInfo()
                        {
                            LogoUrl = "http://mmbiz.qpic.cn/mmbiz_jpg/Wj6TwkVleG6srmSo10D9l0ayKjj7Jaq6m68PcSYJ8Pk4wkHGHdbg1iaogWDeRic86ibXxpGxl31yibuY9ics6OETBvw/0",
                            BrandName = "现代纯K量贩式KTV",
                            CodeType = "CODE_TYPE_QRCODE",
                            Title = "现代纯K量贩式KTV",
                            Color = "Color010",
                            Notice = "使用时向服务员出示此卡",
                            ServicePhone = "15210470906",
                            Description = "1.消费时请出示会员卡 2.会员余额不可提现 3.会员积分可以兑换相应的奖品或者优惠 4.具体积分使用规则参考商家制定的积分政策",

                            DateInfo = new DataInfo() { Type = "DATE_TYPE_PERMANENT" },
                            // 一亿
                            Sku = new Sku() { Quantity = 100000000 },

                            GetLimit = 1,
                            CanGiveFriend = false,
                            CanShare = false,

                            // 不使用自定义Code，卡面显示手机号
                            UseCustomCode = false,
                            UseAllLocations = true,

                            CenterTitle = "会员买单",
                            CenterUrl = "http://wxab6d7123cc1125f5.wx.smartyancheng.com/order/create"

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
                        Prerogative = "1.会员等级随着客户成长值进行升级 2.不同等级会员享受不同的折扣优惠",

                        // 激活相关
                        AutoActivate = false,
                        WXActivate = false,
                        // 激活页面
                        ActivateUrl = "http://wxab6d7123cc1125f5.wx.smartyancheng.com/membercard/activate",

                        // 是否支持储值
                        SupplyBalance = false,

                        //CustomField1 = new CustomField()
                        //{
                        //    // 不行就用 Name , 积分变动触发 is_notify_bonus
                        //    // 其他两个触发 is_notify_custom_field2 is_notify_custom_field3
                        //    NameType = "FIELD_NAME_TYPE_STAMP",
                        //    Url = "http://wxab6d7123cc1125f5.wx.smartyancheng.com/bonus"
                        //},
                        CustomField2 = new CustomField()
                        {
                            // 优惠券
                            NameType = "FIELD_NAME_TYPE_COUPON",
                            Url = "http://wxab6d7123cc1125f5.wx.smartyancheng.com/coupon"
                        },
                        CustomField3 = new CustomField()
                        {
                            // 等级
                            NameType = "FIELD_NAME_TYPE_LEVEL",
                            Url = "http://wxab6d7123cc1125f5.wx.smartyancheng.com/level"
                        },

                        // 积分相关
                        SupplyBonus = true,
                        BonusRule = new BonusRule()
                        {
                            // 满
                            CostMoneyUnit = 1,
                            // 送
                            IncreaseBonus = 1,
                            // 单次获得上限
                            //MaxIncreaseBonus = 0,
                            // 初始积分
                            InitIncreaseBonus = 20,
                            // 用积分
                            CostBonusUnit = 100,
                            // 抵现金
                            ReduceMoney = 100,
                            // 抵扣条件，满xx元（这里以分为单位）可用
                            //LeastMoneyToUseBonus = 0,
                            // 抵扣条件，单笔最多使用xx积分。     
                            //MaxReduceBonus = 0
                        },
                        Discount = 9.9F
                    }
                }
            };

            string url = "https://api.weixin.qq.com/card/create?access_token=" + "_NQAGzWMDM_T086kzEUtQPbgNGcE8tY_PZW_cgDeCmnO70kyFpar7hm8M7Ed3_bYITZUODkjh7L5UVJ6HuutSGMAA7V1GCmDujGlHj1tXmWxvLSvnxxQnZGuB_xm_D7xBWNaAJDOJA";

            string requestBody = JsonConvert.SerializeObject(req);

            //string responseBody = HttpHelper.Post(url, requestBody);


            #region 更新
            //CardCreateReq req = new CardCreateReq()
            //{
            //    Card = new Card()
            //    {
            //        CardID = "pp8Cv1bypNXD5z-KwoatVEaYJa0w",
            //        MemberCard = new MemberCard()
            //        {
            //            BackgroundPicUrl = "http://mmbiz.qpic.cn/mmbiz_png/Wj6TwkVleG6srmSo10D9l0ayKjj7Jaq6zUmVo7xEKgfxWDBpzBx1M0QzIsgaDwPqLkhHcnnYgjft3qgSmJQczw/0",
            //            BaseInfo = new MemberCardBaseInfo()
            //            {
            //                LogoUrl = "http://mmbiz.qpic.cn/mmbiz_jpg/Wj6TwkVleG6srmSo10D9l0ayKjj7Jaq6m68PcSYJ8Pk4wkHGHdbg1iaogWDeRic86ibXxpGxl31yibuY9ics6OETBvw/0",
            //                CodeType = "CODE_TYPE_QRCODE",
            //                Title = "现代纯K量贩式KTV",
            //                Color = "Color010",
            //                Notice = "使用时向服务员出示此券",
            //                ServicePhone = "15210470906",
            //                Description = "1.消费时请出示会员卡 2.会员余额不可提现 3.会员积分可以兑换相应的奖品或者优惠 3.具体积分使用规则参考商家制定的积分政策",

            //                DateInfo = new DataInfo() { Type = "DATE_TYPE_PERMANENT" },

            //                GetLimit = 1,
            //                CanGiveFriend = false,
            //                CanShare = false,

            //                UseCustomCode = false,
            //                UseAllLocations = true,

            //                CenterTitle = "会员买单",
            //                CenterUrl = "http://wxab6d7123cc1125f5.wx.smartyancheng.com/membercard/gopay"

            //                // custom_url_name
            //                // custom_url
            //                // custom_url_sub_title
            //                // promotion_url_name
            //                // promotion_url
            //                // promotion_url_sub_title

            //                // need_push_on_view
            //            },
            //            AdvancedInfo = new MemberCardAdvancedInfo()
            //            {
            //                BusinessService = new List<string>()
            //            {
            //                "BIZ_SERVICE_FREE_WIFI",
            //                "BIZ_SERVICE_WITH_PET",
            //                "BIZ_SERVICE_FREE_PARK",
            //                "BIZ_SERVICE_DELIVER"
            //            }
            //            },
            //            // 会员卡特权说明
            //            Prerogative = "1.会员等级随着客户成长值进行升级 2.不同等级会员享受不同的折扣优惠",

            //            // 激活相关
            //            AutoActivate = false,
            //            WXActivate = false,
            //            // 激活页面
            //            ActivateUrl = "http://wxab6d7123cc1125f5.wx.smartyancheng.com/membercard/activate",

            //            // 是否支持储值
            //            SupplyBalance = false,

            //            //CustomField1 = new CustomField()
            //            //{
            //            //    // 不行就用 Name , 积分变动触发 is_notify_bonus
            //            //    // 其他两个触发 is_notify_custom_field2 is_notify_custom_field3
            //            //    NameType = "FIELD_NAME_TYPE_STAMP",
            //            //    Url = "http://wxab6d7123cc1125f5.wx.smartyancheng.com/bonus"
            //            //},
            //            CustomField2 = new CustomField()
            //            {
            //                NameType = "FIELD_NAME_TYPE_LEVEL",
            //                Url = "http://wxab6d7123cc1125f5.wx.smartyancheng.com/level"
            //            },
            //            CustomField3 = new CustomField()
            //            {
            //                NameType = "FIELD_NAME_TYPE_COUPON",
            //                Url = "http://wxab6d7123cc1125f5.wx.smartyancheng.com/coupon"
            //            },

            //            // 积分相关
            //            SupplyBonus = true,
            //            BonusRule = new BonusRule()
            //            {
            //                // 满
            //                CostMoneyUnit = 1,
            //                // 送
            //                IncreaseBonus = 1,
            //                //MaxIncreaseBonus = 0,
            //                InitIncreaseBonus = 20,
            //                // 用
            //                CostBonusUnit = 100,
            //                // 抵
            //                ReduceMoney = 100,
            //                // 抵扣条件，满
            //                //LeastMoneyToUseBonus = 0,
            //                // 抵扣条件，抵
            //                //MaxReduceBonus = 0
            //            },
            //            Discount = 9.9F
            //        }
            //    }
            //};

            //string url = "https://api.weixin.qq.com/card/update?access_token=" + "-MdWNMw0epZqdaKLruAs8iy4yFh1w1jq9ArdIfAT4x-XmDMhZc3jWqVBtJ_TH3khQ7sFq7nR41kC4YvvyfopZ6To3DxLTCXJBG7pgOeMJz-JVGJyhug9w4YLm3QhFrS9WSQgAFDIEC";

            //string requestBody = JsonConvert.SerializeObject(req);

            //string responseBody = HttpHelper.Post(url, requestBody); 
            #endregion

            Console.ReadLine();
        }
    }
}
