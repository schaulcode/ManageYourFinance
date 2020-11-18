using ManageYourFinance.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourFinance.Data.Models
{
    public class Schedule
    {
        public int ID { get; set; }
        public int AccountsID { get; set; }
        public int CategoryID { get; set; }
        public int PayeeID { get; set; }
        public double Amount { get; set; }
        public Frequency Frequency { get; set; }
        public DateTime NextDueDay { get; set; }
        public double? TotalAmount { get; set; }
        public int? TotalCount { get; set; }
        public DateTime? EndsOnDate { get; set; }
        public double? AmountCount { get; set; }
        public int? CountCount { get; set; }
    }
    
}
