using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManageYourFinance.Data.Models;
using System.ComponentModel.DataAnnotations;
using ManageYourFinance.Data.Enums;

namespace ManageYourFinance.App.Models
{
    public class Accounts
    {
        
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="Please Select a Type")]
        public AccountsType Type { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public bool IncludeTotal { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public int? OpeningBalance { get; set; }
        public List<Transactions> Transactions { get; set; } = new List<Transactions>();
        public double Total { get; set; }

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