using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class MemberCardBaseInfo
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }
        [JsonProperty("code_type")]
        public string CodeType { get; set; }
        [JsonProperty("brand_name", NullValueHandling = NullValueHandling.Ignore)]
        public string BrandName { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("notice")]
        public string Notice { get; set; }
        [JsonProperty("service_phone")]
        public string ServicePhone { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        // 是否自定义Code码
        [JsonProperty("use_custom_code")]
        public bool UseCustomCode { get; set; }
        // 是否支持全部门店
        [JsonProperty("use_all_locations")]
        public bool UseAllLocations { get; set; }

        // 会员卡支付按钮
        [JsonProperty("center_title")]
        public string CenterTitle { get; set; }
        [JsonProperty("center_url")]
        public string CenterUrl { get; set; }

        // 限制
        [JsonProperty("get_limit")]
        public int GetLimit { get; set; }
        [JsonProperty("can_share")]
        public bool CanShare { get; set; }
        [JsonProperty("can_give_friend")]
        public bool CanGiveFriend { get; set; }


        [JsonProperty("date_info")]
        public DataInfo DateInfo { get; set; }
        // 库存
        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public Sku Sku { get; set; }
    }
}