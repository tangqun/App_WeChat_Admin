using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class CustomField
    {
        [JsonProperty("name_type")]
        public string NameType { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
