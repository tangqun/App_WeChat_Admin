﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL_9H
{
    public interface ICardInfoDAL
    {
        int Insert(string authorizerAppID, string cardID, DateTime createTime);
    }
}
