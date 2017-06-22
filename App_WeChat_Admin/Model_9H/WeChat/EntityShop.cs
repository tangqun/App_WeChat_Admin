using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class EntityShop
    {
        [JsonProperty("base_info")]
        public EntityShopInfo BaseInfo { get; set; }
    }
}