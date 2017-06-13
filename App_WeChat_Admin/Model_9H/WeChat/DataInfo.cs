using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class DataInfo
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
