using ManageYourFinance.Data.Enums;
using ManageYourFinance.Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageYourFinance.App.Models
{
    public class IncomeExpenseCategory : IIncomeExpense
    {
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double Total { get; set ; }
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double Average { get ; set ; }
        [Display(Name = "%")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double Precent { get ; set ; }
        public CategoryType IncomeOrExpense { get ; set; }

        public IncomeExpenseCategory()
        {

        }

        public IncomeExpenseCategory(Data.Models.Category data, DateTime startDate, DateTime endDate, int averageDividend)
        {
            var transactions = new SqlDataServices<Data.Models.Transactions>().GetAll(data.ID, typeof(Data.Models.Category)).Where(e => e.Date >= startDate && e.Date <= endDate);

            this.Name = data.Name;
            this.Total = transactions.Select(e => e.Amount).Sum();
            this.Average = this.Total / averageDividend;
            this.IncomeOrExpense = data.Type;
           
        }

        public static IEnumerable<IIncomeExpense> GetModel(IEnumerable<Data.Models.Category> data, DateTime startDate, DateTime endDate, int averageDividend)
        {
            var modelList = new List<IncomeExpenseCategory>();
            foreach (var item in data)
            {
                modelList.Add(new IncomeExpenseCategory(item, startDate, endDate, averageDividend));
            }
            //Precent for Income
            var modelListTotal = modelList.Where(e => e.IncomeOrExpense == CategoryType.Income).Select(e => e.Total).Sum();
            if (modelListTotal != 0)
            {
                foreach (var item in modelList)
                {
                    if (item.IncomeOrExpense == CategoryType.Income)
                    {
                        item.Precent = item.Total * 100 / modelListTotal;
                    }

                }
            }
            
            //Precent for Expense
            modelListTotal = modelList.Where(e => e.IncomeOrExpense == CategoryType.Expense).Select(e => e.Total).Sum();
            if (modelListTotal != 0)
            {
                foreach (var item in modelList)
                {
                    if (item.IncomeOrExpense == CategoryType.Expense)
                    {
                        item.Precent = item.Total * 100 / modelListTotal;
                    }
                }
            }
            modelList.RemoveAll(e => e.Total == 0);
            return modelList;
        }
        
    }

}