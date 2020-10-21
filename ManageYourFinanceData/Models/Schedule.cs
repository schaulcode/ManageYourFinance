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
        public int Amount { get; set; }
        public string Frequency { get; set; }
        public string NextDueDay { get; set; }
        public int TotalAmount { get; set; }
        public int TotalCount { get; set; }
        public DateTime EndsOnDate { get; set; }
        public int AmountCount { get; set; }
        public int CountCount { get; set; }


    }
}
