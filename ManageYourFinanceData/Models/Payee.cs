﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourFinance.Data.Models
{
    public class Payee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public int CategoryID { get; set; } = 0;
    }
}
