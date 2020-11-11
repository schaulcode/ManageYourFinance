using ManageYourFinance.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageYourFinance.App.Models
{
    public class IncomeExpensePayee : IIncomeExpense
    {
        public string Name { get; set; }
        public int Total { get; set; }
        public int Average { get; set; }
        public double Precent { get; set; }
        public CategoryType IncomeOrExpense { get; set; }
    }
}