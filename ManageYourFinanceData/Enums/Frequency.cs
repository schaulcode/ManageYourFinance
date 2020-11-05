using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourFinance.Data.Enums
{
    public enum Frequency
    {
        Monthly,
        Weekly,
        Yearly,
        Quarterly,
        [Display(Name = "One Time Payment")]
        OneTimePayment,
        [Display(Name ="Every Two Weeks")]
        EveryTwoWeeks,
        [Display(Name ="Every Four Weeks")]
        EveryFourWeeks,
        [Display(Name ="Twice a Month")]
        TwiceMonth,
        [Display(Name ="Every Two Month")]
        EveryTwoMonth,
        [Display(Name ="Twice a Year")]
        TwiceYear,
        [Display(Name = "Paid off")]
        PaidOff
    }
}
