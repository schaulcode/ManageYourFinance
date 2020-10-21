using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourFinance.Data.Models
{
    public class Accounts
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public bool IncludeTotal { get; set; }
        public int OpeningBalance { get; set; }

    }
}
