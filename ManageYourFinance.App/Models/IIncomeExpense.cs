using ManageYourFinance.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourFinance.App.Models
{
    interface IIncomeExpense
    {
        string Name { get; set; }
        int Total { get; set; }
        int Average { get; set; }
        double Precent { get; set; }
        CategoryType IncomeOrExpense { get; set; }
    }
}
