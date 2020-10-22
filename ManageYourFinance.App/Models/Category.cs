﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageYourFinance.App.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public List<Payee> Payees { get; set; } = new List<Payee>();
        public List<Transactions> Transactions { get; set; } = new List<Transactions>();

        public Category()
        {

        }
        public Category(ManageYourFinance.Data.Models.Category data)
        {
            this.ID = data.ID;
            this.Name = data.Name;
            this.Type = data.Type;
            this.Active = data.Active;
        }
    public Data.Models.Category ReverseMapper()
        {
            return new Data.Models.Category
            {
                ID = this.ID,
                Name = this.Name,
                Type = this.Type,
                Active = this.Active
            };
        }
    }
} 