using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class CardListGetResp
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }
        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }
        [JsonProperty("card_id_list")]
        public List<string> CardIDList { get; set; }
        [JsonProperty("total_num")]
        public int TotalNum { get; set; }
    }
}
