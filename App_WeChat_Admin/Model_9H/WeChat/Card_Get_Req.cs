using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class Card_Get_Req
    {
        [JsonProperty("card_id")]
        public string Card_Id { get; set; }
    }
}