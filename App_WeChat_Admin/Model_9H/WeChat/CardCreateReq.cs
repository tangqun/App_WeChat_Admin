﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class CardCreateReq
    {
        [JsonProperty("card")]
        public Card Card { get; set; }
    }
}
