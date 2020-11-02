using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageYourFinance.App.HelperLibary
{
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute() : base(typeof(DateTime), DateTime.Today.ToString("dd/MM/yyyy"), "31/12/2050")
        {

        }
    }
}