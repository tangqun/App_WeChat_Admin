using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class CardListGetReq
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("status_list")]
        public List<string> StatusList { get; set; }
    }
}
