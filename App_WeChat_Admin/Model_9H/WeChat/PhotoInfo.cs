using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class PhotoInfo
    {
        [JsonProperty("photo_url")]
        public string PhotoUrl { get; set; }
    }
}