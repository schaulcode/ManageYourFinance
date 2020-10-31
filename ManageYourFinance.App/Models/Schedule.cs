using ManageYourFinance.Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageYourFinance.App.Models
{
    public class Schedule
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Account")]
        public int AccountsID { get; set; }
        [Required]
        [Display(Name ="Category")]
        public int CategoryID { get; set; }
        [Required]
        [Display(Name ="Payee")]
        public int PayeeID { get; set; }
        public string Accounts { get; set; }
        public string Category { get; set; }
        public string Payee { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Frequency { get; set; }
        [Required]
        public string NextDueDay { get; set; }
        public int? TotalAmount { get; set; }
        public int? TotalCount { get; set; }
        public DateTime? EndsOnDate { get; set; }
        public int? AmountCount { get; set; }
        public int? CountCount { get; set; }
        public List<Transactions> Transactions { get; set; } = new List<Transactions>();
        public Schedule()
        {

        }
        public Schedule(Data.Models.Schedule data)
        {
            this.ID = data.ID;
            this.AccountsID = data.AccountsID;
            this.CategoryID = data.CategoryID;
            this.PayeeID = data.PayeeID;
            this.Accounts = new SqlDataServices<Data.Models.Accounts>().Get(data.AccountsID).Name;
            this.Category = new SqlDataServices<Data.Models.Category>().Get(data.CategoryID).Name;
            this.Payee = new SqlDataServices<Data.Models.Payee>().Get(data.PayeeID).Name;
            this.Amount = data.Amount;
            this.Frequency = data.Frequency;
            this.NextDueDay = data.NextDueDay;
            this.TotalAmount = data.TotalAmount;
            this.TotalCount = data.TotalCount;
            this.EndsOnDate = data.EndsOnDate;
            this.AmountCount = data.AmountCount;
            this.CountCount = data.CountCount;
        }
        public Data.Models.Schedule ReverseMapper()
        {
            return new Data.Models.Schedule
            {
                ID = this.ID,
                AccountsID = this.AccountsID,
                CategoryID = this.CategoryID,
                PayeeID = this.PayeeID,
                Amount = this.Amount,
                Frequency = this.Frequency,
                NextDueDay = this.NextDueDay,
                TotalAmount = this.TotalAmount,
                TotalCount = this.TotalCount,
                EndsOnDate = this.EndsOnDate,
                AmountCount = this.AmountCount,
                CountCount = this.CountCount,
            };
        }
    }
    
}