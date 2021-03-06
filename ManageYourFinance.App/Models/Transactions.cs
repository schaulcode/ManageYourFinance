﻿using ManageYourFinance.Data.Enums;
using ManageYourFinance.Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageYourFinance.App.Models
{
    public class Transactions
    {
        public int ID { get; set; }
        [Required]
        [Range(typeof(DateTime), "01/01/2000", "31/12/2050", ErrorMessage = "The Date has to be between {1:dd/MM/yyyy} and {2:dd/MM/yyyy}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:dd/MM/yyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [DisplayFormat(DataFormatString ="{0:C}")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        public string Tag { get; set; }
        public string Reference { get; set; }
        public string Memo { get; set;}
        [Display(Name = "Account")]
        public string Accounts { get; set; }
        public string Category { get; set; }
        public string Payee { get; set; }
        [Required]
        [Display(Name = "Account")]
        public int AccountsID { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        [Required]
        [Display(Name = "Payee")]
        public int PayeeID { get; set; }
        public int? ScheduleID { get; set; }
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
            this.Accounts = new SqlDataServices<Data.Models.Accounts>().Get(data.AccountsID).Name;
            this.Category = new SqlDataServices<Data.Models.Category>().Get(data.CategoryID).Name;
            this.Payee = new SqlDataServices<Data.Models.Payee>().Get(data.PayeeID).Name;
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