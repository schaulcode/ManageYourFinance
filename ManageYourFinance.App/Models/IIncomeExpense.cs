using ManageYourFinance.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourFinance.App.Models
{
    public interface IIncomeExpense
    {
        string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        double Total { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        double Average { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name ="%")]
        double Precent { get; set; }
        CategoryType IncomeOrExpense { get; set; }
    }
}
