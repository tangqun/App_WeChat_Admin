using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class EntityShopGetReq
    {
        [JsonProperty("poi_id")]
        public string PoiID { get; set; }
    }
}