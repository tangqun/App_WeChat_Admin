using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class Card
    {
        [JsonProperty("card_type")]
        public string CardType { get; set; }
        [JsonProperty("member_card")]
        public MemberCard MemberCard { get; set; }

        // 别的卡片类型
    }
}