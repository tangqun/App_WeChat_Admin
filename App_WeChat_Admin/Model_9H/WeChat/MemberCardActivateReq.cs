using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class MemberCardActivateReq
    {
        [JsonProperty("membership_number")]
        public string MembershipNumber { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("card_id")]
        // 卡券ID，自定义Code卡券必填
        public string CardID { get; set; }
        [JsonProperty("init_bonus")]
        // 初始积分，不填为0
        public int InitBonus { get; set; }
        [JsonProperty("init_bonus_record")]
        // 积分同步说明
        public string InitBonusRecord { get; set; }
        [JsonProperty("init_balance")]
        // 初始余额，不填为0
        public int InitBalance { get; set; }
        [JsonProperty("init_custom_field_value1")]
        public string InitCustomFieldValue1 { get; set; }
        [JsonProperty("init_custom_field_value2")]
        public string InitCustomFieldValue2 { get; set; }
        [JsonProperty("init_custom_field_value3")]
        public string InitCustomFieldValue3 { get; set; }
    }
}
