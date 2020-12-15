using ManageYourFinance.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageYourFinance.App.Models
{
    public class IncomeExpenseTable
    {
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double LeftTotal { get; set; }
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double LeftAverage { get; set; }
        [Display(Name = "%")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double LeftPrecent { get; set; }

        public double RightTotal { get; set; }
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double RightAverage { get; set; }
        [Display(Name = "%")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double RightPrecent { get; set; }

        public CategoryType IncomeOrExpense { get; set; }

        public IncomeExpenseTable(IIncomeExpense left, IIncomeExpense right)
        {
            if(left != null)
            {
                this.Name = left.Name;
                this.LeftTotal = left.Total;
                this.LeftAverage = left.Average;
                this.LeftPrecent = left.Precent;
                this.IncomeOrExpense = left.IncomeOrExpense;
            }
            if (right != null)
            {
                this.RightTotal = right.Total;
                this.RightAverage = right.Average;
                this.RightPrecent = right.Precent;
                this.IncomeOrExpense = right.IncomeOrExpense; // In case Left is null but right is not this expression should set the field
            }



        }

        public static IEnumerable<IncomeExpenseTable> GetModel (IEnumerable<IIncomeExpense> left, IEnumerable<IIncomeExpense> right)
        {
            var modelList = new List<IncomeExpenseTable>();
            if(left.Count() > right.Count())
            {
                foreach (var item in left)
                {
                    var rightColumn = right.Where(e => e.Name == item.Name).FirstOrDefault();
                    modelList.Add(new IncomeExpenseTable(item, rightColumn));
                }
            }
            else
            {
                foreach (var item in right)
                {
                    var leftColumn = left.Where(e => e.Name == item.Name).FirstOrDefault();
                    modelList.Add(new IncomeExpenseTable(item, leftColumn));
                }
            }

            return modelList;
        }
    }
}