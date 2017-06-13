using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model_9H
{
    public class Card_Get_Resp
    {
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public Card Card { get; set; }
    }
}