using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourFinance.Data.Models
{
    class Payee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int CategoryID { get; set; }
    }
}
