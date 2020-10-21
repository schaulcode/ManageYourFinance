using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageYourFinance.App.Models
{
    public class Transactions
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public int Amount { get; set; }
        public string Tag { get; set; }
        public string Reference { get; set; }
        public string Memo { get; set; }
        public int AccountsID { get; set; }
        public int CategoryID { get; set; }
        public int PayeeID { get; set; }
        public int ScheduleID { get; set; }
        public Transactions()
        {

        }
        public Transactions(Data.Models.Transactions data)
        {
            this.ID = data.ID;
            this.Date = data.Date;
            this.Amount = data.Amount;
            this.Reference = data.Reference;
            this.Memo = data.Memo;
            this.Tag = data.Tag;
            this.AccountsID = data.AccountsID;
            this.CategoryID = data.CategoryID;
            this.PayeeID = data.PayeeID;
            this.ScheduleID = data.ScheduleID;
        }
        public Data.Models.Transactions Reversemapper()
        {
            return new Data.Models.Transactions
            {
                ID = this.ID,
                Date = this.Date,
                Amount = this.Amount,
                Reference = this.Reference,
                Memo = this.Memo,
                Tag = this.Tag,
                AccountsID = this.AccountsID,
                CategoryID = this.CategoryID,
                PayeeID = this.PayeeID,
                ScheduleID = this.ScheduleID
            };
        }
    }
}