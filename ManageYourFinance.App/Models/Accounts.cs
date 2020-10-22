﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManageYourFinance.Data.Models;

namespace ManageYourFinance.App.Models
{
    public class Accounts
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public bool IncludeTotal { get; set; }
        public int OpeningBalance { get; set; }
        public List<Transactions> Transactions { get; set; } = new List<Transactions>();

        public Accounts()
        {

        }
        public Accounts(ManageYourFinance.Data.Models.Accounts data)
        {
            this.ID = data.ID;
            this.Name = data.Name;
            this.Type = data.Type;
            this.Active = data.Active;
            this.IncludeTotal = data.IncludeTotal;
            this.OpeningBalance = data.OpeningBalance;
        }
        public ManageYourFinance.Data.Models.Accounts ReverseMapper()
        {
            return new ManageYourFinance.Data.Models.Accounts
            {
                ID = this.ID,
                Name = this.Name,
                Type = this.Type,
                Active = this.Active,
                IncludeTotal = this.IncludeTotal,
                OpeningBalance = this.OpeningBalance
            };
        }
    }
}