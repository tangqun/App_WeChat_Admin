using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class UploadIMGReq
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("buffer")]
        public Stream Buffer { get; set; }
    }
}
