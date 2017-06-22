using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class EntityShopListGetReq
    {
        [JsonProperty("begin")]
        public int Begin { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}