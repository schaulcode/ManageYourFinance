using ManageYourFinance.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourFinance.Data.Models
{
    public class Accounts
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public AccountsType Type { get; set; }
        public bool Active { get; set; } = true;
        public bool IncludeTotal { get; set; } = true;
        public int? OpeningBalance { get; set; }

    }
}
