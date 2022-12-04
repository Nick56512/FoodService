﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class History
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public virtual Order? Order { get; set; }
    }
}
