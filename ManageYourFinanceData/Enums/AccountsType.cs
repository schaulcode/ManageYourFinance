using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourFinance.Data.Enums
{
    public enum AccountsType
    {
        [Display(Name = "Credit Card")]
        CreditCard = 1,
        [Display(Name = "Cash")]
        Cash = 2,
        [Display(Name ="Bank Account")]
        BankAccount = 3,
        [Display(Name = "Other Account")]
        OtherAccount = 4

    }
}
