﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreDemo.Models
{
    public class Payload
    {
        //使用者資訊
        public User info { get; set; }
        //過期時間
        public int exp { get; set; }
    }
}
