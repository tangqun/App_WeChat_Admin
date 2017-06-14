using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class CardGetReq
    {
        [JsonProperty("card_id")]
        public string CardID { get; set; }
    }
}