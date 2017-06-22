using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class EntityShopInfo
    {
        [JsonProperty("sid")]
        public string SID { get; set; }
        [JsonProperty("business_name")]
        public string BusinessName { get; set; }
        [JsonProperty("branch_name")]
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
        [JsonProperty("offset_type")]
        public int OffsetType { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("photo_list")]
        public List<PhotoInfo> PhotoList { get; set; }
        [JsonProperty("introduction")]
        public string Introduction { get; set; }
        [JsonProperty("recommend")]
        public string Recomend { get; set; }
        [JsonProperty("special")]
        public string Special { get; set; }
        [JsonProperty("open_time")]
        public string OpenTime { get; set; }
        [JsonProperty("avg_price")]
        public int AvgPrice { get; set; }
        [JsonProperty("poi_id")]
        public string PoiID { get; set; }
        [JsonProperty("available_state")]
        public int AvailableState { get; set; }
        [JsonProperty("district")]
        public string District { get; set; }
        [JsonProperty("update_status")]
        public int UpdateStatus { get; set; }
    }
}