using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class EntityShopListGetResp
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }
        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }
        [JsonProperty("business_list")]
        public List<EntityShop> BusinessList { get; set; }
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
    }
}