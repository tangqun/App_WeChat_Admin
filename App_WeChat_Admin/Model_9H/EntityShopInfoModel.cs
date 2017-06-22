using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class EntityShopInfoModel
    {
        [JsonProperty("sid")]
        public string SID { get; set; }
        [JsonProperty("businessName")]
        public string BusinessName { get; set; }
        [JsonProperty("branchName")]
        public string BranchName { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("telephone")]
        public string Telephone { get; set; }
        [JsonProperty("categories")]
        public List<string> Categories { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("province")]
        public string Province { get; set; }
        [JsonProperty("offsetType")]
        public int OffsetType { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("photoList")]
        public List<string> PhotoList { get; set; }
        [JsonProperty("introduction")]
        public string Introduction { get; set; }
        [JsonProperty("recommend")]
        public string Recomend { get; set; }
        [JsonProperty("special")]
        public string Special { get; set; }
        [JsonProperty("openTime")]
        public string OpenTime { get; set; }
        [JsonProperty("avgPrice")]
        public int AvgPrice { get; set; }
        [JsonProperty("poiID")]
        public string PoiID { get; set; }
        [JsonProperty("availableState")]
        public int AvailableState { get; set; }
        [JsonProperty("district")]
        public string District { get; set; }
        [JsonProperty("updateStatus")]
        public int UpdateStatus { get; set; }
    }
}
