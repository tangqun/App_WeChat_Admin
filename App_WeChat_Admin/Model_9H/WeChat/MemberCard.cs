using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class MemberCard
    {
        [JsonProperty("background_pic_url")]
        public string BackgroundPicUrl { get; set; }

        // 基础信息
        [JsonProperty("base_info")]
        public MemberCardBaseInfo BaseInfo { get; set; }
        
        // 高级信息
        [JsonProperty("advanced_info")]
        public MemberCardAdvancedInfo AdvancedInfo { get; set; }

        // 特权
        [JsonProperty("prerogative")]
        public string Prerogative { get; set; }

        // 激活相关
        [JsonProperty("auto_activate")]
        public bool AutoActivate { get; set; }
        [JsonProperty("wx_activate")]
        public bool WXActivate { get; set; }
        [JsonProperty("activate_url")]
        public string ActivateUrl { get; set; }

        // 是否支持储值
        [JsonProperty("supply_balance")]
        public bool SupplyBalance { get; set; }

        // 积分相关
        [JsonProperty("supply_bonus")]
        public bool SupplyBonus { get; set; }
        
        [JsonProperty("bonus_rule")]
        public BonusRule BonusRule { get; set; }

        // 折扣
        [JsonProperty("discount")]
        public float Discount { get; set; }

        // 会员类目
        [JsonProperty("custom_field1")]
        public CustomField CustomField1 { get; set; }
        [JsonProperty("custom_field2")]
        public CustomField CustomField2 { get; set; }
        [JsonProperty("custom_field3")]
        public CustomField CustomField3 { get; set; }
    }
}