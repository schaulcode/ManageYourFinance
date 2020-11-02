using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourFinance.Data.Models
{
    public class Transactions
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Tag { get; set; }
        public string Reference { get; set; }
        public string Memo { get; set; }
        public int AccountsID { get; set; }
        public int CategoryID { get; set; }
        public int PayeeID { get; set; }
        public int? ScheduleID { get; set; }
    }
}
